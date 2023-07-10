using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PracticaWebServices.BussinesLogic.DAO.DAOEnrollment;
using PracticaWebServices.BussinesLogic.DAO.DAOFaculty;
using PracticaWebServices.BussinesLogic.DAO.DAOPerson;
using PracticaWebServices.BussinesLogic.DAO.DAOSchool;
using PracticaWebServices.BussinesLogic.DAO.DAOSection;
using PracticaWebServices.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddTransient<IFacultyDAO, FacultyDAO>();
builder.Services.AddTransient<IPersonDAO, PersonDAO>();
builder.Services.AddTransient<ISchoolDAO, SchoolDAO>();
builder.Services.AddTransient<ISectionDAO, SectionDAO>();
builder.Services.AddTransient<IEnrollmentDAO, EnrollmentDAO>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
