using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using BlogDemo.Infrastructure.Services;

namespace BlogDemo.Infrastructure.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy, IPropertyMapping propertyMapping)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (propertyMapping == null)
            {
                throw new ArgumentNullException(nameof(propertyMapping));
            }

            var mappingDictionary = propertyMapping.MappingDictionary;
            if (mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            //因为可能根据多个属性排序，所以orderBy可能是xx,xx，所以进行分割
            var orderByAfterSplit = orderBy.Split(',');
            foreach (var orderByClause in orderByAfterSplit.Reverse())
            {
                var trimmedOrderByClause = orderByClause.Trim();
                //是否为倒序
                var orderDescending = trimmedOrderByClause.EndsWith(" desc");

                //IndexOf：返回当前字符串“ ”的索引，以StringComparison.Ordinal方式进行匹配，没找到则返回-1
                var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ", StringComparison.Ordinal);

                //如果为倒序的话存在“ desc”，此步骤后将“ desc”删掉
                //Remove删除从 indexOfFirstSpace索引开始到结尾的字符串，并返回剩余的字符串
                var propertyName = indexOfFirstSpace == -1 ?
                    trimmedOrderByClause : trimmedOrderByClause.Remove(indexOfFirstSpace);

                if (string.IsNullOrEmpty(propertyName))
                {
                    continue;
                }

                //获取字典中key=propertyName的值
                if (!mappingDictionary.TryGetValue(propertyName, out List<MappedProperty> mappedProperties))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }
                if (mappedProperties == null)
                {
                    throw new ArgumentNullException(propertyName);
                }

                //顺序反转  姓名分为：姓-名，在外国 名-姓， 日期分为：年月日，在外国 日月年，
                //所以当dto中的一个属性对应model中的多个属性时需要反转，当然model中的顺序按中国的写
                mappedProperties.Reverse();

                foreach (var destinationProperty in mappedProperties)
                {
                    //Revert是负责标识这个属性是否反过来 因为上面Reverse的时候已经将顺序反过来了，所以如果这个属性不需要反转，
                    //比如年龄等那么上面的Reverse方法虽然改变了他们的顺序但却对他们没有影响。有影响的是那些需要反转的属性，这里写的是需要反转的属性正序变倒叙但是没想明白
                    if (destinationProperty.Revert)
                    {
                        orderDescending = !orderDescending;
                    }
                    source = source.OrderBy(destinationProperty.Name + (orderDescending ? " descending" : " ascending"));
                }
            }

            //查询到的数据返回
            return source;
        }

        //负责检查属性
        public static IQueryable<object> ToDynamicQueryable<TSource>
            (this IQueryable<TSource> source, string fields, Dictionary<string, List<MappedProperty>> mappingDictionary)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if (string.IsNullOrWhiteSpace(fields))
            {
                return (IQueryable<object>)source;
            }

            fields = fields.ToLower();
            var fieldsAfterSplit = fields.Split(',').ToList();
            if (!fieldsAfterSplit.Contains("id", StringComparer.InvariantCultureIgnoreCase))
            {
                fieldsAfterSplit.Add("id");
            }
            var selectClause = "new (";

            foreach (var field in fieldsAfterSplit)
            {
                var propertyName = field.Trim();
                if (string.IsNullOrEmpty(propertyName))
                {
                    continue;
                }

                var key = mappingDictionary.Keys.SingleOrDefault(k => String.CompareOrdinal(k.ToLower(), propertyName.ToLower()) == 0);
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }
                var mappedProperties = mappingDictionary[key];
                if (mappedProperties == null)
                {
                    throw new ArgumentNullException(key);
                }
                foreach (var destinationProperty in mappedProperties)
                {
                    selectClause += $" {destinationProperty.Name},";
                }
            }

            selectClause = selectClause.Substring(0, selectClause.Length - 1) + ")";
            return (IQueryable<object>)source.Select(selectClause);
        }

    }
}
