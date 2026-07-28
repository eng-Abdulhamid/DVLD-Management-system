# 🚗 DVLD – Driver & Vehicle Licensing Department Management System

An enterprise-grade **Windows Desktop rchitecture** for clean separation between UI, business logic, and data access.

The system automates and enforces the full workflow of a driver licensing authority: citizen registration, license applications, multi-stage tests, license issuance, renewals, replacements, international permits, and detained license management.

---

## ✨ Key Features

* 👤 **People Identity Management**
* 🔐 **User Authentication & Security**
* 📝 **License Application Workflow**
* 👁️ **Vision, Written & Practical Tests**
* 📅 **Test Appointment Scheduling**
* 🚗 **Driver & License Lifecycle Management**
* 🌍 **International Driving Licenses**
* ♻️ **Renewal & Replacement Requests**
* 🚓 **Detained License Release Flow**
* 🔍 **Advanced Search & Filtering**
* 📷 **Profile Photo Support**
* 🧩 **Reusable Custom UserControls**

---

## 🏗 Architecture

```text
Presentation Layer (WinForms)
        │
Business Logic Layer (BLL)
        │
Data Access Layer (DAL)
        │
Microsoft SQL Server
```

---

## 🛠 Tech Stack

| Technology           | Purpose                       |
| -------------------- | ----------------------------- |
| C#                   | Core application language     |
| .NET Framework       | Desktop application framework |
| WinForms             | UI layer                      |
| ADO.NET              | Data access                   |
| Microsoft SQL Server | Database engine               |

---

## 📦 Project Structure

```text
DVLD/
DVLD_BLL/
DVLD_DAL/
Database/
docs/
README.md
```

---

## 🔑 Core Modules

<details>
<summary>👤 People & Identity</summary>

* Register citizens with national number, full name, date of birth, gender, address, contact data, nationality, and photo.
* Search and filter people records easily.
* Reusable person card control for selecting or viewing a person across the system.

</details>

<details>
<summary>🔐 Users & Security</summary>

* Role-based system users linked to people records.
* Secure password storage.
* Activate, deactivate, and manage accounts.

</details>

<details>
<summary>📝 Application Workflow</summary>

Supports:

* New local driving license
* Renew license
* Replace damaged license
* Replace lost license
* Release detained license
* Issue international driving license

</details>

<details>
<summary>🧪 Test Pipeline</summary>

* Vision test
* Written test
* Practical test
* Appointment locking after test submission
* Retake application handling after failure

</details>

<details>
<summary>🚗 License Management</summary>

* Driver creation
* License issuance
* License validity tracking
* Class-based rules and restrictions
* International permit validation

</details>

<details>
<summary>🚓 Detain & Release</summary>

* Detain licenses with custom fine amount
* Prevent renewal/replacement while detained
* Release after fine settlement

</details>

---

## 🗄 Database

* 14 normalized relational tables
* Primary and foreign keys
* Referential integrity
* SQL Server scripts included

ERD and database documentation are available inside the `docs/` folder.

---

## ⚙️ Installation

### Prerequisites

* Visual Studio 2019 / 2022
* Microsoft SQL Server 2017 or later
* SQL Server Management Studio

### Setup

```bash
git clone https://github.com/eng-Abdulhamid/DVLD-Management-system.git
cd DVLD-Management-system
```

1. Open `Database/DVLD_Database_Script.sql` in SSMS and execute it.
2. Open the solution in Visual Studio.
3. Update the connection string in `DVLD_DAL/clsDataAccessSettings.cs`.
4. Set `DVLD` as the startup project.
5. Build and run the solution.

### Default Login

```text
Username: Admin
Password: 1234
```

---

## 📸 Screenshots

Add screenshots here to make the README stronger and more professional.

Suggested images:

* Login screen
* People management screen
* Applications screen
* Test booking screen
* License details screen

---

## 💡 Design Goals

* Clear separation of concerns
* Reusable UI components
* Strong business rule enforcement
* Secure database access
* Maintainable and scalable codebase

---

## 📁 Documentation

* `docs/dvld_database_erd.png` — Database ERD
* `Database/DVLD_Database_Script.sql` — SQL setup script

---

## 👨‍💻 Author

**Eng. Abd-Ulhamid Abu-Saada**

Computer Systems Engineering Student

GitHub: **@eng-Abdulhamid**

---

## 📜 License

This project is open-source and released under the **MIT License**.
