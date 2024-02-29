using Tenisu.Players;

var builder = WebApplication.CreateBuilder();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PlayersEndPoints.AddPlayersEndPoints(app);

app.Run();