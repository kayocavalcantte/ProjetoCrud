use EstudosCrud

create table Produtos(
id int identity(1,1) not null,
nome varchar(100) not null,
descricao varchar(100),
primary key(id)
);

select *from Produtos;

insert into Produtos(nome, descricao)
values('TESTE', 'ESSE É UM TESTE');