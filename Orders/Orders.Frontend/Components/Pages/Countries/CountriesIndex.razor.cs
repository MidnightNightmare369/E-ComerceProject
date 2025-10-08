using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging.Abstractions;
using Orders.Frontend.Repositories;
using Orders.Share.Entities;

namespace Orders.Frontend.Components.Pages.Countries;

public partial class CountriesIndex
{
    [Inject] private IRepository Repository { get; set; } = null!;

    public List<Country>? countries;


    protected override async Task OnInitializedAsync()
    {
        var httpResult = await Repository.GetAsync<List<Country>>("/api/countries");
        countries = httpResult.Response;

    }

}