using AutoMapper;
using AutoMapper.test.Dto;
using AutoMapper.test.Entity;
using demo.Dto;
using demo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.profile
{
    public class first : Profile
    {
        public first()
        {
            //简单映射
            CreateMap<Source,Destination>();
            CreateMap<Destination, Source>();

            //Flattening映射
            CreateMap<Order,OrderDto>();

            //Reverse映射
            CreateMap<Reverse, ReverseDto>().
                ForMember(dto=>dto.CustomerName, r=>r.MapFrom(op=>op.customer.Name)).
                ReverseMap().
                ForPath(r=>r.customer.Name,dto=>dto.MapFrom(op=>op.CustomerName));

        }
    }
}
