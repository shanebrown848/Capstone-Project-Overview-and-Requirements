-- database.sql
-- Create Users table (for demonstration; ASP.NET Identity creates its own tables)
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    PasswordHash VARCHAR(255) NOT NULL,
    Phone VARCHAR(20),
    CreatedAt DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- Note: In a production ASP.NET Identity system, the Identity tables (AspNetUsers, AspNetRoles, etc.) are auto-generated.
