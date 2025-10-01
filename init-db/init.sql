IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'salesdb')
BEGIN
    CREATE DATABASE salesdb;
END
GO

USE salesdb;
GO

IF OBJECT_ID('order_items', 'U') IS NOT NULL DROP TABLE order_items;
IF OBJECT_ID('orders', 'U') IS NOT NULL DROP TABLE orders;
IF OBJECT_ID('customers', 'U') IS NOT NULL DROP TABLE customers;
IF OBJECT_ID('products', 'U') IS NOT NULL DROP TABLE products;
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



IF OBJECT_ID('sp_report_orders_per_customer', 'P') IS NOT NULL
DROP PROCEDURE sp_report_orders_per_customer;
CREATE PROCEDURE sp_report_orders_per_customer
    @customer_id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.name AS customer,
        o.order_date AS order_date,
        p.name AS product,
        oi.quantity AS quantity,
        (oi.quantity * oi.unit_price) AS total_item
    FROM customers c
    JOIN orders o       ON o.customer_id = c.id
    JOIN order_items oi ON oi.order_id = o.id
    JOIN products p     ON p.id = oi.product_id
    WHERE c.id = @customer_id
    ORDER BY o.order_date, p.name;
END;
GO


IF OBJECT_ID('sp_top_selling_products', 'P') IS NOT NULL
DROP PROCEDURE sp_top_selling_products;
CREATE PROCEDURE sp_top_selling_products
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        p.id AS id,
        p.name AS product,
        SUM(oi.quantity) AS total_sold
    FROM order_items oi
    JOIN products p ON p.id = oi.product_id
    GROUP BY p.id, p.name
    ORDER BY total_sold DESC;
END;
GO


IF OBJECT_ID('sp_high_value_customers', 'P') IS NOT NULL
DROP PROCEDURE sp_high_value_customers;
CREATE OR ALTER PROCEDURE sp_high_value_customers
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        c.id AS id,
        c.name AS customer,
        SUM(oi.quantity * oi.unit_price) AS total_spent
    FROM customers c
    JOIN orders o       ON o.customer_id = c.id
    JOIN order_items oi ON oi.order_id = o.id
    GROUP BY c.id, c.name
    HAVING SUM(oi.quantity * oi.unit_price) > 1000
    ORDER BY total_spent DESC;
END;
GO

IF OBJECT_ID('sp_get_all_customers', 'P') IS NOT NULL
DROP PROCEDURE sp_get_all_customers;
CREATE PROCEDURE sp_get_all_customers
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        id,
        name,
        cpf,
        registration_date
    FROM customers
    ORDER BY name;
END;
GO