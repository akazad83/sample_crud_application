using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CovidClinic.Application.Common.Interfaces;
using CovidClinic.Application.Common.Models;
using CovidClinic.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace CovidClinic.Application.Cities.Queries.GetCityById
{
    public class GetCityByIdQuery : IRequestWrapper<CityDto>
    {
        public int CityId { get; set; }
    }

    public class GetCityByIdQueryHandler : IRequestHandlerWrapper<GetCityByIdQuery, CityDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCityByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CityDto>> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
        {
            var city = await _context.Cities
                .Where(x => x.Id == request.CityId)
                .ProjectToType<CityDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return city != null ? ServiceResult.Success(city) : ServiceResult.Failed<CityDto>(ServiceError.NotFound);
        }
    }
}
