using wt_lab6_6minimalapi_antonov.Data;
using wt_lab6_6minimalapi_antonov.Models;

var builder = WebApplication.CreateBuilder(args);

// --- Блок 6: Настройка Swagger для .NET 8 ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Включаем Swagger (чтобы он работал и локально, и на Render)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars API V1");
    // Если хочешь, чтобы Swagger открывался на главной странице "/", раскомментируй строку ниже:
    // c.RoutePrefix = string.Empty; 
});

// --- БЛОК 1: Базовые эндпоинты ---
app.MapGet("/", () => "Minimal API работает!");

app.MapGet("/api/info", () => {
    return new
    {
        Application = "Web Technologies",
        Technology = "ASP.NET Core Minimal API",
        Version = "1.0"
    };
});

// --- БЛОК 3: GET-запросы ---
// 3.1. Получить все автомобили
app.MapGet("/api/cars", () => {
    return Results.Ok(CarStore.Cars);
});

// 3.2. Получить по ID
app.MapGet("/api/cars/{id}", (int id) => {
    var car = CarStore.Cars.FirstOrDefault(x => x.Id == id);
    if (car == null) return Results.NotFound();
    return Results.Ok(car);
});

// 3.3. Фильтрация по марке (query-параметр)
app.MapGet("/api/cars/search", (string? search) => {
    var cars = CarStore.Cars.AsEnumerable();
    if (!string.IsNullOrWhiteSpace(search))
    {
        cars = cars.Where(x => x.Brand.Contains(search, StringComparison.OrdinalIgnoreCase));
    }
    return Results.Ok(cars);
});

// --- БЛОК 4: POST-запрос (Создание) ---
app.MapPost("/api/cars", (Car car) => {
    // Автогенерация ID
    car.Id = CarStore.Cars.Count == 0 ? 1 : CarStore.Cars.Max(x => x.Id) + 1;
    CarStore.Cars.Add(car);

    // Возвращаем 201 Created
    return Results.Created($"/api/cars/{car.Id}", car);
});

// --- БЛОК 5: PUT (Обновление) и DELETE (Удаление) ---
// PUT: Изменить
app.MapPut("/api/cars/{id}", (int id, Car updatedCar) => {
    var car = CarStore.Cars.FirstOrDefault(x => x.Id == id);
    if (car == null) return Results.NotFound();

    car.Brand = updatedCar.Brand;
    car.Model = updatedCar.Model;
    car.Year = updatedCar.Year;
    car.PricePerDay = updatedCar.PricePerDay;
    car.IsAvailable = updatedCar.IsAvailable;

    return Results.Ok(car);
});

// DELETE: Удалить
app.MapDelete("/api/cars/{id}", (int id) => {
    var car = CarStore.Cars.FirstOrDefault(x => x.Id == id);
    if (car == null) return Results.NotFound();

    CarStore.Cars.Remove(car);
    return Results.NoContent(); // 204 No Content
});

// --- БЛОК 7: Правильный запуск (локально и на Render) ---
if (app.Environment.IsDevelopment())
{
    // Локально Visual Studio сама выберет порт (например, 7018 или 7123)
    app.Run();
}
else
{
    // На Render приложение будет слушать порт 10000
    var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
    app.Run($"http://0.0.0.0:{port}");
}