using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderReceiver.Common.Models;

namespace OrderReceiver
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Domain <--> Database
            CreateMap<Common.Models.Domain.Order, Common.Models.Database.Order>().ReverseMap();

            //View <--> Domain
            CreateMap<Common.Models.View.Order, Common.Models.Domain.Order>().ReverseMap();
        }
    }
}
