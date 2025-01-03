-- Criação do Banco de Dados
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Observability')
BEGIN
    CREATE DATABASE Observability;
END
GO

-- Usando o Banco de Dados
USE Observability;
GO

-- Criação da Tabela Fornecedors
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Fornecedors' AND xtype='U')
BEGIN
    CREATE TABLE Fornecedors (
        Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        Nome NVARCHAR(MAX) NOT NULL
    );
END;
GO

-- Criação da Tabela Produtos
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Produtos' AND xtype='U')
BEGIN
    CREATE TABLE Produtos (
        Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
        Nome NVARCHAR(MAX) NOT NULL,
        Descricao NVARCHAR(MAX) NOT NULL,
        Valor FLOAT NOT NULL,
        FornecedorId UNIQUEIDENTIFIER NOT NULL,
        CONSTRAINT FK_Produtos_Fornecedors FOREIGN KEY (FornecedorId)
        REFERENCES Fornecedors (Id) ON DELETE CASCADE
    );
    CREATE INDEX IX_Produtos_FornecedorId ON Produtos (FornecedorId);
END;
GO
