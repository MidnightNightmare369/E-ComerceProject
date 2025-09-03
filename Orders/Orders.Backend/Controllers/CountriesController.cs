using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Share.Entities;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly DataContext _context;

    CountriesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(int id)
    {
        var country = await  _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        if(country == null)
        {
            return NotFound();
        }

        return Ok(country);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        return Ok(country);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var country =  await _context.Countries.FirstOrDefaultAsync(x => x.Id == id);
        if (country == null)
        {
            return NotFound();
        }
        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();

        return Ok(country);
    }

    [HttpPut]
    public async Task<IActionResult> PutAsync(Country country)
    {
        _context.Countries.Update(country);
        await _context.SaveChangesAsync();
        return Ok(country);
    }



}
