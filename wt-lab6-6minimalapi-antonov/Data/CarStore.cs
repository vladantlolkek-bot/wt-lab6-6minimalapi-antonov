using wt_lab6_6minimalapi_antonov.Models;

namespace wt_lab6_6minimalapi_antonov.Data;

public static class CarStore
{
    public static List<Car> Cars { get; } = new()
    {
        new Car { Id = 1, Brand = "Toyota", Model = "Camry", Year = 2021, PricePerDay = 4500, IsAvailable = true },
        new Car { Id = 2, Brand = "BMW", Model = "X5", Year = 2020, PricePerDay = 8000, IsAvailable = true },
        new Car { Id = 3, Brand = "Kia", Model = "Rio", Year = 2019, PricePerDay = 2500, IsAvailable = false },
        new Car { Id = 4, Brand = "Audi", Model = "A6", Year = 2022, PricePerDay = 6000, IsAvailable = true },
        new Car { Id = 5, Brand = "Ford", Model = "Focus", Year = 2018, PricePerDay = 3000, IsAvailable = true }
    };
}