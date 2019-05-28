using AutoMapper;
using AutoMapper.test.Dto;
using AutoMapper.test.Entity;
using demo.CustomtypeConverters;
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

            //Reverse（反向）映射
            CreateMap<Reverse, ReverseDto>().
                ForMember(dto=>dto.CustomerName, r=>r.MapFrom(op=>op.customer.Name)).
                ReverseMap().
                ForPath(r=>r.customer.Name,dto=>dto.MapFrom(op=>op.CustomerName));

            //Projection（投影）映射
            CreateMap<CalendarEvent, CalendarEventForm>().
                ForMember(o => o.EventDate, opt => opt.MapFrom(src => src.Date.Date)).
                ForMember(o => o.EventHour, opt => opt.MapFrom(src => src.Date.Hour)).
                ForMember(o => o.EventMinute, opt => opt.MapFrom(src => src.Date.Minute));

            //自定义映射器
            CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
            CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter().Convert);
            CreateMap<string, Type>().ConvertUsing(new TypeTypeConverter().Convert);
            CreateMap<Source, Destination>();

            //空替换
            CreateMap<nullreplace, nullreplaceDTO>().
                ForMember(dto=>dto.str,source=> { source.NullSubstitute("这个为空"); });

        }
    }
}
