using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 用于Flattening映射测试
/// </summary>
namespace demo.Dto
{
    public class OrderDto
    {
        //客户姓名
        public string CustomerName { get; set; }
        //所有商品总价
        public decimal Total { get; set; }
    }
}
