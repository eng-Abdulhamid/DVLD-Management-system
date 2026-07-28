# DVLD Management System

A Desktop Application for managing a Driver and Vehicle Licensing Department (DVLD) system.

The project is built using **C# .NET Windows Forms** and follows a **3-Tier Architecture** to achieve better separation of concerns, maintainability, and scalability.

## Project Overview

DVLD Management System helps manage different operations inside a driving license department, including people management, drivers, licenses, applications, and related administrative processes.

The application provides a structured way to handle data entry, searching, updating records, and performing business operations through a user-friendly desktop interface.

## Architecture

The project is organized into multiple layers:

### Presentation Layer (PL)

Responsible for the graphical user interface and user interaction.

* Windows Forms UI
* Forms and user controls
* Handling user input and displaying results

### Business Logic Layer (BLL)

Contains the application's business rules and logic.

Responsibilities:

* Validating data
* Managing application workflows
* Communicating between the presentation layer and data layer

### Data Access Layer (DAL)

Responsible for database communication.

Responsibilities:

* Executing SQL queries
* Retrieving and updating data
* Managing database operations

### Custom Controls

A reusable controls library used to improve UI consistency and reduce code duplication.

## Technologies Used

* C#
* .NET Framework
* Windows Forms
* SQL Server
* ADO.NET
* Object-Oriented Programming (OOP)
* 3-Tier Architecture

## Main Features

* People Management

  * Add, update, delete, and search people records

* Driver Management

  * Manage driver information and history

* License Management

  * Issue and manage different types of driving licenses

* Applications Management

  * Handle driving license applications and their statuses

* Search System

  * Fast searching and filtering for records

* User Management

  * Manage system users and permissions

## Database Design

The system uses a relational database designed to store and manage:

* People information
* Drivers
* Users
* Licenses
* Applications
* Vehicle and licensing-related data

## Project Structure

```
DVLD-Management-System
│
├── PL              # Presentation Layer
├── BLL             # Business Logic Layer
├── DAL             # Data Access Layer
├── CustomControls  # Reusable UI Controls
│
└── README.md
```

## Installation

1. Clone the repository:

```bash
git clone https://github.com/eng-Abdulhamid/DVLD-Management-system.git
```

2. Open the project using Visual Studio.

3. Configure the SQL Server database connection.

4. Run the application.

## Learning Objectives

This project demonstrates practical experience with:

* Designing multi-layer applications
* Applying Object-Oriented Programming principles
* Working with databases using ADO.NET
* Building desktop applications using C#
* Separating business logic from presentation and data access

## Author

Abd-Ulhamid Abu-Saada
Computer Systems Engineering Student
