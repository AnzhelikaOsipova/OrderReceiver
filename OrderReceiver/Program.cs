using NLog.Extensions.Logging;
using OrderReceiver;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddNLog("NLog.config");

// Add services to the container.
builder.Services.AddRazorPages();
DI.Setup(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
