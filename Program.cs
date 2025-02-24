using Free_Course_For_Student.Repository.Interface;
using Free_Course_For_Student.Repository.Repository;
using EXE_PROJECT.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ MVC
builder.Services.AddControllersWithViews();

// Thêm Session
builder.Services.AddSession();

// Đăng ký DbContext vào DI container
builder.Services.AddDbContext<ElearningContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký Repository (DI)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IUserCourseRepository, UserCourseRepository>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();


// Không cần SqlConnection riêng, vì DbContext đã quản lý kết nối
// builder.Services.AddTransient<SqlConnection>(_ =>
//     new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware xử lý lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Cấu hình Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession(); // Sử dụng session
app.UseAuthorization();

// Cấu hình route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
