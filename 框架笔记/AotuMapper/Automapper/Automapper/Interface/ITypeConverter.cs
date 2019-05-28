using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Interface
{
    public interface ITypeConverter<in TSource, TDestination>
    {
        TDestination Convert(TSource source, TDestination destination, ResolutionContext context);
    }
}
