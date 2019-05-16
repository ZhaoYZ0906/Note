using AutoMapper.test.Dto;
using AutoMapper.test.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapper.test
{
    public class first : Profile
    {
        public first()
        {
            CreateMap< Source, Destination>();
            CreateMap< Destination, Source>();
        }
    }
}
