﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Automapper.Models;
using AutoMapper;
using AutoMapper.test.Entity;
using AutoMapper.test.Dto;
using demo.Entity;
using demo.Dto;

namespace Automapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper mapper;

        public HomeController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            /*简单映射测试
             * 
            var source = new Source() {id=1,value="xxx" };
            var destination = new Destination() { value="fff"};
            mapper.Map<Source, Destination>(source,destination);
            mapper.Map<Destination, Source>(destination, source);
            */


            /*Flattening映射测试
             * 
            var customer = new Customer
            {
                Name = "顾客姓名"
            };

            var order = new Order
            {
                Customer = customer
            };

            var bosco = new Product
            {
                Name = "商品姓名",
                Price = 4.99m
            };

            order.AddOrderLineItem(bosco, 15);

            OrderDto dto = mapper.Map<Order, OrderDto>(order);
            */


            //Reverse（反向）测试
            /*var reverse = new Reverse() {
                Total=12.31M,                
            };
            reverse.customer = new Reverse_Customer() {
                Name = "zyz"
            };

            var reversedto = new ReverseDto() {
            };
            mapper.Map(reverse,reversedto);
            reversedto.CustomerName = "wbb";

            mapper.Map(reversedto,reverse);
            */


            //Projection(投影映射)
            /*var calendarEvent = new CalendarEvent
            {
                Date = new DateTime(2008, 12, 15, 20, 30, 0),
                Title = "Company Holiday Party"
            };

            var result=mapper.Map<CalendarEvent, CalendarEventForm>(calendarEvent);
            */

            //自定义映射
            /*
            var custom = new Custom
            {
                Value1 = "5",
                Value2 = "01/01/2000",
                Value3 = "AutoMapperSamples.GlobalTypeConverters.GlobalTypeConverters+Destination"
            };

            CustomDTO result = mapper.Map<Custom, CustomDTO>(custom);
            */

            //空替换
            var nullreplace = new nullreplace();
            nullreplaceDTO dTO = mapper.Map<nullreplace, nullreplaceDTO>(nullreplace);

            return View();
        }


    }
}
