using Microsoft.AspNetCore.Mvc;
using ScreenSound.api.Endpoints;
using ScreenSound.Bancos;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configure JSON options to ignore reference cycles
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Add DbContext and DAL services
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();

// Add API explorer and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add endpoints for Artistas and Musicas
app.AddEndpointsArtistas();
app.AddEndpointsMusicas();

// Use Swagger for API documentation
app.UseSwagger();
app.UseSwaggerUI();

app.Run();