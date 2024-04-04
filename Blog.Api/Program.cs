using Blog.Application;
using Blog.Infrastructure;
using Blog.Infrastructure.data.postgres;
using Blog.Infrastructure.data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Npgsql;


var builder = WebApplication.CreateBuilder(args);
{
    var conn = builder.Configuration.GetConnectionString("CleanArchitecture");

    // Postgres database
    builder.Services.AddDbContext<AppDbContext>(option => option.UseNpgsql(conn));

    // SQLite database
    builder.Services.AddDbContext<CustomerDbContext>(options => options.UseSqlite(@"Data Source=customer.db"));

    builder.Services.AddApplication().AddInfrastructure();
    builder.Services.AddControllers();
}

{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>();
    dbContext.Database.EnsureCreated();

    app.UseSwagger();
    app.UseSwaggerUI();
}

{
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

