using Orders.Backend.Repositories.Interfaces;
using Orders.Backend.UnitOfWork.Interfaces;
using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.UnitOfWork.Implements;

public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
{
    private readonly ICitiesRepository _citiesRepository;

    public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
    {
        _citiesRepository = citiesRepository;
    }

    public async Task<IEnumerable<City>> GetComboAsync(int stateId) => await _citiesRepository.GetComboAsync(stateId);

    public override Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => _citiesRepository.GetAsync(pagination);

    public override Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => _citiesRepository.GetTotalRecordsAsync(pagination);
}