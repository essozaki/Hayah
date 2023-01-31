using EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pharmacy_Project.Api.Services.BLL;
using Pharmacy_Project.Api.Services;
using Pharmacy_Project.Bll;
using Pharmacy_Project.Data;
using Pharmacy_Project.Extend;
using Pharmacy_Project.Data.Entities;
using Pharmacy_Project.Api.Bll;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Pharmacy_DbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection"));
});

builder.Services.AddSingleton(builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Pharmacy_DbContext>().AddDefaultTokenProviders();


builder.Services.AddEndpointsApiExplorer();

//start Add Transient
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IClientRep, ClientRep>();
builder.Services.AddTransient<IAreasRep, AreasRep>();
builder.Services.AddTransient<ICitiesRep, CitiesRep>();
builder.Services.AddTransient<ITerms_ConditionsRep, Terms_ConditionsRep>();
builder.Services.AddTransient<IQuestionsRep, QuestionsRep>();
builder.Services.AddTransient<IContactUsRep, ContactUsRep>();
builder.Services.AddTransient<IComplainsRep, ComplainsRep>();
builder.Services.AddTransient<IMedical_InformationRep, Medical_InformationRep>();
builder.Services.AddTransient<IClincsRep, ClincsRep>();
builder.Services.AddTransient<IAnalysisLapsRep, AnalysisLapsRep>();
builder.Services.AddTransient<IHospitalsRep, HospitalsRep>();
builder.Services.AddTransient<IMedicalCentresRep, MedicalCentresRep>();
builder.Services.AddTransient<IXraysRep, XraysRep>();
builder.Services.AddTransient<IHomeSliderRep, HomeSliderRep>();

builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IComplainsApiRep, ComplainsApiRep>();
builder.Services.AddScoped<IClincsApiRep, ClincsApiRep>();
builder.Services.AddScoped<IQuestionsApiRep, QuestionsApiRep>();
builder.Services.AddScoped<ITerms_ConditionsApiRep, Terms_ConditionsApiRep>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
