# Tech Market MVC Project 

## Glimpse of the working solution
![Image](https://github.com/user-attachments/assets/d1a2f49d-abf3-4506-a18b-fa2451b05346)
![Image](https://github.com/user-attachments/assets/6a90067e-1530-4ded-a674-87c422c9f15d)
![Image](https://github.com/user-attachments/assets/baae665e-eeab-4f38-a94f-8bfce5a372c0)
![Image](https://github.com/user-attachments/assets/ede5fe74-0742-418e-b364-4e4dd3310982)
![Image](https://github.com/user-attachments/assets/1f8d1044-65d6-494e-800c-f0d4ce6acb65)
![Image](https://github.com/user-attachments/assets/972ef7c4-5d21-4079-a2cf-77e343849347)
![Image](https://github.com/user-attachments/assets/07bf7b1a-dce3-4dd2-9310-915c49a57815)
![Image](https://github.com/user-attachments/assets/6afac48e-0837-4bdf-aa72-deea8b690fd0)
![Image](https://github.com/user-attachments/assets/0fa811dd-37cd-4acb-9d24-53f42768235f)
![Image](https://github.com/user-attachments/assets/f645b50f-8dc5-4a97-a63a-788d92cdcb25)
![Image](https://github.com/user-attachments/assets/6b5ceacb-c2bb-43d4-a23f-68bd10d0ddd6)
![Image](https://github.com/user-attachments/assets/c6ae2dd9-82a2-4faf-ad1b-57917e1ba600)
![Image](https://github.com/user-attachments/assets/9068b7ad-320f-4685-9b77-64f0796d9b88)
![Image](https://github.com/user-attachments/assets/767d1522-2b46-4ddc-bf23-3887bafa2824)
![Image](https://github.com/user-attachments/assets/21d1702e-0018-449d-a0df-a1b8464cb4d4)
![Image](https://github.com/user-attachments/assets/64f9792d-4cfc-4c06-a94f-2d2b05887eac)
![Image](https://github.com/user-attachments/assets/8e470813-e5f9-403c-a215-b29c36a68ae1)
![Image](https://github.com/user-attachments/assets/9ea64dfc-1bce-4c2d-b9eb-a59ad85c4525)
![Image](https://github.com/user-attachments/assets/27697163-406a-4958-aecd-21b05d358324)


## Project Overview

**Objective:** This project incorporates various design patterns and best practices, including the Repository Pattern, Singleton Pattern. It leverages Entity Framework Core for database interactions and includes comprehensive user and role management using Microsoft ASP.NET Identity. Additionally, the project integrates a pre-built theme, utilizes JavaScript libraries like jQuery DataTables and Toaster JS, and implements a full-featured admin dashboard for managing the project.

## Key Features and Development Focus

### 1. [Repository Pattern](#repository-pattern)
- **Description:** Implement the Repository Pattern to abstract data access logic, making the code more testable and maintainable. 
- **Functionality:**
  - **Repository Pattern:** Simplifies data access by providing a consistent API for CRUD operations.
  - **Unit of Work:** Manages transactions across multiple repositories, ensuring data integrity.

### 2. [Singleton Pattern](#singleton-pattern)
- **Description:** Utilize the Singleton Pattern where appropriate to ensure a class has only one instance, providing a global point of access to it.
- **Usage:** This pattern is particularly useful for managing shared resources, such as configuration settings or logging services.

### 3. [Entity Framework Core](#entity-framework-core)
- **Description:** Handle database interactions using Entity Framework Core, allowing for seamless integration with the database. The use of code-first migrations ensures that the database schema is in sync with the application models.
- **Features:**
  - **Code-First Migrations:** Automatically generate database schema from your code.
  - **Entity Mapping:** Ensure proper mapping of domain entities to database tables.

### 4. [Theme Integration](#theme-integration)
- **Description:** Integrate a pre-built theme into the project. Customize the theme to match the project’s requirements, ensuring it works well with ASP.NET Core.
- **Customization:** Modify the theme to align with the branding and functional needs of the project, ensuring consistency across all pages.

### 5. [User and Role Management](#user-and-role-management)
- **Description:** Implement user and role management using Microsoft ASP.NET Identity. This includes functionalities for user registration, login, role assignment, and permissions management.

#### Admin Capabilities
- **Create, Update, Delete Products:** Manage the product inventory with full CRUD operations.
- **Manage Categories:** Add, edit, or remove product categories.
- **User Management:** Create users, assign roles, lock or unlock users, and delete users as needed.
- **Role Assignment:** Define and assign roles such as Admin, Editor, and Customer, with specific permissions.

#### Auth Section
- **Login:** Secure user authentication.
- **Register:** Allow new users to create accounts.
- **Reset Password:** Provide password recovery options.
- **Edit Profile:** Enable users to update their personal information and settings.

### 7. [JavaScript Libraries](#javascript-libraries)
- **Description:** Utilize JavaScript libraries to enhance the user interface and provide dynamic functionality.
- **Libraries:**
  - **jQuery DataTables:** For dynamic tables with features like sorting, searching, and pagination.
  - **Toaster JS:** For displaying user-friendly notifications throughout the application.

### 8. [Admin Dashboard](#admin-dashboard)
- **Description:** Develop an admin dashboard that allows system administrators to manage the project effectively.
- **Features:**
  - **User Management:** View, create, update, and delete users.
  - **Role Management:** Assign and manage user roles.
  - **Product Management:** Oversee product listings, including adding, editing, and deleting products.
  - **Order Management:** Track and manage customer orders and their statuses.

### 9. [Pagination](#pagination)
- **Description:** Implement pagination to manage large sets of products across multiple pages, ensuring a user-friendly experience.
- **Functionality:** Pagination will be integrated with search and filter functionalities to allow users to easily navigate through products.

### 10. [Session Management](#session-management)
- **Description:** Manage user sessions effectively, ensuring data is maintained across user interactions with the site.
- **Session Features:** 
  - Maintain user state across different pages.
  - Secure sensitive session data.

### 11. [Online Payments with Stripe](#online-payments-with-stripe)
- **Description:** Enable online payments using the Stripe payment gateway. Implement secure payment processing, handling payment confirmations and errors gracefully.

#### Customer Capabilities
- **Create Order:** Customers can place orders for products.
- **Make Payments:** Securely process payments using Stripe, with support for various payment methods.

### 13. [Data Seeding](#data-seeding)
- **Description:** Seed initial data for the admin role and users to ensure the system starts with essential data, improving ease of testing and initial use.
- **Seeded Data:**
  - **Admin Role:** Pre-configured admin role with full access.
  - **Sample Users:** Initial users with different roles for testing purposes.

---

## Links
- **Video Demo:** https://2u.pw/s8yfvMwH
- **Live Demo:** [https://bookhaven.runasp.net](https://techmarket.runasp.net)
- **Email:** Email: MoAdmin@TechMarket.Com
- **Password:** P@$$0Rd123
