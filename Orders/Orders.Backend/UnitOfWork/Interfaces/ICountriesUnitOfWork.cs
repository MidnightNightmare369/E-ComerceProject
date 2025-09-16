using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.UnitOfWork.Interfaces;

public interface ICountriesUnitOfWork
{
    Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}