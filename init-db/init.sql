IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'salesdb')
BEGIN
    CREATE DATABASE salesdb;
END
GO

USE salesdb;
GO


CREATE TABLE customers (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    cpf CHAR(11) NOT NULL UNIQUE,
    registration_date DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE products (
    id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL
);

CREATE TABLE orders (
    id INT IDENTITY(1,1) PRIMARY KEY,
    customer_id INT NOT NULL,
    order_date DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (customer_id) REFERENCES customers(id)
);

CREATE TABLE order_items (
    id INT IDENTITY(1,1) PRIMARY KEY,
    order_id INT NOT NULL,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    unit_price DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (order_id) REFERENCES orders(id),
    FOREIGN KEY (product_id) REFERENCES products(id)
);
GO

INSERT INTO customers (name, cpf) VALUES
('John Doe', '11111111111'),
('Jane Smith', '22222222222'),
('Carlos Johnson', '33333333333'),
('Anna Brown', '44444444444'),
('Emily Davis', '55555555555');
GO

INSERT INTO products (name, unit_price) VALUES
('Laptop', 3500.00),
('Mouse', 80.00),
('Keyboard', 150.00),
('Monitor', 1200.00),
('Printer', 900.00);
GO

INSERT INTO orders (customer_id, order_date) VALUES
(1, GETDATE()),
(2, GETDATE()),
(3, GETDATE()),
(4, GETDATE()),
(5, GETDATE());
GO

INSERT INTO order_items (order_id, product_id, quantity, unit_price) VALUES
(1, 1, 1, 3500.00),
(2, 2, 2, 80.00),
(3, 3, 1, 150.00),
(4, 4, 2, 1200.00),
(5, 5, 1, 900.00);
GO
