using MySql.Data.MySqlClient;
using System;
using GladiaSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace GladiaSystem.Database
{
    public class Queries
    {
        Connection con = new Connection();

        public bool CategoryExists(Category category)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_category WHERE category_name = @name", con.ConnectionDB());
            cmd.Parameters.AddWithValue("@name", category.name);
            MySqlDataReader reader;
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        public string Login(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_lvl FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.userLvl = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.userLvl;
                    }
                }
            }
            else
            {
                user.userLvl = null;
            }
            reader.Close();
            return "error";
        }

        public User GetUser(string userID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbl_user where (user_id = @user_id);", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.userID = Convert.ToString(reader[0]);
                        dto.Cpf = Convert.ToString(reader[1]);
                        dto.Celular = Convert.ToString(reader[2]);
                        dto.name = Convert.ToString(reader[3]);
                        dto.email = Convert.ToString(reader[4]);
                        reader.Close();
                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();
            User a = new User();
            return a;
        }


        public string GetUserName(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_name FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.name = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.name;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }


        public string GetUserEmail(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_email FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.email = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.email;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }

        public string GetUserID(User user)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT user_id FROM tbl_user where user_email = @email and user_password=@password;", con.ConnectionDB());
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.userID = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.userID;
                    }
                }
            }
            else
            {
                user.userLvl = null;
                reader.Close();
                return "error";
            }
            reader.Close();
            return "error";
        }


        public string GetUserImages(string UserID)
        {
            MySqlCommand cmd = new MySqlCommand("select * from img  where user_id = @UserID;", con.ConnectionDB());
            cmd.Parameters.Add("@UserID", MySqlDbType.VarChar).Value = UserID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User dto = new User();
                    {
                        dto.img = Convert.ToString(reader[0]);
                        reader.Close();
                        return dto.img;
                    }
                }
            }
            else
            {
                return null;
            }
            reader.Close();
            return "error";

        }

        public void ChangePhoto(string imagePath, string session)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_img` = @img WHERE (`user_id` = @session);", con.ConnectionDB());
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = imagePath;
            cmd.Parameters.Add("@session", MySqlDbType.VarChar).Value = session;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterCategory(Category category)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_category` (`category_name`) VALUES (@name);", con.ConnectionDB());
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = category.name;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void RegisterUserEcommerce(User user)
        {

            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_user` (`user_cpf`, `user_phone`, `user_name`, `user_email`, `user_password`,`user_lvl`) VALUES(@cpf, @phone, @name, @mail, @password, '0'); ", con.ConnectionDB());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = user.Cpf;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = user.Celular;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = user.name;
            cmd.Parameters.Add("@mail", MySqlDbType.VarChar).Value = user.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = user.password;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void RegisterNewAddress(User user, int userIDInt) {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_address` (`address_cep`, `address_uf`, `address_city`, `address_district`, `address_public_place`, `address_complement`, `fk_user_id`) VALUES (@cep, @uf, @city, @district, @place, @complement, @user_id); ", con.ConnectionDB());
            cmd.Parameters.Add("@cep", MySqlDbType.VarChar).Value = user.Cep;
            cmd.Parameters.Add("@uf", MySqlDbType.VarChar).Value = user.UF;
            cmd.Parameters.Add("@city", MySqlDbType.VarChar).Value = user.City;
            cmd.Parameters.Add("@district", MySqlDbType.VarChar).Value = user.District;
            cmd.Parameters.Add("@place", MySqlDbType.VarChar).Value = user.PublicPlace;
            cmd.Parameters.Add("@complement", MySqlDbType.VarChar).Value = user.Complement;
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userIDInt;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void RegisterProd(Product product, string path)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_product` (`prod_name`, `prod_desc`, `prod_brand`, `prod_price`, `prod_quant`, `prod_img`, `prod_min_quant`, `fk_category`) VALUES(@Name, @Desc, @Brand, @Price, @Quant, @Img, @QuantMin, @CategoryID);", con.ConnectionDB());
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = product.Desc;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = product.Brand;
            cmd.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
            cmd.Parameters.Add("@Quant", MySqlDbType.VarChar).Value = product.Quant;
            cmd.Parameters.Add("@Img", MySqlDbType.VarChar).Value = path;
            cmd.Parameters.Add("@QuantMin", MySqlDbType.VarChar).Value = product.QuantMin;
            cmd.Parameters.Add("@CategoryID", MySqlDbType.VarChar).Value = product.Category.ID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }


        public void RegisterAdm(User adm, string path)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_user` (`user_cpf`,`user_phone`,`user_name`, `user_email`, `user_password`, `user_img`, `user_lvl`) VALUES(@cpf, @phone, @name, @email, @password, @img, '1');", con.ConnectionDB());
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = adm.Cpf;
            cmd.Parameters.Add("@phone", MySqlDbType.VarChar).Value = adm.Celular;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = adm.name;
            cmd.Parameters.Add("@email", MySqlDbType.VarChar).Value = adm.email;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = adm.password;
            cmd.Parameters.Add("@img", MySqlDbType.VarChar).Value = path;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void DeleteAccount(string deleteID)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_user` WHERE (`user_id` = @user_id );", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = deleteID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void ChangePass(string password, string userID)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_password` = @password WHERE (`user_id` = @user_id);", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void ChangeName(string name, string userID)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_user` SET `user_name` = @name WHERE (`user_id` = @user_id);", con.ConnectionDB());
            cmd.Parameters.Add("@user_id", MySqlDbType.VarChar).Value = userID;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();

        }

        public void DeleteItemProduct(int codItem)
        {
            MySqlCommand cmd = new MySqlCommand("DELETE FROM `db_asp`.`tbl_product` WHERE (`prod_id` = @product_item);", con.ConnectionDB());
            cmd.Parameters.Add("@product_item", MySqlDbType.VarChar).Value = codItem;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public Order GetOrderByID(int orderID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM db_asp.tbl_order where order_id = @orderID;", con.ConnectionDB());
            cmd.Parameters.Add("@orderID", MySqlDbType.VarChar).Value = orderID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Order dto = new Order();
                    {
                        dto.DateOrder = Convert.ToString(reader[1]);

                        reader.Close();
                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();
            Order orderReturn = new Order();
            return orderReturn;
        }

        public List<Order> ListOrder(string ID)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM db_asp.tbl_order where fk_id_user = @ID AND order_status = 1;", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = ID;
            var OrderDatas = cmd.ExecuteReader();
            return ListAllOrder(OrderDatas);
        }

        public List<Order> ListAllOrder(MySqlDataReader dt)
        {
            var AllOrders = new List<Order>();
            while (dt.Read())
            {
                var OrderTemp = new Order()
                {
                    ID = (dt["order_id"].ToString()),
                    DateOrder = (dt["order_date"].ToString()),
                    Payment = (dt["order_payment"].ToString()),
                    PriceTotal = (dt["order_total"].ToString()),
                };
                AllOrders.Add(OrderTemp);
            }
            dt.Close();
            return AllOrders;
        }

        public Product GetProduct(string productName)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT prod_id,prod_name,prod_desc,prod_brand,prod_price,prod_quant,prod_min_quant,fk_category,category_id,category_name, REPLACE(prod_img, '~/', '../') FROM db_asp.tbl_product join tbl_category on tbl_product.fk_category = tbl_category.category_id WHERE prod_name LIKE @name;", con.ConnectionDB());
            string name = productName + "%";
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product dto = new Product();
                    {
                        dto.ID = Convert.ToInt32(reader[0]);
                        dto.Name = Convert.ToString(reader[1]);
                        dto.Desc = Convert.ToString(reader[2]);
                        dto.Brand = Convert.ToString(reader[3]);
                        dto.Price = Convert.ToInt32(reader[4]);
                        dto.Quant = Convert.ToInt32(reader[5]);
                        dto.QuantMin = Convert.ToInt32(reader[6]);
                        dto.Category.name = Convert.ToString(reader[9]);
                        dto.img = Convert.ToString(reader[10]);
                        reader.Close();
                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();
            Product a = new Product();
            return a;
        }

        public void AddProduct(Pos pos)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_pos` (`pos_quant_order`, `fk_product_id`) VALUES (@quantOrder, @prodId);", con.ConnectionDB());
            cmd.Parameters.Add("@quantOrder", MySqlDbType.VarChar).Value = pos.QuantOrder;

            cmd.Parameters.Add("@prodId", MySqlDbType.VarChar).Value = GetProdId(pos.Product.Name);

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }


        public int Administrator()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) AS 'Administrator' FROM db_asp.tbl_user WHERE user_lvl = 1;", con.ConnectionDB());

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int outPut = Convert.ToInt32(reader[0]);
                    reader.Close();
                    return outPut;
                }
            }
            reader.Close();
            return 0;
        }

        public int GetProdId(string name)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT prod_id FROM db_asp.tbl_product WHERE prod_name LIKE @prodName;", con.ConnectionDB());
            string nameProduct = name + "%";
            cmd.Parameters.Add("@prodName", MySqlDbType.VarChar).Value = nameProduct;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product dto = new Product();
                    {
                        dto.ID = Convert.ToInt32(reader[0]);
                        int id = dto.ID;
                        reader.Close();
                        return id;
                    }
                }
            }
            reader.Close();
            return 0;
        }

        public List<Product> ListCategoryQuant()
        {
            MySqlCommand cmd = new MySqlCommand("select sum(prod_quant) as quant, category_name from db_asp.tbl_product inner join tbl_category on tbl_product.fk_category = tbl_category.category_id group by category_name;", con.ConnectionDB());
            var categoryData = cmd.ExecuteReader();
            return ListAllCategoryQuant(categoryData);
        }

        private List<Product> ListAllCategoryQuant(MySqlDataReader categoryData)
        {
            var AllCategoryQuant = new List<Product>();

            while (categoryData.Read())
            {
                var tempCategoryQuant = new Product()
                {
                    Quant = int.Parse(categoryData["quant"].ToString()),
                    CategoryName = categoryData["category_name"].ToString(),
                };
                AllCategoryQuant.Add(tempCategoryQuant);
            }
            categoryData.Close();
            return AllCategoryQuant;
        }

        public List<Category> ListCategory()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT category_name,category_id FROM db_asp.tbl_category;", con.ConnectionDB());
            var categoryData = cmd.ExecuteReader();
            return ListAllCategory(categoryData);
        }

        private List<Category> ListAllCategory(MySqlDataReader categoryData)
        {
            var AllCategory = new List<Category>();

            while (categoryData.Read())
            {
                var tempCategory = new Category()
                {
                    name = categoryData["category_name"].ToString(),
                    ID = int.Parse(categoryData["category_id"].ToString()),
                };
                AllCategory.Add(tempCategory);
            }
            categoryData.Close();
            return AllCategory;
        }

        public Product GetProductByID(int productID)
        {
            MySqlCommand cmd = new MySqlCommand("select * from allproduct where prod_id = @ID;", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = productID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Product dto = new Product();
                    {
                        dto.ID = Convert.ToInt32(reader[0]);
                        dto.Name = Convert.ToString(reader[1]);
                        dto.Desc = Convert.ToString(reader[2]);
                        dto.Brand = Convert.ToString(reader[3]);
                        dto.Price = (int)Convert.ToDouble(reader[4]);
                        dto.Quant = Convert.ToInt32(reader[5]);
                        dto.img = Convert.ToString(reader[10]);
                        dto.QuantMin = Convert.ToInt32(reader[6]);
                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();

            Product productReturn = new Product();
            return productReturn;
        }

        public List<Product> ListProduct()
        {
            MySqlCommand cmd = new MySqlCommand("select * from allproduct;", con.ConnectionDB());
            var ProductDatas = cmd.ExecuteReader();
            return ListAllProduct(ProductDatas);
        }

        public List<Product> ListAllProduct(MySqlDataReader dt)
        {
            var AllProduct = new List<Product>();
            while (dt.Read())
            {
                var ProdTemp = new Product()
                {
                    ID = int.Parse(dt["prod_id"].ToString()),
                    Name = (dt["prod_name"].ToString()),
                    Desc = (dt["prod_desc"].ToString()),
                    Price = int.Parse(dt["prod_price"].ToString()),
                    Quant = int.Parse(dt["prod_quant"].ToString()),
                    QuantMin = int.Parse(dt["prod_min_quant"].ToString()),
                    Brand = (dt["prod_brand"].ToString()),
                    img = (dt["img"].ToString()),
                };
                AllProduct.Add(ProdTemp);
            }
            dt.Close();
            return AllProduct;
        }

        public void UpdateProduct(Product product)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_product` SET `prod_name` = @Name, `prod_desc` = @Desc, `prod_brand` = @Brand, `prod_price` = @Price, `prod_quant` = @Quant, `prod_min_quant` = @QuantMin WHERE (`prod_id` = @ID);", con.ConnectionDB());
            cmd.Parameters.Add("@ID", MySqlDbType.VarChar).Value = product.ID;
            cmd.Parameters.Add("@Name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@Desc", MySqlDbType.VarChar).Value = product.Desc;
            cmd.Parameters.Add("@Brand", MySqlDbType.VarChar).Value = product.Brand;
            cmd.Parameters.Add("@Price", MySqlDbType.VarChar).Value = product.Price;
            cmd.Parameters.Add("@Quant", MySqlDbType.VarChar).Value = product.Quant;
            cmd.Parameters.Add("@QuantMin", MySqlDbType.VarChar).Value = product.QuantMin;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public void OpenOrder(string owner, int totalValue)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_order` (`order_date`, `order_payment`, `order_total`, `order_status`, `fk_id_user`) VALUES (@DateNow, 'PicPay', @TotalValue, '0', @Owner);", con.ConnectionDB());
            DateTime aDate = DateTime.Now;
            cmd.Parameters.Add("@DateNow", MySqlDbType.VarChar).Value = aDate.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@Owner", MySqlDbType.VarChar).Value = owner;
            cmd.Parameters.Add("@TotalValue", MySqlDbType.VarChar).Value = totalValue;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public int GetOrderOpen(string userOwner)
        {
            MySqlCommand cmd = new MySqlCommand("SELECT order_id FROM db_asp.tbl_order where fk_id_user = @Owner AND order_status = 0;", con.ConnectionDB());
            cmd.Parameters.Add("@Owner", MySqlDbType.VarChar).Value = userOwner;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int dto = new int();
                    {
                        dto = Convert.ToInt32(reader[0]);
                        reader.Close();
                        return dto;
                    }
                }
            }
            reader.Close();
            return 0;
        }
        
        public void InserItemsOrder(int orderOpenID, List<Product> productList)
        {

            foreach (var item in productList)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO `db_asp`.`tbl_items_order` (`fk_id_order`, `fk_id_prod`, `items_quant`, `item_subtotal`) VALUES(@OrderOpenID, @ItemID, @ItemQuant, @SubTotal);", con.ConnectionDB());
                int subTotalValue = item.Price * item.Quant;

                cmd.Parameters.Add("@OrderOpenID", MySqlDbType.VarChar).Value = orderOpenID;
                cmd.Parameters.Add("@ItemID", MySqlDbType.VarChar).Value = item.ID;
                cmd.Parameters.Add("@ItemQuant", MySqlDbType.VarChar).Value = item.Quant;
                cmd.Parameters.Add("@SubTotal", MySqlDbType.VarChar).Value = subTotalValue;

                cmd.ExecuteNonQuery();
                con.DisconnectDB();
            }

        }

        public void CloseOrder(int orderOpenID)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE `db_asp`.`tbl_order` SET `order_status` = '1' WHERE (`order_id` = @OrderOpenID);", con.ConnectionDB());
            cmd.Parameters.Add("@OrderOpenID", MySqlDbType.VarChar).Value = orderOpenID;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }

        public List<TrackOrder> Track(int orderID)
        {
            MySqlCommand cmd = new MySqlCommand("select * from trackOrder WHERE order_id = @OrderID", con.ConnectionDB());
            cmd.Parameters.Add("@OrderID", MySqlDbType.VarChar).Value = orderID;
            var TrackDatas = cmd.ExecuteReader();
            return ListAllTrack(TrackDatas);
        }

        public List<TrackOrder> ListAllTrack(MySqlDataReader dt)
        {
            var AllTrack = new List<TrackOrder>();
            while (dt.Read())
            {
                var TrackTemp = new TrackOrder()
                {
                    OrderID = int.Parse(dt["order_id"].ToString()),
                    Name = (dt["prod_name"].ToString()),
                    Payment = (dt["order_payment"].ToString()),
                    Date = (dt["order_date"].ToString()),
                    Desc = (dt["prod_desc"].ToString()),
                    Price = int.Parse(dt["prod_price"].ToString()),
                    Quant = int.Parse(dt["items_quant"].ToString()),
                    Image = (dt["prod_img"].ToString())
                };
                AllTrack.Add(TrackTemp);
            }
            dt.Close();
            return AllTrack;
        }

        public TrackOrder GetTrack(int orderID)
        {
            MySqlCommand cmd = new MySqlCommand("select * from trackOrder WHERE order_id = @OrderID", con.ConnectionDB());
            cmd.Parameters.Add("@OrderID", MySqlDbType.VarChar).Value = orderID;

            MySqlDataReader reader;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    TrackOrder dto = new TrackOrder();
                    {
                        dto.OrderID = Convert.ToInt32(reader[0]);
                        dto.Date = Convert.ToString(reader[1]);
                        dto.Payment = Convert.ToString(reader[2]);
                        return dto;
                    }
                }
            }
            else
            {
                //return null;
            }
            reader.Close();

            TrackOrder trackReturn = new TrackOrder();
            return trackReturn;
        }

        public List<Product> ListProductByCategory(string category)
        {
            MySqlCommand cmd = new MySqlCommand("select * from allproduct where category_name = @Category;", con.ConnectionDB());
            cmd.Parameters.Add("@Category", MySqlDbType.VarChar).Value = category;

            var ProductDatas = cmd.ExecuteReader();
            return ListAllProductByCategory(ProductDatas);
        }

        public List<Product> ListAllProductByCategory(MySqlDataReader dt)
        {
            var AllProduct = new List<Product>();
            while (dt.Read())
            {
                var ProdTemp = new Product()
                {
                    ID = int.Parse(dt["prod_id"].ToString()),
                    Name = (dt["prod_name"].ToString()),
                    Desc = (dt["prod_desc"].ToString()),
                    Price = int.Parse(dt["prod_price"].ToString()),
                    Quant = int.Parse(dt["prod_quant"].ToString()),
                    QuantMin = int.Parse(dt["prod_min_quant"].ToString()),
                    Brand = (dt["prod_brand"].ToString()),
                    img = (dt["img"].ToString()),
                };
                AllProduct.Add(ProdTemp);
            }
            dt.Close();
            return AllProduct;
        }

        public void RemoveFromStorage(int prodID, int prodQuantToRemove)
        {
            MySqlCommand cmd = new MySqlCommand("UPDATE tbl_product SET prod_quant = prod_quant - @ProdQuant WHERE prod_id = @ProdID;", con.ConnectionDB());
            cmd.Parameters.Add("@ProdID", MySqlDbType.VarChar).Value = prodID;
            cmd.Parameters.Add("@ProdQuant", MySqlDbType.VarChar).Value = prodQuantToRemove;

            cmd.ExecuteNonQuery();
            con.DisconnectDB();
        }
    }
}