CREATE DATABASE InventarioDB;
GO

USE InventarioDB;
GO

CREATE TABLE Categoria (
    IdCategoria INT IDENTITY(1,1) PRIMARY KEY,
    Nombre      NVARCHAR(50) NOT NULL
);

CREATE TABLE Producto (
    IdProducto  INT IDENTITY(1,1) PRIMARY KEY,
    Codigo      NVARCHAR(20)  NOT NULL UNIQUE,
    Nombre      NVARCHAR(100) NOT NULL,
    Precio      DECIMAL(10,2) NOT NULL,
    Stock       INT           NOT NULL,
    IdCategoria INT           NOT NULL,
    CONSTRAINT FK_Producto_Categoria
        FOREIGN KEY (IdCategoria) REFERENCES Categoria(IdCategoria)
);
GO

INSERT INTO Categoria (Nombre) VALUES
('Bebidas'), ('Snacks'), ('Limpieza'), ('Papelería'), ('Lácteos');

INSERT INTO Producto (Codigo, Nombre, Precio, Stock, IdCategoria) VALUES
('P001', 'Agua 500ml',       25.00, 120, 1),
('P002', 'Jugo de naranja',  60.00,  40, 1),
('P003', 'Papitas',          35.00,   4, 2),
('P004', 'Galletas',         30.00,   3, 2),
('P005', 'Detergente 1L',   150.00,  15, 3),
('P006', 'Cuaderno',         45.00,   2, 4),
('P007', 'Leche 1L',         75.00,  30, 5);
GO