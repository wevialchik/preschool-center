using Microsoft.EntityFrameworkCore;
using nз3.Data;
using nз3.Services;
using nз3.Repositories; // <--- 1. ВАЖНО: Добавьте это

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Регистрируем Repository Pattern
// Это позволяет использовать IRepository<Child>, IRepository<Course> и т.д.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// 3. Регистрируем Бизнес-сервисы
builder.Services.AddScoped<IDataService, DataService>();

// 4. Добавляем Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// 5. Применяем миграции и заполняем БД (Seed) при запуске
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    
    // Применяем миграции (создает БД если нет)
    await db.Database.MigrateAsync();
    
    // Заполняем тестовыми данными (если БД пустая)
    await DbSeeder.SeedAsync(db);
}

// 6. Настройка Middleware (Обработка ошибок, статика, маршрутизация)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();