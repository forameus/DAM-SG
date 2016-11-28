use Almacen

go

create table Productos(
	idProducto int  IDENTITY (1,1) not null constraint PK_Productos primary key,
	idCategoria int not null,
	nombreProducto varchar(50),
	constraint FK_Productos foreign key (idCategoria) references categorias(idCategoria)
)

go