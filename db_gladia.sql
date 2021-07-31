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
	address_cep varchar(8) not null,
    address_uf enum('RO','AC','AM','RR','PA','AP','TO','MA','PI','CE','RN','PB','PE','AL','SE','BA','MG','ES','RJ','SP','PR','SC','RS','MS','MT','GO','DF') not null,
    address_city varchar(80) not null,
    address_district varchar(80) not null,
    address_public_place varchar(120) not null, /*logradouro*/
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
    order_date timestamp not null,
    order_payment enum("picpay","paypal") not null,
    order_subtotal varchar(25) not null,
    order_total varchar(25) not null,
    fk_id_user int not null
);

create table if not exists tbl_items_order(
	fk_id_order int,
    fk_id_prod int,
    items_quant int not null,
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
