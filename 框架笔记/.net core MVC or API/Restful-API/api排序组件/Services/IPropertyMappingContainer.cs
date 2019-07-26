using BlogDemo.Core.Entites;
using BlogDemo.Core.Interfaces;

namespace BlogDemo.Infrastructure.Services
{
    public interface IPropertyMappingContainer
    {
        void Register<T>() where T : IPropertyMapping, new();

        IPropertyMapping Resolve<TSource, TDestination>() where TDestination : Entity;

        bool ValidateMappingExistsFor<TSource, TDestination>(string fields) where TDestination : Entity;
    }
}