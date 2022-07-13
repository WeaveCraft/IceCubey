using IceCubey_Business.Repository;
using IceCubey_Business.Repository.IRepository;
using IceCubey_DataAccess.Data;
using IceCubey_Server.Service;
using IceCubey_Server.Service.IService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(); //When we request category repo in blazor server it will give us an obj of categoryrepo & its implementation.
builder.Services.AddScoped<IIncomeRepository, IncomeRepository>(); 
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>(); 
builder.Services.AddScoped<IFileUpload, FileUpload>(); 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
