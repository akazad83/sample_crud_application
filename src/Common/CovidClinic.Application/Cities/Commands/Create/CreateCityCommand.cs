using System.Threading;
using System.Threading.Tasks;
using CovidClinic.Application.Common.Interfaces;
using CovidClinic.Application.Common.Models;
using CovidClinic.Application.Dto;
using CovidClinic.Domain.Entities;
using CovidClinic.Domain.Event;
using MapsterMapper;

namespace CovidClinic.Application.Cities.Commands.Create
{
    public record CreateCityCommand(string Name) : IRequestWrapper<CityDto>;

    public class CreateCityCommandHandler : IRequestHandlerWrapper<CreateCityCommand, CityDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = new City
            {
                Name = request.Name
            };

            entity.DomainEvents.Add(new CityCreatedEvent(entity));

            await _context.Cities.AddAsync(entity, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CityDto>(entity));
        }
    }
}
