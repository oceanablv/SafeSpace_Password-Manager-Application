# SafeSpace: Employee & Password Management System

## Dashboard (Admin)
<img width="441" height="306" alt="image" src="https://github.com/user-attachments/assets/009ef037-cf98-426d-b78a-b6543bd89a56" />

## Dashboard (User)
<img width="428" height="278" alt="image" src="https://github.com/user-attachments/assets/4b3830e5-b08a-409a-afa3-7ba804ee7a3c" />

Welcome to the repository for SafeSpace, a comprehensive desktop application developed as a final project for my Visual Programming course. SafeSpace is a centralized system designed to manage employee data and secure password credentials within a corporate environment, featuring a robust dual-role system for administrators and standard users.

---

## ✨ Core Features

SafeSpace is built with a focus on security and administrative control, offering distinct functionalities for different user roles.

### Administrator Features:
- **Comprehensive User Management:** Full CRUD (Create, Read, Update, Delete) capabilities for both employee profiles and other admin accounts.
- **Centralized Password Control:** Manage all external service credentials (e.g., company social media, SaaS tools) on behalf of employees.
- **Secure Password Generation:** A built-in tool to generate strong, random passwords for new accounts or password resets.
- **Data Exporting:** Ability to generate reports and export data directly to Excel for auditing and analysis.

### User (Employee) Features:
- **Personal Password Manager:** A secure space for employees to store and manage their own external account credentials for work-related services.
- **Self-Service Account Management:** Users can securely log in and manage their own application password.

---

## 🛠️ Technology Stack

This application was developed using the Microsoft .NET Framework and a relational database.

- **Language:** Visual Basic .NET (VB.NET)
- **Framework:** Windows Forms (.NET Framework)
- **Database:** MySQL
- **Key Concepts Implemented:**
  - Object-Oriented Programming (OOP)
  - CRUD Operations (Create, Read, Update, Delete)
  - Database Transaction Management for Data Integrity
  - Custom Event Handling for User Interface Interactions
  - Relational Database Design with Foreign Keys

---

## 🔧 System Architecture

The application is designed around a relational database (`employee_db`) that serves as the single source of truth for all data.

- **`employee` table:** The master table containing core information for all employees.
- **`admin` & `appuser` tables:** Store specific login credentials for administrators and standard users, linked to the `employee` table.
- **`accountpassword` table:** The central table for the password manager feature, storing encrypted credentials for external services, linked to each employee.

The system's logic is detailed in the included ERD (Entity Relationship Diagram) and DFDs (Data Flow Diagrams).

---

## 🚀 Getting Started

To set up and run this project locally, you will need:

1.  **Visual Studio:** An IDE that supports .NET Framework development (e.g., Visual Studio 2019 or later).
2.  **MySQL Server:** A local or remote MySQL database server.
3.  **.NET Framework:** Ensure you have the required version of the .NET Framework installed.

### Installation Steps:

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/oceanablv/SafeSpace_Password-Manager-Application.git
    ```
2.  **Set up the database:**
    - Create a new database named `employee_db`.
    - Execute the SQL scripts found in the `/database` folder to create the required tables (`employee`, `admin`, `appuser`, `accountpassword`).
3.  **Configure the connection string:**
    - Open the project in Visual Studio.
    - Navigate to the `Dashboard.vb` file (or the central configuration module).
    - Update the `ConnStr` constant with your local MySQL server credentials:
      ```vb
      Private Const ConnStr As String = "server=localhost; user id=your_user;password=your_password; database=employee_db"
      ```
4.  **Build and run the project:**
    - Build the solution in Visual Studio (F6).
    - Run the application (F5) to launch the login screen.
