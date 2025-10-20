using Microsoft.EntityFrameworkCore;
using Orders.Share.Entities;

namespace Orders.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();
        await CheckCountriesFullAsync();
        await CheckCountriesAsync();
        await CheckCategoriesAsync();
    }

    private async Task CheckCountriesFullAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Database.SetCommandTimeout(300); // Añadi esta linea ya que mi pc tarda mucho en cargar y arroja error timeout
            var countriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
    }

    private async Task CheckCategoriesAsync()
    {
        if (!_context.Categories.Any())
        {
            _context.Categories.Add(new Category { Name = "Apple" });
            _context.Categories.Add(new Category { Name = "Autos" });
            _context.Categories.Add(new Category { Name = "Belleza" });
            _context.Categories.Add(new Category { Name = "Calzado" });
            _context.Categories.Add(new Category { Name = "Comida" });
            _context.Categories.Add(new Category { Name = "Cosmeticos" });
            _context.Categories.Add(new Category { Name = "Deportes" });
            _context.Categories.Add(new Category { Name = "Erótica" });
            _context.Categories.Add(new Category { Name = "Ferreteria" });
            _context.Categories.Add(new Category { Name = "Gamer" });
            _context.Categories.Add(new Category { Name = "Hogar" });
            _context.Categories.Add(new Category { Name = "Jardín" });
            _context.Categories.Add(new Category { Name = "Jugetes" });
            _context.Categories.Add(new Category { Name = "Lenceria" });
            _context.Categories.Add(new Category { Name = "Mascotas" });
            _context.Categories.Add(new Category { Name = "Nutrición" });
            _context.Categories.Add(new Category { Name = "Ropa" });
            _context.Categories.Add(new Category { Name = "Tecnología" });
            await _context.SaveChangesAsync();
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country { Name = "Si ves esto el full async en seedDb no funciono como se espera" });
            _context.Countries.Add(new Country
            {
                Name = "Colombia",
                States = [
                    new State()
                    {
                        Name = "Antioquia",
                        Cities = [
                            new City() { Name = "Medellín" },
                            new City() { Name = "Itagüí" },
                            new City() { Name = "Envigado" },
                            new City() { Name = "Bello" },
                            new City() { Name = "Rionegro" },
                        ]
                    },
                    new State()
                    {
                        Name = "Bogotá",
                        Cities = [
                            new City() { Name = "Usaquen" },
                            new City() { Name = "Champinero" },
                            new City() { Name = "Santa fe" },
                            new City() { Name = "Useme" },
                            new City() { Name = "Bosa" },
                        ]
                    },
                ]
            });
            await _context.SaveChangesAsync();
        }
    }
}