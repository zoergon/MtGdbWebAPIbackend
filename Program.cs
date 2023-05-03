using Microsoft.EntityFrameworkCore;
using MtGdbWebAPIbackend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Nämä lisätty
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy",
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

// ---------------- Connection string luetaan appsettings.json tiedostosta -------------
// jos olisi useampi yhteys > "paikallinen" > "muuksi"

builder.Services.AddDbContext<MtGdbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("paikallinen")
    ));

// Non-nullable kentät, jotka aiheuttavat ongelmia POST/PUT-metodeissa, joilla ei pitäisi olla käytännön merkitystä varsinaiseen POST/PUT:iin
// -> Voidaan kiertää tällä.
builder.Services.AddControllers(
    options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthorization();

//tämä lisätty
app.UseCors("MyCorsPolicy");

 app.MapControllers();

app.Run();
