using gRPC.Demo.Server;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseEndpoints(x => x.MapGrpcService<PopulationService>());

app.Run();
