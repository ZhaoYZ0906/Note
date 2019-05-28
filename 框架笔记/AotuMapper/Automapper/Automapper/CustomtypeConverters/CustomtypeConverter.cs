
using demo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace demo.CustomtypeConverters
{
    public class DateTimeTypeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, AutoMapper.ResolutionContext context)
        {
            return System.Convert.ToDateTime(source);
        }

    }

    public class TypeTypeConverter : ITypeConverter<string, Type>
    {
        public Type Convert(string source, Type destination, AutoMapper.ResolutionContext context)
        {
            return Assembly.GetExecutingAssembly().GetType(source);
        }
    }
}
