using System.Collections.Generic;
using BlogDemo.Core.Entites;
using BlogDemo.Core.Interfaces;

namespace BlogDemo.Infrastructure.Services
{
    public abstract class PropertyMapping<TSource, TDestination> : IPropertyMapping 
        where TDestination : Entity
    {
        public Dictionary<string, List<MappedProperty>> MappingDictionary { get; }

        protected PropertyMapping(Dictionary<string, List<MappedProperty>> mappingDictionary)
        {
            MappingDictionary = mappingDictionary;

            MappingDictionary[nameof(Entity.Id)] = new List<MappedProperty>
            {
                new MappedProperty { Name = nameof(Entity.Id), Revert = false}
            };
        }
    }
}
