namespace BlogDemo.Infrastructure.ResourcePlasticity.PlasticityValidator
{
    //此接口负责塑性时检查要塑形的属性在对应类中是否存在
    public interface ITypeHelperService
    {
        bool TypeHasProperties<T>(string fields);
    }
}
