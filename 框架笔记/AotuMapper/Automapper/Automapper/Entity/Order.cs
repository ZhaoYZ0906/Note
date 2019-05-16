using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// 用于Flattening映射测试
/// </summary>
namespace demo.Entity
{
    //一张购物清单
    public class Order
    {
        //清单中的所有列
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();


        //主要映射部分
        //顾客信息
        public Customer Customer { get; set; }
        
        //获取所有物品的总价
        public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }



        //在清单中添加一行
        public void AddOrderLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }


    }

    //顾客信息
    public class Customer
    {
        //顾客姓名
        public string Name { get; set; }
    }


    //购物清单中的列类（1列）
    public class OrderLineItem
    {
        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        //物品信息
        public Product Product { get; private set; }
        //数量
        public int Quantity { get; private set; }

        //获取当前物品的总价（数量*单价）
        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }

    //物品类
    public class Product
    {
        //价格
        public decimal Price { get; set; }
        //名称
        public string Name { get; set; }
    }


}
