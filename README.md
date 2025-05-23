# Garbage Management System

## Overview
The **Garbage Management System** is a web application built using **ASP.NET MVC** that helps in managing waste collection efficiently. Users can input the **amount and type of waste**, and the system calculates the **price** accordingly. Additionally, the application generates a **PDF summary** of the collected waste using **Rotativa**, allowing users to download and maintain records.

## Features
- **Waste Collection Management**: Users can enter the type and quantity of waste collected.
- **Automated Pricing**: Calculates the price based on waste type and quantity.
- **PDF Generation**: Uses **Rotativa** to generate and download a PDF summary.
- **User-Friendly Interface**: Clean and easy-to-use UI for seamless experience.

## Tech Stack
- **Backend**: ASP.NET MVC
- **Frontend**: HTML, CSS, JavaScript
- **Database**: SQL Server
- **PDF Generation**: Rotativa
- **Version Control**: Git & GitHub

## Installation & Setup
### Prerequisites:
- Visual Studio
- .NET Framework
- SQL Server

### Steps:
1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/garbage-management.git
   ```
2. Open the project in Visual Studio.
3. Restore NuGet packages.
4. Set up the database in SQL Server.
5. Update the database connection string in appsettings.json.
6. Run the project in Visual Studio.

### Usage
- Enter the type and quantity of waste collected.
- The system calculates and displays the price.
- Generate and download a PDF summary of the collected waste.

### Future Enhancements
- User authentication system.
- Graphical analytics for waste trends.
- Multi-language support.

