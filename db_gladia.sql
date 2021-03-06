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
    fk_address int,
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
    prod_name varchar(100) Not null,
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
    fk_id_user int not null,
    order_shipping varchar(255)
);


create table if not exists tbl_items_order(
	fk_id_order int,
    fk_id_prod int,
    items_quant int not null,
    item_subtotal varchar(255),
    primary key(fk_id_order,fk_id_prod)
);

ALTER TABLE tbl_user
ADD FOREIGN KEY (fk_address) REFERENCES tbl_address(address_id);

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

INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Comida');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Brinquedos');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Higiene');
INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES ('Medicamentos');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('2', 'Tapete Higi??nico Petix Supersec??o Max Citrus 30 Unidades', '- Indicado para embalagens com 30 unidades.', 'Supersec??o ', '67,92', '50', '~/Images/db1f9071-dfed-46ff-8c9e-ab960d8d042a_1.png', '9', '3');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('3', 'Areia Pipicat para Gatos Carv??o Ativado 4kg', '- Indicada para gatos;- Dispon??vel em embalagens com 4 kg.', 'Pipicat ', '55,5', '50', '~/Images/eef5df5d-d62e-4054-ac8f-1dcd7c9dd5cc_2.png', '9', '3');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('4', 'Arranhador Divert Cat Torre Cilindro Cinza', '- Indicado para gatos; - Mant??m seu pet entretido e livre de estresse; - Estimula o exerc??cio; - Feito com material at??xico;- Evita que o gato arranhe m??veis;', 'Divert Cat', '459,99', '50', '~/Images/a4e2629a-6fdf-4a9c-94b8-243af4bf0af6_3.png', '10', '2');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('5', 'Arranhador de Papel??o para Gatos - Furac??o Pet', '- Indicada para gatos;- Ideal para suprir a necessidade de arranhar do seu felino;-Garante horas de divers??o e relaxamento,', 'Furac??o Pet', '51,99', '50', '~/Images/66a61554-6b27-4931-a78a-2ca736e4fd4e_4.png', '10', '2');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('6', 'Arranhador Divert Cat para Gatos 2 Plataformas Casa Gato Marrom e Bege', '- Indicado para gatos;- Mant??m seu pet entretido e livre de estresse;- Estimula o exerc??cio;- Feito com material at??xico;- Evita que o gato arranhe m??veis;- Dispon??vel na cor marrom com bege.', 'Divert Cat', '399,99', '50', '~/Images/0c1e8558-5c75-4cf4-922d-89f3a9b87e34_5.png', '10', '2');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('7', 'Arranhador de Rampa Furac??o Pet para gatos', '- Indicado para gatos- Previne o estrago de m??veis e utens??lios de sua casa; - Exercita a musculatura, a percep????o visual e t??tica do gato,- Cont??m: 01 Arranhador duplo e 02 Bolinhas pl??sticas.', ' Furac??o Pet', '59,49', '50', '~/Images/1e0d6ce9-eba9-4e38-9eda-68daef05fd22_6.png', '10', '2');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('8', 'Poste Arranhador Dom Tchochoro para Gatos - Cores Sortidas', '- Indicado para gatos;- Madeira de excelente qualidade;- Encapado com pel??cia;- Sisal e uma corda com uma bolinha para uma melhor distra????o e divertimento do seu pet;', 'Dom Tchochoro ', '89,99', '50', '~/Images/e91dda2f-b3a5-476f-be7a-b6ce2c0a6fc5_7.png', '10', '2');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('9', 'Petisco KelDog C??es Adultos Tekinhos - 500g', '- Indicado para c??es adultos;- Aroma que atrai os pets; - Perfeito para adestramentos e para agradar seu melhor amigo; - Dispon??vel em embalagem com 500g.', 'KelDog ', '22,02', '50', '~/Images/75bc9919-63a6-4482-87ee-08a8bd3b4521_8.png', '10', '1');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('10', 'Bifinho Dom Tchochoro Strip Churrasco para C??es', '- Indicado para c??es;- Felicidade em forma de bifinhos;- Para todo o pet que merece agrado e recompensa;- A Petz, em parceria com um especialista em nutri????o animal, desenvolveu esses bifinhos;- Feitos com recortes especiais de angus, prebi??ticos e ze??lita;- ??timo para a flora intestinal;- Aproveite este momento para fortalecer o carinho com seu pet, seu melhor amigo merece;- Dispon??vel em embalagens de 60g, 500g e 1kg.', 'Dom Tchochoro', '3,49', '50', '~/Images/3785c5b1-773d-4b0e-83cf-e6c5d04d3f6b_9.png', '10', '1');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('11', 'Snack Dom Tchochoro para C??es sabor Fil?? de Carne Bovino 100g', '- Indicado para c??es;- Alimento mastig??vel;- Natural e 100% saud??vel;- Feito com fil?? bovino desidratado,- Dispon??vel em embalagem de 100g.', 'Dom Tchochoro ', '21,99', '50', '~/Images/41cd96ef-cf8a-4743-bc4b-5d04e5284a05_10.png', '9', '1');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('12', 'Snack Dom Tchochoro Cuidado Oral para C??es de Pequeno Porte', '- Indicado para c??es;- Ajuda na redu????o da placa bacteriana;- Auxilia na redu????o do ac??mulo do t??rtaro;- Ajuda na limpeza dos dentes;- H??lito fresco;- Dispon??vel em embalagens de 3 e 7 unidades.', 'Dom Tchochoro', '4,99', '50', '~/Images/cf396fc9-2117-4b04-9e4e-0d8db69ce15b_12.png', '10', '1');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('13', 'Ra????o Royal Canin Maxi - C??es Adultos - 15kg', '- Indicada para c??es;- Ideal para pets de grande porte;- Oferece todos nutrientes necess??rios para uma vida saud??vel;- Proporciona maior aporte para os ossos e articula????es;- Cont??m f??rmula enriquecida com ??mega 3,- Dispon??vel em embalagem de 15 kg.', 'Royal Canin', '302,59', '50', '~/Images/7b684a1a-d3cf-45a0-b350-37ae69c10ca8_13.png', '10', '1');
INSERT INTO `db_asp`.`tbl_product` (`prod_id`, `prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES ('14', 'Ra????o Golden Duii para C??es Adultos Sabor Salm??o com Ervas e Cordeiro com Arroz - 10,1kg', '- Indicada para c??s adultos;- Conta com dois sabores exclusivos;- Proporciona ??mega 3 e 6;- Oferece sa??de intestinal,- Dispon??vel em embalagem com 10,1 kg.', 'Premier Pet ', '146,99', '50', '~/Images/78a784b5-88d2-482c-b374-48805ebf567b_14.png', '10', '1');
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES ('22286878711', '994635595', 'Rafael Ioshi', 'rafa.ioshi@gmail.com', 'ioshi00', '~/Images/db1f9071-dfed-46ff-8c9e-ab960d8d042a_1.png', '1');
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('22286878711', '994635495', 'Vitor Vieira', 'vitor@gmail.com', 'vitor00', '0');
INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`, `user_lvl`) VALUES ('22286878711', '994635511', 'Jo??o Tancredi', 'joao@gmail.com', 'joao00', '0');
INSERT INTO `db_asp`.`tbl_address` (`address_cep`, `address_uf`, `address_city`, `address_district`, `address_public_place`, `address_complement`, `fk_user_id`) VALUES ('06020187', 'SP', 'Osasco', 'Parque Continental', 'Av Manoel Pedro Pimentel 200', 'Bl 15 Ap 81', '3');
INSERT INTO `db_asp`.`tbl_address` (`address_cep`, `address_uf`, `address_city`, `address_district`, `address_public_place`, `fk_user_id`) VALUES ('20165844', 'RJ', 'Niter??i', 'Barreto', 'Rua Guimar??es J??nior 13', '2');
INSERT INTO `db_asp`.`tbl_address` (`address_cep`, `address_uf`, `address_city`, `address_district`, `address_public_place`, `address_complement`, `fk_user_id`) VALUES ('10202021', 'MA', 'Nova Iorque', 'Pastos Bons', 'Rua S??o Jo??o 23', 'Casa 2', '1');