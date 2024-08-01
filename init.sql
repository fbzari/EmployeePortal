IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'employeeDB')
BEGIN
    CREATE DATABASE [employeeDB]
END
