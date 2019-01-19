//Anastasiia Korneva
//Assignment 4
//3/19/2018
//DataBaseConnection.cs
//This file contains functionality for GUI and make request to connection class and get data from it to sed to GUI

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;
using chartDB;

namespace chartDB
{

    public partial class Form1 : Form
    {
        List<string> Product_Class = new List<string>();//list for Product Class
        List<string> City_List = new List<string>();//list for Sales City
        List<string> Product_List = new List<string>();//list for Product
        public Form1()
        {
            InitializeComponent();
            //connect to database
            DataBaseConnection dbc = new DataBaseConnection();
           // dbc.ConnectoToSQL();

            //create a chart
            var chartArea = new ChartArea("FopdMartChart");
            chartArea.AxisX.Title = "Months of the year";
            chartArea.AxisY.Title = "Sales";
            this.FopdMartChart.Titles.Add("Sales");
            string[] monthes = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            //get all Cities
            City_List= dbc.getSalesCity();

            //Get All products
            Product_Class=dbc.getProductClass();

            //Insert values which provides functionality according requernements
            SalesCity.Items.Add("All");
            SalesCity.Items.Add("Any one");

            ProductClass.Items.Add("All");
            ProductClass.Items.Add("Any one");

            //insert values from database to listboxes
            int numOfItems = City_List.Count();
            for(int i=0; i< numOfItems; i++ )
            {
                SalesCity.Items.Add(City_List[i]);
            }

            numOfItems = Product_Class.Count();
            for (int i = 0; i < numOfItems; i++)
            {
                ProductClass.Items.Add(Product_Class[i]);
            }

        }



        /// <summary>
        /// This method insert values of products from chosen category
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBaseConnection dbc = new DataBaseConnection();
            Product.Items.Clear();

           // dbc.ConnectoToSQL();
            string category = ProductClass.GetItemText(ProductClass.SelectedItem);
            Product_List = dbc.getProducts(category, Product_Class);
            Product.Items.Add("All");
            Product.Items.Add("Any one");

            int numOfItems = Product_List.Count();
            for (int i = 0; i < numOfItems; i++)
            {
                Product.Items.Add(Product_List[i]);
            }

        }


        //Metods created by system for GUI
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        private void chart1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// This method calls a function to get values from a database and create a new chart using this values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refresh_Click(object sender, EventArgs e)
        {
            //create connection
            DataBaseConnection dbc = new DataBaseConnection();

            //get values from GUI
            string city= SalesCity.GetItemText(SalesCity.SelectedItem);
            string product = Product.GetItemText(Product.SelectedItem);

            //monthes for chart
            string[] monthes = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            //give a random value for city if required
            if (city == "Any one")
            {
                int numOfItems = City_List.Count();
                Random rnd = new Random();
                int rand = rnd.Next(0, numOfItems);
                city = City_List[rand];
            }

            //give a random value for product if required
            if (product == "Any one")
            {
                int numOfItems = Product_List.Count();
                Random rnd = new Random();
                int rand = rnd.Next(0, numOfItems);
                product = Product_List[rand];
            }

            //get valus for each month to dispay
           double[] mothSales=dbc.getValuesFromDB(city, product);
           
            //give a fancy and nice color to chart
            this.FopdMartChart.Palette = ChartColorPalette.Berry;

            //remove all data from chart
            foreach (var series in FopdMartChart.Series)
            {
                series.Points.Clear();
            }
            // Add series.
            for (int i = 0; i < monthes.Length; i++)
            {
                this.FopdMartChart.Series["Month"].Points.AddXY(monthes[i], mothSales[i]);
            }
        }
    }
}
