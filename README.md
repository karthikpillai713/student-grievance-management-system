# Student Grievance Management System

A role-based Grievance Management System built with ASP.NET Core MVC, Entity Framework Core, and SQL Server.

## Overview

This application allows students to submit grievances and track their status. Teachers can review, solve, or forward grievances, and principals can make final decisions such as resolving or rejecting them.

## Features

- Student registration and login
- Session-based authentication and authorization
- Role-based access control (Student, Teacher, Principal)
- Grievance submission with category selection
- Students can view only their own grievances
- Teachers can review, solve, or forward grievances
- Principals can review, resolve, or reject grievances
- SQL Server database integration
- Entity Framework Core migrations

## Technologies and Frameworks Used

- ASP.NET Core MVC (.NET 8)
- C#
- Microsoft SQL Server
- Entity Framework Core (ORM)
- HTML5
- CSS3
- Bootstrap 5
- Razor View Engine (.cshtml)
- Session-Based Authentication & Authorization
- MVC (Model–View–Controller) Architecture
- Visual Studio 2022
- SQL Server Management Studio (SSMS)

## User Roles

### Student
- Register and log in
- Submit grievances
- View personal grievance history and status

### Teacher
- View submitted grievances
- Mark grievances as Solved
- Forward grievances to the Principal

### Principal
- View forwarded grievances
- Mark grievances as Under Review
- Resolve or Reject grievances

## Workflow

1. Student registers and logs in.
2. Student submits a grievance under a selected category.
3. Teacher reviews the grievance and either solves it or forwards it.
4. Principal reviews forwarded grievances and makes the final decision.
5. Student tracks the grievance status in the My Grievances page.

## Database Tables

### Users
Stores user account information and roles.

### Categories
Stores grievance categories such as Academic, Hostel, Fees, and Transport.

### Grievances
Stores complaint details, status, and relationships to users and categories.

## Setup Instructions

1. Clone the repository.
2. Open the solution in Visual Studio 2022.
3. Update the connection string in `appsettings.json` if necessary.
4. Open Package Manager Console and run:
   ```powershell
   Update-Database
   ```
5. Press F5 to build and run the application.

## Sample Login Credentials

Create accounts through the application or insert test accounts into the `Users` table.

- Student: student@example.com / 123
- Teacher: teacher@example.com / 123
- Principal: principal@example.com / 123

## Future Enhancements

- ASP.NET Core Identity integration
- Password hashing
- Email notifications
- File attachments for grievances
- Admin dashboard
- Deployment to Azure or IIS

## Author

Karthik Pillai
