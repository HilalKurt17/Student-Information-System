using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data.Abstract;
using StudentInformationSystem.Data.Concrete.EfCore;


var builder = WebApplication.CreateBuilder(args);

// add MVC services
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<SISContext>(options =>
    options.UseSqlite
    (builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);
builder.Services.AddScoped<IStudentRepository, EfCoreStudentRepository>();
builder.Services.AddScoped<ITeacherRepository, EfCoreTeacherRepository>();
builder.Services.AddScoped<ILessonRepository, EfCoreLessonRepository>();
builder.Services.AddScoped<IAddressRepository, EfCoreAddressRepository>();
builder.Services.AddScoped<IAssignmentRepository, EfCoreAssignmentRepository>();
builder.Services.AddScoped<IPaymentDetailsRepository, EfCorePaymentDetailsRepository>();
builder.Services.AddScoped<IReferencesRepository, EfCoreReferencesRepository>();
builder.Services.AddScoped<IWorkExperienceRepository, EfCoreWorkExperienceRepository>();


var app = builder.Build();

// add required middlewares to run the MVC
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// MVC (routing)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
