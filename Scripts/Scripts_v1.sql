CREATE DATABASE FloraliaBD;
GO

USE FloraliaBD;
GO

-- Tabela Produto
CREATE TABLE Produto (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID() NOT NULL,
    Nome VARCHAR(60) NULL,
    Descricao TEXT NULL,
    Foto VARCHAR(250) NULL,
    Preco DECIMAL(10,2) NULL
);
GO

-- Tabela Usuario
CREATE TABLE Usuario (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID() NOT NULL,
    Nome VARCHAR(100) NULL,
    Email VARCHAR(100) NULL,
    Senha VARCHAR(100) NULL,
    Foto VARCHAR(250) NULL --
);
GO

-- Tabela Encomenda
CREATE TABLE Encomenda (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID() NOT NULL,
    IdProduto uniqueidentifier,
    IdUsuario uniqueidentifier,
    StatusEncomanda VARCHAR(60),
    DataEncomenda DATE,
    FOREIGN KEY (IdProduto) REFERENCES Produto(ID),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(ID)
);
GO

-- Tabela Carrinho
CREATE TABLE Carrinho (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID() NOT NULL,
    IdProduto uniqueidentifier,
    IdUsuario uniqueidentifier,
    FOREIGN KEY (IdProduto) REFERENCES Produto(ID),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(ID)
);
GO

-- Tabela Favorito
CREATE TABLE Favorito (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID(),
    IdProduto uniqueidentifier,
    IdUsuario uniqueidentifier,
    FOREIGN KEY (IdProduto) REFERENCES Produto(ID),
    FOREIGN KEY (IdUsuario) REFERENCES Usuario(ID)
);
GO