-- drop database if exists db_asp; 
create database if not exists db_asp;
use db_asp;

@@ -44,19 +43,29 @@ use db_asp;
 create table if not exists tbl_order(
	order_id int primary key auto_increment,
    order_date timestamp not null,
    order_payment enum("PicPay") not null,
    order_subtotal varchar(25) not null,
    order_total varchar(25) not null,
    fk_id_user int not null
);

create table if not exists tbl_items_order(
	fk_id_order int auto_increment,
    fk_id_prod int,
    items_quant int not null,
    primary key(fk_id_order,fk_id_prod)
);

 create view img 
 as SELECT REPLACE(user_img, "~/", "../"),user_id from tbl_user;

 create view Allproduct 
 as SELECT prod_id,prod_name,prod_desc,prod_brand,prod_price,prod_quant,prod_min_quant,fk_category,category_id,category_name,
 REPLACE(prod_img, "~/", "../") as img
 FROM db_asp.tbl_product 
 join tbl_category
 on tbl_product.fk_category = tbl_category.category_id;

ALTER TABLE tbl_product
ADD FOREIGN KEY (fk_category) REFERENCES tbl_category (category_id);

@@ -72,63 +81,5 @@ ADD FOREIGN KEY (fk_id_order) REFERENCES tbl_order(order_id);
ALTER TABLE tbl_items_order
ADD FOREIGN KEY (fk_id_prod) REFERENCES tbl_product(prod_id);

Create temporary table if not exists tbl_cart 
select o.fk_id_user, i.fk_id_prod, p.prod_name, p.prod_price, p.prod_img, i.items_quant, o.order_subtotal, o.order_total
from tbl_order as o 
join tbl_items_order as i 
on o.order_id = i.fk_id_order
join tbl_product as p 
on p.prod_id = i.fk_id_prod;

create view img 
as SELECT REPLACE(user_img, "~/", "../"),user_id from tbl_user;

create view Allproduct 
as SELECT prod_id,prod_name,prod_desc,prod_brand,prod_price,prod_quant,prod_min_quant,fk_category,category_id,category_name,
REPLACE(prod_img, "~/", "../") as img
FROM db_asp.tbl_product 
join tbl_category
on tbl_product.fk_category = tbl_category.category_id;

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

call inserirDados();

CREATE USER 'gladia'@'localhost' IDENTIFIED BY '123456';
GRANT ALL PRIVILEGES ON db_asp.* TO 'gladia'@'localhost' WITH GRANT OPTION;

/*SEEDS*/
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('22286781801', '994635598', 'Rafael Ioshi', 'rafa.ioshi@gmail.com', 'rafael00', '1');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Comida');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Brinquedos');
INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `fk_category`) VALUES ('Ração Golden Power Training', 'Indicada para cães adultos', 'Golden', '164,99', '10', '1');
INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_min_quant`, `fk_category`) VALUES ('Brinquedo Macaco Dom', 'Indicado para cães', 'Dom', '39,99', '5', '1', '2');
INSERT INTO `db_asp`.`tbl_address` (`address_cep`, `address_uf`, `address_city`, `address_district`, `address_public_place`, `address_complement`, `fk_user_id`) VALUES ('06020194', 'SP', 'Osasco', 'Parque Continental', 'Av Manoel Pedro Pimentel 200', 'Bl 15 Ap 81', '1');
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('23151315121', '994564511', 'Vitor Vieira', 'vitor@gmail.com', 'vitor00', '0');