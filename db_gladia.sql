drop database if exists db_asp; 
create database if not exists db_asp;
use db_asp;

 Create table if not exists tbl_address(
	address_id int primary key auto_increment,
	address_cep varchar(8),
    address_uf enum('RO','AC','AM','RR','PA','AP','TO','MA','PI','CE','RN','PB','PE','AL','SE','BA','MG','ES','RJ','SP','PR','SC','RS','MS','MT','GO','DF'),
    address_city varchar(80),
    address_district varchar(80),
    address_public_place varchar(120), /*logradouro*/
    address_complement varchar(80)
 );

INSERT INTO `db_asp`.`tbl_address` (`address_id`, `address_cep`, `address_uf`, `address_city`, `address_district`, `address_public_place`, `address_complement`) VALUES ('1', '06020194', 'SP', 'Osasco', 'São Paulo', 'Av Manoel Pedro Pimentel', 'Bl 15 Ap 81');

 Create Table if not exists tbl_user (
    user_id int primary key auto_increment ,
    user_cpf varchar(11) not null,
    user_phone varchar(11) not null,
    user_name varchar(80) not null,
    user_email varchar(80) not null,
    user_password varchar(80) not null,
    user_img varchar(255),
    fk_address int DEFAULT '1',
    user_lvl varchar(2) not null
 );
 
 Create table if not exists tbl_category(
	category_id int primary key auto_increment,  
    category_name varchar(50)
 );
 
 Create Table if not exists tbl_product (
    prod_id int primary key auto_increment ,
    prod_name varchar(80) Not null,
    prod_desc text Not null,
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
    order_status varchar(2) not null,/*0 = open and 1 = closed*/
    fk_id_user int not null
);

create table if not exists tbl_items_order(
	fk_id_order int,
    fk_id_prod int,
    items_quant int not null,
    item_subtotal int,
    primary key(fk_id_order,fk_id_prod)
);

ALTER TABLE tbl_user
ADD FOREIGN KEY (fk_address) REFERENCES tbl_address(address_id);

ALTER TABLE tbl_product
ADD FOREIGN KEY (fk_category) REFERENCES tbl_category (category_id);

ALTER TABLE tbl_order
ADD FOREIGN KEY (fk_id_user) REFERENCES tbl_user(user_id);

ALTER TABLE tbl_items_order
ADD FOREIGN KEY (fk_id_order) REFERENCES tbl_order(order_id);

ALTER TABLE tbl_items_order
ADD FOREIGN KEY (fk_id_prod) REFERENCES tbl_product(prod_id);

create view img 
as SELECT REPLACE(user_img, "~/", "../"),user_id from tbl_user;
 
create view Allproduct 
as SELECT prod_id,prod_name,prod_desc,prod_brand,prod_price,prod_quant,prod_min_quant,fk_category,category_id,category_name,
REPLACE(prod_img, "~/", "../") as img
FROM db_asp.tbl_product 
join tbl_category
on tbl_product.fk_category = tbl_category.category_id;

create view trackOrder as SELECT  o.order_id, o.order_date, o.order_payment,o.order_total, p.prod_name, p.prod_price, p.prod_desc, REPLACE(prod_img, "~/", "../") as prod_img, i.items_quant
FROM db_asp.tbl_order as o
JOIN tbl_items_order as i
ON o.order_id = i.fk_id_order
JOIN tbl_product as p
ON p.prod_id = i.fk_id_prod;

INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('22286781801', '994635598', 'Rafael Ioshi', 'rafa.ioshi@gmail.com', 'rafael00', '1');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Comida');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Brinquedos');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Higiene');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Medicamentos');
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('23151315121', '994564511', 'Vitor Vieira', 'vitor@gmail.com', 'vitor00', '0');
INSERT INTO `db_asp`.`tbl_user` (`user_id`, `user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES ('3', '23151315121', '994564511', 'Ioshi ', 'ioshi@gmail.com', 'ioshi00', '~/Images/58371762-5fbd-4163-bcef-6e21e24bb1fd_01.png', '1');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ( 'Higiene');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('1', 'Tapete Higiênico Petix Supersecão Max Citrus 30 Unidades', '- Indicado para cães;', 'Supersecão ', '68', '30', '~/Images/48412d34-a350-43af-be07-080621f64931_1.png', '5', '3');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('2', 'Snack Dom Tchochoro para Cães sabor Filé de Carne Bovino 100g', '- Indicado para cães;', 'Dom Tchochoro', '22', '30', '~/Images/d7610363-5e48-4fb5-92ee-47de63b495bc_12.png', '5', '1');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('3', 'Poste Arranhador Dom Tchochoro para Gatos - Cores Sortidas', '- Indicado para gatos;', 'Dom Tchochoro', '90', '2', '~/Images/d740d6e9-72bc-4c90-9a0a-fc4240b7703b_7.png', '0', '2');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('4', 'Antipulgas e Carrapatos Bravecto MSD para Cães de 4,5 a 10 kg', '- Indicado para cães;', 'Bravecto', '193', '5', '~/Images/f3b53a29-4adc-4003-b686-749dc665026d_16.png', '2', '4');
