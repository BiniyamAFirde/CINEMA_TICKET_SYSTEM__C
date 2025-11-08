# Cinema Ticket Booking System

A web-based cinema ticket reservation system built with ASP.NET Core MVC, enabling users to browse screenings, reserve seats in real-time, and manage bookings with full administrative controls.

## Badges

![.NET](https://img.shields.io/badge/.NET-9.0.306-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat-square&logo=.net&logoColor=white)
![Azure SQL](https://img.shields.io/badge/Azure%20SQL-Database-0078D4?style=flat-square&logo=microsoftazure&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

## Visuals

---

## Features

**Users:** Register/login, browse screenings, view seat maps, reserve/cancel seats  
**Admins:** Create/delete screenings, manage users and cinema data  

## Installation

### Requirements
- .NET 9.0 SDK (version 9.0.306)
- Microsoft Azure Account (for Azure SQL Database)
- Visual Studio 2022 (recommended) or VS Code with Azure extensions
- Azure SQL Database instance (or SQL Server for local development)

### Quick Setup
```bash
# Clone repository
git clone https://gitlab-stud.elka.pw.edu.pl/25z-egui/mvc/25Z-EGUI-MVC-Firde-Yonatan.git
cd cinema-ticket-system

# Restore packages and update database
dotnet restore
dotnet ef database update

# Run application
dotnet run
# Access at: https://localhost:7001
```

### Database Configuration
Edit `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CinemaTicketDB;Trusted_Connection=True"
}
```

**Default Admin:** admin@cinema.com / Admin@123

## Usage

### For Users
1. **Register:** Navigate to registration page → Fill in email, password, name, and phone → Submit
2. **Browse Screenings:** Click "Screenings" → View available movies
3. **Show Booking History:** Go to "My Bookings"

### For Administrators
1. **Login:** Use admin credentials to access admin panel
2. **Create Screening:** Admin Panel → "Create Screening" → Select cinema, enter film title and date/time → Submit
3. **Delete Screening:** Admin Panel → "Screenings" → Click "Delete" (removes all associated reservations)

## Support

**Get Help:**
- Email: yonatanawlachew1@gmail.com

**Common Issues:**
- **Azure SQL connection fails:** Verify firewall rules in Azure Portal allow current IP address
- **Migration errors:** Delete database and run `dotnet ef database update` 
- **Port already in use:** Change port in `Properties/launchSettings.json`

## Roadmap
---

## Authors and Acknowledgment

**Developer:** Yonatan Firde  
**Institution:** Warsaw University of Technology  
**Course:** Graphical User Interface  
**Academic Year:** 2025-2026

**Acknowledgments:**
- Microsoft ASP.NET Core Team for the MVC framework
- Microsoft Azure Team for cloud database services
- Bootstrap Team for UI components
- Course Instructor: Professor Waldemar Grabski for guidance and requirements

## License

**MIT License**

Copyright (c) 2025 Yonatan Firde
