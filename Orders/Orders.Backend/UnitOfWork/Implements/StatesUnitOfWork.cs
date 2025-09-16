using Orders.Backend.Repositories.Interfaces;
using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.UnitOfWork.Implements;

public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
{
    private readonly IStatesRepository _statesRepository;

    public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
    {
        _statesRepository = statesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination)
    {
        return await _statesRepository.GetAsync(pagination);
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        return await _statesRepository.GetTotalRecordsAsync(pagination);
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
    {
        return await _statesRepository.GetAsync();
    }

    public override async Task<ActionResponse<State>> GetAsync(int id)
    {
        return await _statesRepository.GetAsync(id);
    }
}