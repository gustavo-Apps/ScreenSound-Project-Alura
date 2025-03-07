using Microsoft.AspNetCore.Mvc;
using ScreenSound.api.Endpoints;
using ScreenSound.Bancos;
using ScreenSound.Modelos;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();


var app = builder.Build();

app.AddEndpointsArtistas();
app.AddEndpointsMusicas();


app.Run();
