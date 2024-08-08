using MSGarnet_server;

var builder = WebApplication.CreateBuilder(args);

Task.Run(() =>
{
    var server = new Garnet.GarnetServer(new string[] { "--config-import-path", "garnet.conf"});
    server.Start();
    Thread.Sleep(Timeout.Infinite);
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGarnetClient, GarnetClient>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
