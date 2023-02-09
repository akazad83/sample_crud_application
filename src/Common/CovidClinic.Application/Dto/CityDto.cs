using System.Collections.Generic;
using CovidClinic.Domain.Entities;
using Mapster;

namespace CovidClinic.Application.Dto
{
    public class CityDto : IRegister 
    {
        public CityDto() { }

        public int Id { get; set; }

        public int Rank { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }

        public string CreateDate { get; set; }

        public bool Active { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<City, CityDto>()
            .Map(dest => dest.CreateDate,
                src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}
