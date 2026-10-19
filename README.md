.NET 10 Web API - Students CRUDThis repository contains a RESTful API built with .NET 10 and Entity Framework Core, connected to a SQL Server instance to perform complete CRUD operations on the Student entity.🚀 Technologies UsedPlatform: .NET 10 (C#)Web Framework: ASP.NET Core Web APIORM: Entity Framework CoreDatabase: Microsoft SQL ServerAPI Testing Tools: Postman / cURL🛠️ Setup & Installation1. Prerequisites.NET 10 SDK installed.SQL Server running locally (Default instance MSSQLSERVER or SQLEXPRESS).API testing tool (Postman, Thunder Client, Swagger, etc.).2. Connection String ConfigurationEnsure the connection string in your appsettings.json points to your local SQL Server instance:{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StudentsDB;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
3. Migrations and Database UpdateOpen the Package Manager Console in Visual Studio and run the following commands to generate the database schema and tables:add-migration InitialSetupDB
update-database
📂 Project StructureModel (Models/Student.cs)using System.ComponentModel.DataAnnotations;

namespace WebAPISolution.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50)]
        public string Surname { get; set; }
    }
}
Database Context (Contexts/ApplicationDBContext.cs)using Microsoft.EntityFrameworkCore;
using WebAPISolution.Models;

namespace WebAPISolution.Contexts
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
📡 API EndpointsBase Controller Route: https://localhost:<port>/api/studentsMethodEndpointDescriptionRequest BodyGET/api/studentsRetrieves all students.N/AGET/api/students/{id}Retrieves a single student by ID.N/APOST/api/studentsCreates a new student.JSON with name and surnamePUT/api/students/{id}Updates an existing student by ID.Full JSON with studentId, name, and surnameDELETE/api/students/{id}Deletes a student by ID.N/A📝 Example Requests in PostmanCreate Student (POST /api/students)URL: https://localhost:44356/api/studentsHeader: Content-Type: application/jsonBody (raw / JSON):{
  "name": "Esteban",
  "surname": "Pastor"
}
Response: 201 CreatedUpdate Student (PUT /api/students/{id})URL: https://localhost:44356/api/students/1Header: Content-Type: application/jsonBody (raw / JSON):{
  "studentId": 1,
  "name": "Esteban",
  "surname": "Pastor"
}
⚠️ Important: The studentId in the URL route must match the studentId provided in the JSON body.Response: 204 No Content
