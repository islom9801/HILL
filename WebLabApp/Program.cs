using WebLabApp.Controllers;
using WebLabApp.Models;
using Microsoft.EntityFrameworkCore;
using WebLabApp.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IWForecastRepository, WForecastRepository>();
builder.Services.AddControllers();
builder.Services.AddHostedService<BackgroundWorkerService>();

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews(); //������� ���������� MVC, ������� ��������� ������������ ����������� � ������������� � ��������� ����������������. 

var app = builder.Build();
app.UseHttpsRedirection(); // �������������
app.UseStaticFiles(); // ����������� ����������� ������ wwwroot
app.UseRouting(); // ��������� ������������� ��������
app.UseAuthorization(); // ��������� �����������

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainPage}/{action=Index}/{id?}");

app.Run();
