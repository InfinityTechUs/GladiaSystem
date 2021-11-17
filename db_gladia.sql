drop database if exists db_asp; 
create database if not exists db_asp;
use db_asp;

 Create Table if not exists tbl_user (
    user_id int primary key auto_increment ,
    user_cpf varchar(11) not null,
    user_phone varchar(11) not null,
    user_name varchar(80) not null,
    user_email varchar(80) not null,
    user_password varchar(80) not null,
    user_img varchar(255),
    user_lvl varchar(2) not null
 );
 
 Create table if not exists tbl_address(
	address_id int primary key auto_increment,
	address_cep varchar(8),
    address_uf enum('RO','AC','AM','RR','PA','AP','TO','MA','PI','CE','RN','PB','PE','AL','SE','BA','MG','ES','RJ','SP','PR','SC','RS','MS','MT','GO','DF'),
    address_city varchar(80),
    address_district varchar(80),
    address_public_place varchar(120), /*logradouro*/
    address_complement varchar(80),
    fk_user_id int not null
 );
 
 Create table if not exists tbl_category(
	category_id int primary key auto_increment,  
    category_name varchar(50)
 );
 
 Create Table if not exists tbl_product (
    prod_id int primary key auto_increment ,
    prod_name varchar(80) Not null,
    prod_desc varchar(200) Not null,
    prod_brand varchar(80) Not null,
    prod_price varchar(255) Not null,
    prod_quant int not null,
	prod_img varchar(255),
    prod_min_quant int,
    fk_category int
 );
 
 create table if not exists tbl_order(
	order_id int primary key auto_increment,
    order_date varchar(255),
    order_payment enum("PicPay"),
    order_total varchar(25),
    order_status varchar(2) not null,
    fk_id_user int not null
);

create table if not exists tbl_items_order(
	fk_id_order int,
    fk_id_prod int,
    items_quant int not null,
    item_subtotal int,
    primary key(fk_id_order,fk_id_prod)
);

ALTER TABLE tbl_product
ADD FOREIGN KEY (fk_category) REFERENCES tbl_category (category_id);

ALTER TABLE tbl_address
ADD FOREIGN KEY (fk_user_id) REFERENCES tbl_user(user_id);

ALTER TABLE tbl_order
ADD FOREIGN KEY (fk_id_user) REFERENCES tbl_user(user_id);

ALTER TABLE tbl_items_order
ADD FOREIGN KEY (fk_id_order) REFERENCES tbl_order(order_id);

ALTER TABLE tbl_items_order
ADD FOREIGN KEY (fk_id_prod) REFERENCES tbl_product(prod_id);

/*Create temporary table if not exists tbl_cart 
select o.fk_id_user, i.fk_id_prod, p.prod_name, p.prod_price, p.prod_img, i.items_quant, o.order_subtotal, o.order_total
from tbl_order as o 
join tbl_items_order as i 
on o.order_id = i.fk_id_order
join tbl_product as p 
on p.prod_id = i.fk_id_prod;*/

create view img 
as SELECT REPLACE(user_img, "~/", "../"),user_id from tbl_user;
 
create view Allproduct 
as SELECT prod_id,prod_name,prod_desc,prod_brand,prod_price,prod_quant,prod_min_quant,fk_category,category_id,category_name,
REPLACE(prod_img, "~/", "../") as img
FROM db_asp.tbl_product 
join tbl_category
on tbl_product.fk_category = tbl_category.category_id;

/*CREATE USER 'gladia'@'localhost' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON db_asp.* TO 'gladia'@'localhost' WITH GRANT OPTION;

set @@autocommit = off;
delimiter $$
create procedure inserirDados()
begin
	declare erro tinyint default false;
	declare continue handler for sqlexception set erro = true;
    start transaction;
		insert into tbl_order(order_total, fk_id_user)
		select order_total, fk_id_user
		from tbl_cart;

		insert into tbl_items_order(items_quant, fk_id_prod)
		select items_quant, fk_id_prod
		from tbl_cart;
		
		insert into tbl_product(prod_name, prod_price, prod_img)
		select prod_name, prod_price, prod_img 
		from tbl_cart;
		
		if erro = false then
			commit;
			select 'ta safe' as resultado;
		else 
			rollback;
			select 'não ta safe' as resultado;
		end if;
end$$
DELIMITER ;
call inserirDados();*/ 

INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('22286781801', '994635598', 'Rafael Ioshi', 'rafa.ioshi@gmail.com', 'rafael00', '1');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Comida');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Brinquedos');
INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_min_quant`, `fk_category`) VALUES ('Brinquedo Macaco Dom', 'Indicado para cães', 'Dom', '39', '5', '1', '2');
INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_min_quant`, `fk_category`) VALUES ('Brinquedo Fodase', 'fodase para cães', 'foda', '49', '15', '1', '2');
INSERT INTO `db_asp`.`tbl_address` (`address_cep`, `address_uf`, `address_city`, `address_district`, `address_public_place`, `address_complement`, `fk_user_id`) VALUES ('06020194', 'SP', 'Osasco', 'Parque Continental', 'Av Manoel Pedro Pimentel 200', 'Bl 15 Ap 81', '1');
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('23151315121', '994564511', 'Vitor Vieira', 'vitor@gmail.com', 'vitor00', '0');
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('23151315121', '994564511', 'Ioshi ', 'ioshi@gmail.com', 'ioshi00', '1');