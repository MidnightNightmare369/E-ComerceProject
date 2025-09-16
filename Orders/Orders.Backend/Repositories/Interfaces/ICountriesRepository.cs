using Orders.Share.DTOs;
using Orders.Share.Entities;
using Orders.Share.Responses;

namespace Orders.Backend.Repositories.Interfaces;

public interface ICountriesRepository
{
    Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<Country>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Country>>> GetAsync();
}