create table venta (
	idventa integer primary key identity(1,1),
	idcliente integer not null,
	idusuario integer not null,
	tipo_comprobante VARCHAR(20) not null,
	serie_comprobante VARCHAR(7) not null,
	num_comprobante VARCHAR(10) not null,
	fecha_hora DATETIME not null,
	impuesto DECIMAL (4,2) not null,
	total DECIMAL(11,2) not null,
	estado VARCHAR(20) not null,
	FOREIGN KEY(idcliente) REFERENCES persona(idpersona),
	FOREIGN KEY(idusuario) REFERENCES usuario(idusuario)
);
create table detalle_venta(
	iddetalle_venta integer primary key identity(1,1),
	idventa integer not null,
	idarticulo integer not  null,
	cantidad integer not null,
	precio DECIMAL (11,2) not null,
	descuento DECIMAL (11,2) not null,
	FOREIGN KEY (idventa) REFERENCES venta (idventa) on delete cascade,
	FOREIGN KEY (idarticulo) REFERENCES articulo(idarticulo)
);