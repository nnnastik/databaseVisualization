//Anastasiia Korneva
//Assignment 4
//3/19/2018
//DataBaseConnection.cs
//This file contains functionality to connect application to database, make requests and work with responds from server

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace chartDB
{
    //This class was created to provide efficient connection from application to database
    public class DataBaseConnection
    {
        SqlConnection cnn;
        SqlDataReader rdr = null;
        SqlCommand cmd = null;

        List<string> Product_Class = new List<string>();
        List<string> City_List = new List<string>();
        List<string> Product_List = new List<string>();

        /// <summary>
        /// Class constructor
        /// </summary>
        public DataBaseConnection()
        {

        }

        /// <summary>
        /// Class destructor
        /// </summary>
        ~ DataBaseConnection()
        {

        }


        /// <summary>
        /// This class gets all products from database from Product class by user choice
        /// </summary>
        /// <param name="category">Product class to get products from</param>
        /// <param name="Product_Class">List of all product classes</param>
        /// <returns>List of products from database from Product Class</returns>
        public List<string> getProducts(string category, List<string> Product_Class)
        {
            string getProduct;
            ConnectoToSQL();
            //request if all categories
            if (category == "All")
            {
                getProduct = "SELECT DISTINCT product.product_name FROM dbo.sales_fact_1998 RIGHT JOIN product ON sales_fact_1998.product_id= product.product_class_id INNER JOIN product_class ON product.product_class_id= product_class.product_class_id ORDER BY product.product_name";
            }

            //get random category
            else if (category == "Any one")
            {
                int numOfItems = Product_Class.Count();
                Random rnd = new Random();
                int rand = rnd.Next(0, numOfItems);
                category = Product_Class[rand];
                getProduct = "SELECT DISTINCT product.product_name FROM dbo.sales_fact_1998 RIGHT JOIN product ON sales_fact_1998.product_id= product.product_class_id INNER JOIN product_class ON product.product_class_id= product_class.product_class_id  WHERE product_subcategory= '" + category + "' ORDER BY product.product_name";
            }
            //use chosen category
            else
            {
                getProduct = "SELECT DISTINCT product.product_name FROM dbo.sales_fact_1998 RIGHT JOIN product ON sales_fact_1998.product_id= product.product_class_id INNER JOIN product_class ON product.product_class_id= product_class.product_class_id  WHERE product_subcategory= '" + category + "' ORDER BY product.product_name";
            }
            //connect to database
            try
            {
                cmd = new SqlCommand(getProduct);
                cmd.Connection = cnn;
                cnn.Open();/////
                rdr = cmd.ExecuteReader();

                //add all products to list
                while (rdr.Read())
                {
                    string pr = rdr[0].ToString();
                    Product_List.Add(pr);
                }
                cmd.Connection.Close();
                cnn.Close();
            }
            catch (Exception ex)

            {
                // MessageBox.Show("Can not open connection ! ");
                return null;
            }
            return Product_List;
            
        }



        /// <summary>
        /// This function get all product classes from table
        /// </summary>
        /// <returns>list of product classes from database</returns>
        public List<string> getProductClass()
        {
            //connect to database
            ConnectoToSQL();
            string getProductClass = "SELECT DISTINCT product_class.product_subcategory FROM dbo.sales_fact_1998 RIGHT JOIN product ON sales_fact_1998.product_id= product.product_class_id INNER JOIN product_class ON product.product_class_id= product_class.product_class_id ORDER BY product_class.product_subcategory";
            try
            {
                SqlCommand cmdPC = new SqlCommand(getProductClass);
                cmdPC.Connection = cnn;
                cnn.Open();
                SqlDataReader pc = cmdPC.ExecuteReader();

                //add all values to list
                while (pc.Read())
                {
                    string pClass = pc[0].ToString();
                    Product_Class.Add(pClass);
                }
                cnn.Close();
            }
             
            catch (Exception ex)

            {
                // MessageBox.Show("Can not open connection ! ");
                return null;
            }
            return Product_Class;
        }


        /// <summary>
        /// This function get all product cities from table
        /// </summary>
        /// <returns></returns>
        public List<string> getSalesCity()
        {
            //connect to database
            ConnectoToSQL();
           
            string getSalesCity = "SELECT DISTINCT store_city FROM dbo.sales_fact_1998 INNER JOIN store ON sales_fact_1998.store_id= store.store_id ORDER BY store_city";
            try
            {
                cnn.Open();
                cmd = new SqlCommand(getSalesCity);
                cmd.Connection = cnn;
                rdr = cmd.ExecuteReader();

                //add all values to list
                while (rdr.Read())
                {
                    string city = rdr["store_city"].ToString();
                    City_List.Add(city);
                }
                cmd.Connection.Close();
            }
            catch (Exception ex)

            {
                // MessageBox.Show("Can not open connection ! ");
                return null;
            }
            return City_List;
        }


        /// <summary>
        /// This method start connection to database using connection string from app.config
        /// </summary>
        /// <returns></returns>
        private int ConnectoToSQL()
        {
            try
            {
                var connection = System.Configuration.ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                cnn = new SqlConnection(connection);
                cnn.Open();
                cnn.Close();
            }
            catch (Exception ex)

            {
                // MessageBox.Show("Can not open connection ! ");
                return -1;
            }
            return 0;

        }



        /// <summary>
        /// This function gets month sales for a year from a table from database according user choice of sity and product
        /// </summary>
        /// <param name="city"></param>
        /// <param name="product"></param>
        /// <returns>values for 12 monthes</returns>
        public double[] getValuesFromDB(string city, string product)
        {
            double[] mothSales = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            string[] monthes = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            string janStr = "";
            string qur = "";
            ConnectoToSQL();
            //pick up connection string by user choice
            for (int i = 0; i < 12; i++)
            {
                if (city == "All")
                {
                    if (product == "All")
                    {
                        qur = "SELECT SUM(store_sales) FROM sales_fact_1998 INNER JOIN time_by_day ON sales_fact_1998.time_id= time_by_day.time_id INNER JOIN store ON sales_fact_1998.store_id= store.store_id INNER JOIN product ON sales_fact_1998.product_id= product.product_class_id WHERE time_by_day.the_month='" + monthes[i] + /*/*"' AND  store_city='" + city +  "'AND product.product_name='" + product + */"'";
                    }
                    else
                    {
                        qur = "SELECT SUM(store_sales) FROM sales_fact_1998 INNER JOIN time_by_day ON sales_fact_1998.time_id= time_by_day.time_id INNER JOIN store ON sales_fact_1998.store_id= store.store_id INNER JOIN product ON sales_fact_1998.product_id= product.product_class_id WHERE time_by_day.the_month='" + monthes[i] + /*"' AND  store_city='" + city +*/ "' AND product_name='" + product + "'";
                    }
                }
                else
                {
                    if (product == "All")
                    {
                        qur = "SELECT SUM(store_sales) FROM sales_fact_1998 INNER JOIN time_by_day ON sales_fact_1998.time_id= time_by_day.time_id INNER JOIN store ON sales_fact_1998.store_id= store.store_id INNER JOIN product ON sales_fact_1998.product_id= product.product_class_id WHERE time_by_day.the_month='" + monthes[i] + "' AND  store_city='" + city + /* "'AND product.product_name='" + product + */"'";
                    }
                    else
                    {
                        qur = "SELECT SUM(store_sales) FROM sales_fact_1998 INNER JOIN time_by_day ON sales_fact_1998.time_id= time_by_day.time_id INNER JOIN store ON sales_fact_1998.store_id= store.store_id INNER JOIN product ON sales_fact_1998.product_id= product.product_class_id WHERE time_by_day.the_month='" + monthes[i] + "' AND  store_city='" + city + "' AND product_name='" + product + "'";
                    }
                }
                //connect to database
                try
                {
                    SqlCommand cmdPC = new SqlCommand(qur)
                    {
                        Connection = cnn
                    };
                    cnn.Open();
                    SqlDataReader pc = cmdPC.ExecuteReader();

                    //record all data
                    while (pc.Read())
                    {
                        janStr = pc[0].ToString();
                        try
                        {
                            mothSales[i] = Convert.ToDouble(janStr);
                        }
                        catch (Exception ex)
                        {
                            mothSales[i] = 0;
                        }
                    }
                    cnn.Close();
                }
                catch (Exception ex)

                {
                    // MessageBox.Show("Can not open connection ! ");
                    return null;
                }
            }
            return mothSales;
        }
    }
}
