using AutoMapper;
using AutoMapper.test;
using AutoMapper.test.Dto;
using AutoMapper.test.Entity;
using System;

namespace AotuMapper.test
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 简单的两个对象之间的转换，一般不使用
            Mapper.Initialize(cfg=> { cfg.CreateMap<Source,Destination>(); });

            Source source = new Source {id=1,value="xxx" };

            Destination destination = new Destination { value=""};

            var dto= Mapper.Map<Source, Destination>(source, destination);
            */



            /*  使用文件整合映射关系
             *  这里可以写多个profile文件 并且这一句要在程序运行的开始写
            Mapper.Initialize(cfg => {
                cfg.AddProfile<first>(); 
                cfg.AddProfile<second>(); 
                });

            Source source = new Source { id = 1, value = "aaaa" };

            Destination destination = new Destination { value = "bbb" };

            Mapper.Map<Source, Destination>(source, destination);
            Mapper.Map< Destination, Source> ( destination, source);
             */

            Console.WriteLine(source.value);          

            Console.ReadKey();
        }
    }
}
