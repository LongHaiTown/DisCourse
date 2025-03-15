# Course & Discussion Platform Application

## Introduction
This application is a course and discussion platform built using C# with WinForms, featuring a modern and interactive interface through Guna2 UI. The platform emphasizes a reading/writing-based learning approach, enabling users to create and explore courses, publish articles, and engage in thoughtful discussions.

## Features
- Create, edit, and manage courses
- Write and publish articles
- Facilitate and moderate user discussions
- Modern user interface powered by Guna2 UI
- Data interaction through ADO.NET

## Installation

### Requirements
- .NET Framework 4.6 or later
- Visual Studio
- [Guna2 UI](https://www.nuget.org/packages/Guna.UI2.WinForms/) (available via NuGet)
- SQL Server (LocalDB or a full version)

### Setup Instructions
1. **Clone the repository**:
   ```bash
   https://github.com/LongHaiTown/DisCourse.git
2. **Database Installation:**
- Locate the `.bacpac` file in the Database directory.
- Import the `.bacpac` file using SQL Server Management Studio (SSMS):
  1. Open SSMS and connect to the SQL Server instance.
  2. Right-click on "Databases" and select "Import Data-tier Application".
  3. Follow the prompts to import the .bacpac file.
3.  **Open the Project:**
- Open the project using Visual Studio.
- Install necessary packages via NuGet:
  - Guna2 UI: `Install-Package Guna.UI2.WinForms`
4. **Database Connection**:
- The application uses ADO.NET for data access. After importing, update the database connection string in `app.config` to match your SQL Server instance and database name.
5. **Build and Run**:
- Build and run the project through Visual Studio.
 
### User Roles and Permissions
The application features three main user roles with distinct permissions:
1. Learner (Học viên)
Learners are the primary users who interact with the content by viewing and engaging with courses and articles.
2. NhanVien (Staff)
Staff members or content creators responsible for managing and publishing content.
3. Admin (Quản trị viên)
Admins have full control and access across the platform.

### Screenshots
Below are some screenshots showcasing the application's interface and main features:
#### Main Interfaces
![CoursesPage](https://github.com/user-attachments/assets/a051968a-daeb-4466-9ab9-3fe754ce37b9)
![PostsPage](https://github.com/user-attachments/assets/cb6a7759-8bf5-455c-8cb8-cabb66b3b339)
#### Personal Page
![PersonalPage](https://github.com/user-attachments/assets/014416e3-0828-4e0c-83be-1e2da9b3a4fa)
#### Management Page
![CourseManagement](https://github.com/user-attachments/assets/23e7f300-f4e3-41ae-b461-24219ec3b597)

### Contributing
I am very honored if you have any contributions to improve this program:
1. Fork this repository.
2. Create a new branch (`git checkout -b feature/feature-name`).
3. Commit your changes (`git commit -m 'Add feature X'`).
4. Push to the branch (`git push origin feature/feature-name`).
5. Open a Pull Request.
  
### Author
- Thân Huỳnh
- Email address: [hthan401@gmail.com]


### Thank you sincerely for your interest and for reading this far!
