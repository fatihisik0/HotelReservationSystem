# 🏨 Hotel Reservation System 

A robust and modern **Windows Forms Application** developed in C# to manage hotel rooms, customers, and reservations.
This project demonstrates **Object-Oriented Programming (OOP)** principles such as Classes, Encapsulation, Polymorphism, and Collections.

## Features 

* **Room Types:** Selectable room categories (Standard, Deluxe, Suite, King Suite) via dynamic dropdown menu.
* **Customer Management:** Records full guest details including **Name, Phone Number, and Unique Customer ID/TC**.
* **Smart Validation:** Prevents adding duplicate Room Numbers or Customer IDs to ensure data integrity.
* **Conflict Detection:** Advanced algorithm to check if a room is available for selected dates (prevents double booking).
* **Modern UI:** User-friendly interface with grouped sections, intuitive controls, and color-coded feedback.

## Technologies & Concepts 

* **Language:** C#
* **Framework:** .NET Framework (Windows Forms)
* **IDE:** Visual Studio 2022
* **OOP Concepts:**
    * **Classes & Objects:** (`Room`, `Customer`, `Reservation`)
    * **Encapsulation:** (Properties with `get; set;`)
    * **Collections:** (`ListBox`, `List<T>`, `foreach` loops)
    * **Input Validation:** (Try-Catch blocks, logical constraints)

## How It Works 

1.  **Add Room:** Enter a Room Number, select a **Room Type** (e.g., Suite), and enter Price.
2.  **Add Customer:** Register a guest by entering their **Customer Name, Phone Number, and ID/TC Number**. The system ensures the ID is unique.
3.  **Check Availability:** Select Check-in/Check-out dates and a room to see if it's free.
4.  **Make Reservation:** If available, create the booking. The system automatically links the selected Room and Customer.

---
*Developed by Fatih Işık*
