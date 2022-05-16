use AtividadesDB
go
create table [dbo].Atividades(
[Id] [int] identity(1,1) not null,
[Atividade] [nvarchar](255),
[Status] [nvarchar](100),
)
go