CREATE DATABASE Floralia_BD;
GO

USE Floralia_BD;
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
    Foto VARCHAR(250) NULL,
	CodRecupSenha Int Null --
);
GO

-- Tabela Pedido
CREATE TABLE Pedido (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID() NOT NULL,
    StatusPedido VARCHAR(60),
    DataPedido DATE
);
GO

---- Tabela Carrinho
--CREATE TABLE Carrinho (
--    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID() NOT NULL,
--    IdUsuario uniqueidentifier,
--	StatusEncomenda VARCHAR(60),
--    FOREIGN KEY (IdUsuario) REFERENCES Usuario(ID)
--);
--GO

-- Tabela ProdutoPedido
CREATE TABLE Carrinho (
    ID uniqueidentifier PRIMARY KEY DEFAULT NEWID() NOT NULL,
    IdProduto uniqueidentifier,
    IdPedido uniqueidentifier,
    FOREIGN KEY (IdProduto) REFERENCES Produto(ID),
    FOREIGN KEY (IdPedido) REFERENCES Pedido(ID)
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