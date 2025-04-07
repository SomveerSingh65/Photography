using Microsoft.EntityFrameworkCore;
using Photography.Databases;
using Photography.Services.Abstract;
using Photography.Services.Concate;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("Default_Connections")));
builder.Services.AddScoped<IBookingServices, BookingServices>();
builder.Services.AddScoped<IMediaServies, MediaServices>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Booking}/{action=Index}/{id?}");

app.Run();
