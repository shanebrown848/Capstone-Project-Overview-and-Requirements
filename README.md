# SafeVault Security Project

## Overview
SafeVault is a secure web application designed to manage sensitive data such as user credentials and financial records. This project demonstrates best practices in secure coding, including input validation, SQL injection prevention, secure authentication, and role-based access control (RBAC).

## Features
- **User Registration:**  
  - HTML5 form with client-side validation.
  - Fields include username, name, email, password, confirm password, and phone number.
  
- **Input Validation & SQL Injection Prevention:**  
  - C# `ValidationHelpers` class validates inputs.
  - Secure database queries using parameterized queries.
  
- **Authentication & Authorization:**  
  - Secure login with hashed passwords.
  - Integration with ASP.NET Identity for managing roles and claims.
  - Role-based access control to restrict access to sensitive endpoints.
  
- **Vulnerability Testing:**  
  - NUnit tests simulating SQL injection and XSS attacks.
  - Code fixes to address vulnerabilities.
  
- **Use of Microsoft Copilot:**  
  - Assisted in generating secure code and debugging security issues.


