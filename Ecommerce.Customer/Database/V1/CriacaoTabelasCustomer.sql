create table Cliente(
Id int identity(1,1) Not NULL Primary key,
Nome varchar(200) NOT Null,
Cpf varchar(11) NOT NULL,
Data_Nascimento datetime NOT NUll,
Telefone varchar(20) NOT NULL,
Email varchar(100) NOT null,
Senha varchar(100) NOT NULL,
Ativo varchar (50) not null,
Create_Date datetime NOT NULL,
Update_Date datetime NOT NULL)
GO

create table Endereco(
Id int identity(1,1)NOT NULL Primary key,
Rua varchar (200) Not NULL,
Numero varchar(20) NOT null,
Bairro varchar(200) not null,
Cidade varchar(200) not null,
Uf varchar(100) not null,
Cep varchar(8) not null,
Nome_Endereco varchar(200) not null,
Id_Cliente int NOT NULL,
Create_Date datetime NOT NULL,
Update_Date datetime NOT NULL) 

ALTER TABLE Endereco  WITH CHECK ADD CONSTRAINT FK_Endereco_Cliente FOREIGN KEY(Id_Cliente)
REFERENCES Cliente (id)
Go

insert into [dbo].[Cliente](Nome, Cpf, Data_Nascimento, Telefone, Email, Senha, Ativo, Create_date, Update_Date) 
values('Renata Cometti', '09820056799', '23/03/1984', '27999971902', 'renatacometti2@gmail.com', '19098119', 'Sim', GETDATE(), Getdate())