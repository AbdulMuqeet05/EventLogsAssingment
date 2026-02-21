using EventStore.Extension;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddEventLogService(builder.Configuration);
var  AngularApp = "_AngularApp";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AngularApp, policy =>
    {
        policy.WithOrigins("http://localhost:4200");
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(AngularApp);
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();