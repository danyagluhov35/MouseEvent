using System;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IMouseMovementService, MouseMovementService>();
builder.Services.AddControllersWithViews();


var app = builder.Build();
app.UseStaticFiles();
app.UseDefaultFiles();
app.MapControllerRoute
    (
        name : "default",
        pattern : "{Controller=MouseMovement}/{action=Index}/{id?}"
    );


app.Run();
