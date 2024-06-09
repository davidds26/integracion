CREATE TABLE PrecioOferta (
	  PrecioOfertaId int NOT NUll IDENTITY,
	  NuevoPrecio numeric(7,2) NOT NULL,
	  TextoPromocional nvarchar(120) NOT NULL,
	  ProductoId int NOT NULL 
	);

    ALTER TABLE PrecioOferta
	ADD CONSTRAINT PK_PrecioOferta PRIMARY KEY (PrecioOfertaId);

	ALTER TABLE PrecioOferta
	ADD CONSTRAINT UC_PrecioOferta_ProductoId UNIQUE (ProductoId);

	ALTER TABLE PrecioOferta
	ADD CONSTRAINT Fk_PrecioOferta_Producto_ProductoId FOREIGN KEY (ProductoId)
	REFERENCES Producto (ProductoId) ON DELETE CASCADE;

INSERT INTO PrecioOferta(NuevoPrecio, TextoPromocional, ProductoId)
VALUES (1500,'Oferta del Mes',1);
