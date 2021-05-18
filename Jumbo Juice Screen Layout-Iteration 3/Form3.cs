using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //This is for the use of SQL - Will need to be on every form

namespace Jumbo_Juice_Screen_Layout
{
    public partial class Form3 : Form
    {
        //This string holds the ID of the employee who logged in
        string employeeID = "";

        //Global variable to store the amount a specific customer has spent with us
        string customerSpendings = "0";

        //List that holds customer IDs. The customer in index 0 in the customer combo box will have an ID in index zero here. This continues all the way up the string
        //Wanted to have this seperate (not just saying ID = combobox index + 1 --> so the item at index 0 = customer ID 1) so customers could be deleted and still have an ID that is correct
        List<string> parallelCustomerIDsList = new List<string>();



        //Use this to connect to the database
        ////////////////////////////////////////////////////////////////////////////////////
        string connectionstring = "Data Source=essql1.walton.uark.edu;Initial Catalog=ISYS4283Team21;User ID=ISYS4283Team21;Password=KY55kzb$";
        SqlConnection connection; //Function to open an sql database
        SqlCommand command; //Used to execute sql statements I think???
        SqlDataReader datareader;
        ////////////////////////////////////////////////////////////////////////////////////

        public Form3(string empID)
        {
            InitializeComponent();

            //Set the employee ID to the employee's ID who logged in
            employeeID = empID;
        }

        private void reportingMenuButton_Click(object sender, EventArgs e)
        {
            reportingPanel.Visible = true;
            purchasePanel.Visible = false;

            //Use this to load employee names from the database into the Employee Report Combo Box
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT First_Name FROM Employee";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Uploads employees into the employee combo box
            while (datareader.Read())
            {
                employeeReportComboBox.Items.Add(datareader[0].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




            //Use this to load customer names from the database into the Employee Report Combo Box
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlC = "SELECT First_Name, Customer_ID FROM Customer";
            command = new SqlCommand(sqlC, connection);
            datareader = command.ExecuteReader();

            //Uploads customers into the customer combo box
            while (datareader.Read())
            {
                customerProfileComboBox.Items.Add(datareader[0].ToString());
                parallelCustomerIDsList.Add(datareader[1].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




            //Use this to populate the inventory report upon loading this form
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Populate the sales datagridview
            var sqlI = "SELECT Ingredient_UPC, Name, Quantity FROM Ingredient";
            var da = new SqlDataAdapter(sqlI, connection);
            var ds = new DataSet();  //Dataset - basical a spreadsheet
            da.Fill(ds); //Take the data adapter and fill the dataset
            inventoryDataGridView.DataSource = ds.Tables[0];
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            //Use this to load the profit into the profit textbox
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            double costs = 0; //Will save costs to this
            double revenues = 0; //Will save revenues to this

            //Find costs
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlCost = "SELECT SUM(I.Buy_Cost * P.Quantity) FROM Purchase_Order P LEFT JOIN Ingredient I ON P.Ingredient_UPC = I.Ingredient_UPC";
            command = new SqlCommand(sqlCost, connection);
            datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                costs = Convert.ToDouble(datareader[0]);
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader

            costs = costs + 2000 + 7200;


            //Now find revs
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlRev = "SELECT SUM(Amount_Paid) FROM Sales_Order";
            command = new SqlCommand(sqlRev, connection);
            datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                revenues = Convert.ToDouble(datareader[0]);
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
                                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Now fill the profit textbox
            profitTextBox.Text = "$" + Convert.ToString(revenues - costs);
        }

        //Create the parallel lists
        List<string> ParalellIngredientList = new List<string>();
        List<string> ParalellVendorList = new List<string>();
        private void purchaseMenuButton_Click(object sender, EventArgs e)
        {
            purchasePanel.Visible = true;
            reportingPanel.Visible = false;

            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT Ingredient_UPC, Name FROM Ingredient";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            
            while (datareader.Read())
            {
                orderIngredientComboBox.Items.Add(datareader[1].ToString());
                ParalellIngredientList.Add(datareader[0].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader


            /*
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlv = "SELECT Name, Vendor_ID FROM Vendor";
            command = new SqlCommand(sqlv, connection);
            datareader = command.ExecuteReader();


            while (datareader.Read())
            {
                VendorIDComboBox.Items.Add(datareader[0].ToString());
                ParalellVendorList.Add(datareader[1].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            */
        }

        private void homeMenuButton_Click(object sender, EventArgs e)
        {
            purchasePanel.Visible = false;
            reportingPanel.Visible = false;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            purchasePanel.Visible = false;
            reportingPanel.Visible = false;


            //All of this was put into the reporting menu button. Keeping it commented out right now just in case. Will delete later to clean up
            /*
            //Use this to load employee names from the database into the Employee Report Combo Box
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT First_Name FROM Employee";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Uploads employees into the employee combo box
            while (datareader.Read())
            {
                employeeReportComboBox.Items.Add(datareader[0].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //Use this to load customer names from the database into the Employee Report Combo Box
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlC = "SELECT First_Name, Customer_ID FROM Customer";
            command = new SqlCommand(sqlC, connection);
            datareader = command.ExecuteReader();

            //Uploads customers into the customer combo box
            while (datareader.Read())
            {
                customerProfileComboBox.Items.Add(datareader[0].ToString());
                parallelCustomerIDsList.Add(datareader[1].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //Use this to populate the inventory report upon loading this form
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Populate the sales datagridview
            var sqlI = "SELECT Ingredient_UPC, Name, Quantity FROM Ingredient";
            var da = new SqlDataAdapter(sqlI, connection);
            var ds = new DataSet();  //Dataset - basical a spreadsheet
            da.Fill(ds); //Take the data adapter and fill the dataset
            inventoryDataGridView.DataSource = ds.Tables[0];
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            //Use this to load the profit into the profit textbox
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            double costs = 0; //Will save costs to this
            double revenues = 0; //Will save revenues to this

            //Find costs
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlCost = "SELECT SUM(I.Buy_Cost * P.Quantity) FROM Purchase_Order P LEFT JOIN Ingredient I ON P.Ingredient_UPC = I.Ingredient_UPC";
            command = new SqlCommand(sqlCost, connection);
            datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                costs = Convert.ToDouble(datareader[0]);
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader

            costs = costs + 2000 + 7200;


            //Now find revs
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlRev = "SELECT SUM(Amount_Paid) FROM Sales_Order";
            command = new SqlCommand(sqlRev, connection);
            datareader = command.ExecuteReader();

            while (datareader.Read())
            {
                revenues = Convert.ToDouble(datareader[0]);
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
                                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Now fill the profit textbox
            profitTextBox.Text = "$" + Convert.ToString(revenues - costs);
            */
        }

        private void employeeReportComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = employeeReportComboBox.SelectedItem.ToString();

            //Distinguish how to filter the information with an if statement
            if(selectedItem == "All Employees")
            {
                //Load the datagridview with data on all employees
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var sql2 = "SELECT * FROM Employee";
                var da = new SqlDataAdapter(sql2, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                employeeDataGridView.DataSource = ds.Tables[0];
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else if(selectedItem == "Current Employees")
            {
                //Load the datagridview with data on only current employees
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var sql2 = "SELECT * FROM Employee WHERE Status = 'Active'";
                var da = new SqlDataAdapter(sql2, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                employeeDataGridView.DataSource = ds.Tables[0];
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else if(selectedItem == "Terminated Employees")
            {
                //Load the datagridview with data on only terminated employees
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var sql2 = "SELECT * FROM Employee WHERE Status = 'Terminated'";
                var da = new SqlDataAdapter(sql2, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                employeeDataGridView.DataSource = ds.Tables[0];
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else if(selectedItem == "Retired Employees")
            {
                //Load the datagridview with data on only retired employees
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var sql2 = "SELECT * FROM Employee WHERE Status = 'Retired'";
                var da = new SqlDataAdapter(sql2, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                employeeDataGridView.DataSource = ds.Tables[0];
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else
            {
                //Load the datagridview with data on only a specific selected employee
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var sql2 = "SELECT * FROM Employee WHERE First_Name = '" + employeeReportComboBox.Text +"'";
                var da = new SqlDataAdapter(sql2, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                employeeDataGridView.DataSource = ds.Tables[0];
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
        }

        private void customerProfileComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //The selected index from the customer combo box
            int selectedCustIndex = customerProfileComboBox.SelectedIndex;

            //The customer ID that corresponds to that index. "All customers" is index 0, so offset it by 1
            string selectedCustomerID = "0";
            if (selectedCustIndex > 0)
            {
                selectedCustomerID = parallelCustomerIDsList[selectedCustIndex - 1];
            }

            //Show the more info button and edit profile button if a specific customer is chosen
            if (selectedCustIndex != -1 && selectedCustIndex != 0)
            {
                moreCustomerDataButton.Visible = true;
                editCustProfileButton.Visible = true;
            }
            else
            {
                moreCustomerDataButton.Visible = false;
                editCustProfileButton.Visible = false;

            }


            //Fill the datagridview
            if (selectedCustIndex == 0)
            {
                //Populate the customer profile datagridview
                var sql2 = "SELECT * FROM Customer";
                var da = new SqlDataAdapter(sql2, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                customerDataGridView.DataSource = ds.Tables[0];
            }
            else
            {
                //Populate the customer profile datagridview
                var sql2 = "SELECT C.*," +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Ingredient1_UPC) as 'Ingredient 1', " +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Ingredient2_UPC) as 'Ingredient 2', " +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Ingredient3_UPC) as 'Ingredient 3', " +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Juice_Selection_UPC) as 'Juice Selection', " +
                    "S.Quantity, " +
                    "S.Amount, " +
                    "S.Amount_Paid " +
                    "FROM Customer C LEFT JOIN Sales_Order S ON C.Customer_ID = S.Customer_ID " +
                    "WHERE C.Customer_ID = " + (selectedCustomerID); //This way, it goes off ID and not name.. which there can be multiples of
                var da = new SqlDataAdapter(sql2, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                customerDataGridView.DataSource = ds.Tables[0];




                //Find the total amount spent by a customer
                connection = new SqlConnection(connectionstring);
                connection.Open(); //Opens the connection to the database
                string sql = "SELECT SUM(Amount_Paid) FROM Sales_Order WHERE Customer_ID = '" + selectedCustomerID + "'"; //Codinf in C# between the plusses
                command = new SqlCommand(sql, connection);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    customerSpendings = datareader[0].ToString();
                }
                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command
                datareader.Close(); //Closes the datareader
            }
        }

        private void moreCustomerDataButton_Click(object sender, EventArgs e)
        {
            //This section shows how much a customer has spent with us
            if (customerSpendings != "0" && customerSpendings != "")
            {
                MessageBox.Show("Total spent with us: $" + customerSpendings);
            }
            else
            {
                MessageBox.Show("Total spent with us: $0");
            }
        }

        private void salesTrendsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (salesTrendsComboBox.SelectedIndex == 0)
            {
                zeroSalesButton.Visible = false;
                zeroSalesLabel.Visible = false;

                //Populate the sales datagridview
                var sql = "SELECT S.Customer_ID, " +
                    "(SELECT First_Name FROM Customer WHERE Customer_ID = S.Customer_ID) AS Customer_First_Name, " +
                    "S.Employee_ID, " +
                    "(SELECT First_Name FROM Employee WHERE Employee_ID = S.Employee_ID) AS Employee_First_Name, " +
                    "S.Amount_Paid, S.Ingredient1_UPC, S.Ingredient2_UPC, S.Ingredient3_UPC, S.Juice_Selection_UPC " +
                    "FROM Sales_Order S LEFT JOIN Customer C ON S.Customer_ID = C.Customer_ID";
                var da = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                salesDataGridView.DataSource = ds.Tables[0];
            }
            else if(salesTrendsComboBox.SelectedIndex == 1)
            {
                zeroSalesButton.Visible = false;
                zeroSalesLabel.Visible = false;

                //Populate the sales datagridview
                var sql = "CREATE TABLE #Temporary_Table (Ingredient int, Quantity float) " +
                    "INSERT INTO #Temporary_Table SELECT Ingredient1_UPC, Quantity FROM Sales_Order " +
                    "INSERT INTO #Temporary_Table SELECT Ingredient2_UPC, Quantity FROM Sales_Order " +
                    "INSERT INTO #Temporary_Table SELECT Ingredient3_UPC, Quantity FROM Sales_Order " +
                    "INSERT INTO #Temporary_Table SELECT Juice_Selection_UPC, Quantity FROM Sales_Order " +
                    "CREATE Table #Temporary_Table2 (Ingredient int, quantity float) " +
                    "INSERT INTO #Temporary_Table2 SELECT Ingredient, SUM(Quantity) FROM #Temporary_Table GROUP BY Ingredient " +
                    "SELECT T.Ingredient AS 'Ingredient_UPC', (SELECT Name FROM Ingredient WHERE Ingredient_UPC = T.Ingredient) AS 'Name', T.Quantity " +
                    "FROM #Temporary_Table2 T LEFT JOIN Ingredient I ON T.Ingredient = I.Ingredient_UPC " +
                    "WHERE T.Quantity = (SELECT MAX(Quantity) FROM #Temporary_Table2)";
                var da = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                salesDataGridView.DataSource = ds.Tables[0];
            }
            else if (salesTrendsComboBox.SelectedIndex == 2)
            {
                zeroSalesButton.Visible = true;
                zeroSalesLabel.Visible = true;

                //Populate the sales datagridview
                var sql = "CREATE TABLE #Temporary_Table (Ingredient int, Quantity float) " +
                    "INSERT INTO #Temporary_Table SELECT Ingredient1_UPC, Quantity FROM Sales_Order " +
                    "INSERT INTO #Temporary_Table SELECT Ingredient2_UPC, Quantity FROM Sales_Order " +
                    "INSERT INTO #Temporary_Table SELECT Ingredient3_UPC, Quantity FROM Sales_Order " +
                    "INSERT INTO #Temporary_Table SELECT Juice_Selection_UPC, Quantity FROM Sales_Order " +
                    "CREATE Table #Temporary_Table2 (Ingredient int, quantity float) " +
                    "INSERT INTO #Temporary_Table2 SELECT Ingredient, SUM(Quantity) FROM #Temporary_Table GROUP BY Ingredient " +
                    "SELECT T.Ingredient AS 'Ingredient_UPC', (SELECT Name FROM Ingredient WHERE Ingredient_UPC = T.Ingredient) AS 'Name', T.Quantity " +
                    "FROM #Temporary_Table2 T LEFT JOIN Ingredient I ON T.Ingredient = I.Ingredient_UPC " +
                    "WHERE T.Quantity = (SELECT MIN(Quantity) FROM #Temporary_Table2)";
                var da = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                salesDataGridView.DataSource = ds.Tables[0];
            }
        }

        private void zeroSalesButton_Click(object sender, EventArgs e)
        {
            zeroSalesButton.Visible = false;
            zeroSalesLabel.Visible = false;

            //Populate the sales datagridview
            var sql = "CREATE TABLE #Temporary_Table (Ingredient int, Quantity float) " +
                "INSERT INTO #Temporary_Table SELECT Ingredient1_UPC, Quantity FROM Sales_Order " +
                "INSERT INTO #Temporary_Table SELECT Ingredient2_UPC, Quantity FROM Sales_Order " +
                "INSERT INTO #Temporary_Table SELECT Ingredient3_UPC, Quantity FROM Sales_Order " +
                "INSERT INTO #Temporary_Table SELECT Juice_Selection_UPC, Quantity FROM Sales_Order " +
                "SELECT Ingredient_UPC, Name FROM Ingredient WHERE Ingredient_UPC NOT IN (SELECT Ingredient FROM #Temporary_Table)";
            var da = new SqlDataAdapter(sql, connection);
            var ds = new DataSet();  //Dataset - basical a spreadsheet
            da.Fill(ds); //Take the data adapter and fill the dataset
            salesDataGridView.DataSource = ds.Tables[0];
        }

        private void revenueComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (revenueComboBox.SelectedIndex == 0)
            {
                connection = new SqlConnection(connectionstring);

                connection.Open(); //Opens the connection to the database
                string sql = "SELECT SUM(Amount_Paid) FROM Sales_Order";
                command = new SqlCommand(sql, connection);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    revenueTextBox.Text ="$" + Convert.ToString(datareader[0]);
                }
                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command
                datareader.Close(); //Closes the datareader
            }
        }

        private void expenseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (expenseComboBox.SelectedIndex == 0)
            {
                connection = new SqlConnection(connectionstring);

                connection.Open(); //Opens the connection to the database
                string sql = "SELECT SUM(I.Buy_Cost * P.Quantity) FROM Purchase_Order P LEFT JOIN Ingredient I ON P.Ingredient_UPC = I.Ingredient_UPC";
                command = new SqlCommand(sql, connection);
                datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    expenseTextBox.Text = "$" + Convert.ToString(datareader[0]);
                }
                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command
                datareader.Close(); //Closes the datareader
            }
            else if (expenseComboBox.SelectedIndex == 1)
            {
                expenseTextBox.Text = "$2,000.00";
            }
            else if (expenseComboBox.SelectedIndex == 2)
            {
                expenseTextBox.Text = "$7,200.00";
            }
        }

        private void editInvPanelCloseButton_Click(object sender, EventArgs e)
        {
            editInvPanel.Visible = false;
        }


        //This is a parallel list to hold UPCs of corresponding ingredients in the "updateInvComboBox"
        List<string> parallelUpdateInvList = new List<string>();

        private void editInvButton_Click(object sender, EventArgs e)
        {
            editInvPanel.Location = new Point(22, 25);
            editInvPanel.Width = 1084;
            editInvPanel.Height = 590;

            editInvPanel.Visible = true;

            loadIngredientNamesIntoEditCombos();
        }


        private void loadIngredientNamesIntoEditCombos()
        {
            //Clear the list to add items back into a fresh one
            parallelUpdateInvList.Clear();

            //Clear the comboboxes to have fresh items
            updateInvComboBox.Items.Clear();
            deleteInvComboBox.Items.Clear();

            //Use this to load ingredient names from the database into the update ingredient combo box and delete ingredient combo box
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlC = "SELECT Name, Ingredient_UPC FROM Ingredient";
            command = new SqlCommand(sqlC, connection);
            datareader = command.ExecuteReader();

            //Uploads ingredients into the ingredient combo box
            while (datareader.Read())
            {
                updateInvComboBox.Items.Add(datareader[0].ToString());
                deleteInvComboBox.Items.Add(datareader[0].ToString());
                parallelUpdateInvList.Add(datareader[1].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }






        private void updateInvButton_Click(object sender, EventArgs e)
        {
            int inv;
            bool updateInvIsInt = Int32.TryParse(updateQuantityTextBox.Text, out inv);

            if (updateInvComboBox.Text == "" || updateQuantityTextBox.Text == "" || updateInvIsInt == false)
            {
                MessageBox.Show("Enter values for inventory and quantity to be updated. Make sure the quantity entered is a whole number.");
            }
            else
            {
                //Update the inventory
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                connection = new SqlConnection(connectionstring);
                connection.Open(); //Opens the connection to the database


                int answer;
                string sql = "UPDATE Ingredient SET Quantity=@Q WHERE Ingredient_UPC=@UPC";


                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Q", updateQuantityTextBox.Text);
                command.Parameters.AddWithValue("@UPC", parallelUpdateInvList[updateInvComboBox.SelectedIndex]);

                answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                updateQuantityTextBox.Text = "";
                updateInvComboBox.Text = "";


                //Use this to refresh the inventory report with the updated inventory
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var sqlI = "SELECT Ingredient_UPC, Name, Quantity FROM Ingredient";
                var da = new SqlDataAdapter(sqlI, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                inventoryDataGridView.DataSource = ds.Tables[0];
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



                MessageBox.Show("Successfully Updated " + updateInvComboBox.Text);
            }
        }

        private void deleteInvButton_Click(object sender, EventArgs e)
        {
            if (deleteInvComboBox.SelectedIndex >= 0)
            {
                connection = new SqlConnection(connectionstring);
                connection.Open(); //Opens the connection to the database


                int answer;
                string sql = "DELETE FROM Ingredient WHERE Ingredient_UPC=@UPC";


                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@UPC", parallelUpdateInvList[deleteInvComboBox.SelectedIndex]);

                answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command


                deleteInvComboBox.Text = "";
                updateInvComboBox.Text = "";

                MessageBox.Show("Successfully deleted inventory item.");

                //Now refresh the comboboxes
                loadIngredientNamesIntoEditCombos();

                //Use this to refresh the inventory report with the updated inventory
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                var sqlI = "SELECT Ingredient_UPC, Name, Quantity FROM Ingredient";
                var da = new SqlDataAdapter(sqlI, connection);
                var ds = new DataSet();  //Dataset - basical a spreadsheet
                da.Fill(ds); //Take the data adapter and fill the dataset
                inventoryDataGridView.DataSource = ds.Tables[0];
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            }
            else
            {
                MessageBox.Show("Select an inventory item to delete.");
            }
        }

        private void addInvButton_Click(object sender, EventArgs e)
        {
            //Use this bit of code to ensure that numbers are entered for fields that require numbers
            double price;
            double cost;
            bool sellIsDouble = Double.TryParse(sellPriceTextBox.Text, out price);
            bool buyIsDouble = Double.TryParse(buyCostTextBox.Text, out cost);
            int qntty;
            bool quantityIsInt = Int32.TryParse(invQuantityInStockTextBox.Text, out qntty);
            double nutr; //Im not using these, just using them to catch the outs. So I can just keep sending the nutrition outs from the tryparses to this
            bool calsIsNum = Double.TryParse(invCaloriesTextBox.Text, out nutr);
            bool fatIsNum = Double.TryParse(invFatTextBox.Text, out nutr);
            bool carbsIsNum = Double.TryParse(invCarbsTextBox.Text, out nutr);
            bool proteinIsNum = Double.TryParse(invProteinTextBox.Text, out nutr);
            double msrmnt;
            bool measurementIsDouble = Double.TryParse(invMeasurementTextBox.Text, out msrmnt);



            if (invNameTextBox.Text != "" && invMeasurementTypeComboBox.SelectedIndex != -1 && invIsJuiceComboBox.SelectedIndex != -1 && invTypeComboBox.SelectedIndex != -1)
            {
                if (sellIsDouble && buyIsDouble && calsIsNum && fatIsNum && carbsIsNum && proteinIsNum && measurementIsDouble)
                {
                    if (quantityIsInt)
                    {
                        connection = new SqlConnection(connectionstring);
                        connection.Open(); //Opens the connection to the database


                        int answer;
                        string sql = "INSERT INTO Ingredient VALUES (@Name, @Measuremnt, @BCost, @Qntty, @Cals, @Fat, @Carbs, @Protein, @SPrice, @MeasuremntType, @IsJuice, @IType)"; //The @s are placeholders. Telling system that they will be seen later in the code


                        command = new SqlCommand(sql, connection);

                        //Connects the correct textbox data with what attribute they will be put into
                        command.Parameters.AddWithValue("@Name", invNameTextBox.Text);
                        command.Parameters.AddWithValue("@Measuremnt", invMeasurementTextBox.Text);
                        command.Parameters.AddWithValue("@BCost", buyCostTextBox.Text);
                        command.Parameters.AddWithValue("@Qntty", invQuantityInStockTextBox.Text);
                        command.Parameters.AddWithValue("@Cals", invCaloriesTextBox.Text);
                        command.Parameters.AddWithValue("@Fat", invFatTextBox.Text);
                        command.Parameters.AddWithValue("@Carbs", invCarbsTextBox.Text);
                        command.Parameters.AddWithValue("@Protein", invProteinTextBox.Text);
                        command.Parameters.AddWithValue("@SPrice", sellPriceTextBox.Text);
                        command.Parameters.AddWithValue("@MeasuremntType", invMeasurementTypeComboBox.Text);
                        command.Parameters.AddWithValue("@IsJuice", invIsJuiceComboBox.Text);
                        command.Parameters.AddWithValue("@IType", invTypeComboBox.Text);

                        answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

                        connection.Close(); //Closes the connection to the database. Don't want to leave it open
                        command.Dispose(); //Disposes of the command

                        MessageBox.Show("Successfully entered " + answer + " ingredient.");


                        invNameTextBox.Text = "";
                        invMeasurementTextBox.Text = "";
                        buyCostTextBox.Text = "";
                        invQuantityInStockTextBox.Text = "";
                        invCaloriesTextBox.Text = "";
                        invFatTextBox.Text = "";
                        invCarbsTextBox.Text = "";
                        invProteinTextBox.Text = "";
                        sellPriceTextBox.Text = "";
                        invMeasurementTypeComboBox.Text = "";
                        invIsJuiceComboBox.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Make sure that quantity is a whole number.");
                    }
                }
                else
                {
                    MessageBox.Show("Make sure that numeric values are entered for fields requireing them.");
                }
            }
            else
            {
                MessageBox.Show("Make sure a value is entered for every field.");

            }


            //Now refresh the comboboxes
            loadIngredientNamesIntoEditCombos();

            //Use this to refresh the inventory report with the updated inventory
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var sqlI = "SELECT Ingredient_UPC, Name, Quantity FROM Ingredient";
            var da = new SqlDataAdapter(sqlI, connection);
            var ds = new DataSet();  //Dataset - basical a spreadsheet
            da.Fill(ds); //Take the data adapter and fill the dataset
            inventoryDataGridView.DataSource = ds.Tables[0];
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void editCustProfileButton_Click(object sender, EventArgs e)
        {
            editCustProfilePanel.Visible = true;

            editCustProfilePanel.Location = new Point(22, 25);
            editCustProfilePanel.Width = 1084;
            editCustProfilePanel.Height = 590;

            //Insert data into the fields in the edit customer panel
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);
            connection.Open(); //Opens the connection to the database
            string sql = "SELECT First_Name, Last_Name, Phone_Number, Email, Birthday, Age, Credit_Card_Number, City, Gender, Postal, Street, Zip_Code, Frequent_Customer FROM Customer WHERE Customer_ID = " + parallelCustomerIDsList[customerProfileComboBox.SelectedIndex - 1];
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Populate the textboxes
            while (datareader.Read())
            {
                editCustFirstNameTB.Text = datareader[0].ToString();
                editCustLastNameTB.Text = datareader[1].ToString();
                editCustPhoneNumTB.Text = datareader[2].ToString();
                editCustEmailTB.Text = datareader[3].ToString();
                editCustDateTB.Text = datareader[4].ToString();
                editCustAgeTB.Text = datareader[5].ToString();
                editCustCCNTB.Text = datareader[6].ToString();
                editCustCityTB.Text = datareader[7].ToString();
                editCustGenderCB.Text = datareader[8].ToString();
                editCustPostalTB.Text = datareader[9].ToString();
                editCustStreetTB.Text = datareader[10].ToString();
                editCustZipTB.Text = datareader[11].ToString();
                editCustFrequentCB.Text = datareader[12].ToString();
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            //Fill in the Customer ID textbox
            editCustIDTB.Text = parallelCustomerIDsList[customerProfileComboBox.SelectedIndex - 1];
        }

        private void button5_Click(object sender, EventArgs e) //This is the back button on the edit customer panel. Forgot to rename it
        {
            editCustProfilePanel.Visible = false;

            //Reload the customer's data into the customer datagridview
            var sql2 = "SELECT C.*," +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Ingredient1_UPC) as 'Ingredient 1', " +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Ingredient2_UPC) as 'Ingredient 2', " +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Ingredient3_UPC) as 'Ingredient 3', " +
                    "(SELECT Name FROM Ingredient WHERE Ingredient_UPC = S.Juice_Selection_UPC) as 'Juice Selection', " +
                    "S.Quantity, " +
                    "S.Amount, " +
                    "S.Amount_Paid " +
                    "FROM Customer C LEFT JOIN Sales_Order S ON C.Customer_ID = S.Customer_ID " +
                    "WHERE C.Customer_ID = " + (parallelCustomerIDsList[customerProfileComboBox.SelectedIndex - 1]); //This way, it goes off ID and not name.. which there can be multiples of
            var da = new SqlDataAdapter(sql2, connection);
            var ds = new DataSet();  //Dataset - basical a spreadsheet
            da.Fill(ds); //Take the data adapter and fill the dataset
            customerDataGridView.DataSource = ds.Tables[0];
        }

        private void editCustUpdateButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionstring);
            connection.Open(); //Opens the connection to the database


            int answer;
            string sql = "UPDATE Customer SET First_Name=@FName, Last_Name=@LName, Phone_Number=@PNum, Email=@Email, Birthday=@BDay, Age=@Age, Credit_Card_Number=@CCN, City=@City, Gender=@Gender, Postal=@Postal, Street=@Str, Zip_Code=@Zip, Frequent_Customer=@Freq WHERE Customer_ID= " + editCustIDTB.Text;


            command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@FName", editCustFirstNameTB.Text);
            command.Parameters.AddWithValue("@LName", editCustLastNameTB.Text);
            command.Parameters.AddWithValue("@PNum", editCustPhoneNumTB.Text);
            command.Parameters.AddWithValue("@Email", editCustEmailTB.Text);
            command.Parameters.AddWithValue("@BDay", editCustDateTB.Text);
            command.Parameters.AddWithValue("@Age", editCustAgeTB.Text);
            command.Parameters.AddWithValue("@CCN", editCustCCNTB.Text);
            command.Parameters.AddWithValue("@City", editCustCityTB.Text);
            command.Parameters.AddWithValue("@Gender", editCustGenderCB.Text);
            command.Parameters.AddWithValue("@Postal", editCustPostalTB.Text);
            command.Parameters.AddWithValue("@Str", editCustStreetTB.Text);
            command.Parameters.AddWithValue("@Zip", editCustZipTB.Text);
            command.Parameters.AddWithValue("@Freq", editCustFrequentCB.Text);


            answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command

            MessageBox.Show("Successfully updated " + answer + " customer.");
        }

        private void selectDateButton_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
        }


        /// This is all to find the age and birthday of a customer creating an account
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Find the current year, month, and day
        int todaysDay = DateTime.Now.Day;
        int todaysMonth = DateTime.Now.Month;
        int todaysYear = DateTime.Now.Year;

        //Variables to save the customer's selected birth year, month, and day
        int selectedDay;// = selectedDate.Day;
        int selectedMonth;// = selectedDate.Month;
        int selectedYear;// = selectedDate.Year;

        //Variables to save how many years the current date is ahead of the selected one. Do the same for month and day
        int yearsPassed;// = todaysYear - selectedYear;
        int monthsPassed;// = todaysMonth - selectedMonth;
        int daysPassed;// = todaysDay - selectedDay;

        //Variable to save the age
        int customerAge;
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //Find the customer's selected birth year, month, and day
            DateTime selectedDate = monthCalendar1.SelectionRange.Start;
            selectedDay = selectedDate.Day;
            selectedMonth = selectedDate.Month;
            selectedYear = selectedDate.Year;

            //find how many years the current date is ahead of the selected one. Do the same for month and day
            yearsPassed = todaysYear - selectedYear;
            monthsPassed = todaysMonth - selectedMonth;
            daysPassed = todaysDay - selectedDay;

            //This bit of code calculates the age. It checks to see if it is a full x years ahead, and adjusted according to month and day placement
            customerAge = yearsPassed;
            if (monthsPassed < 0)
            {
                customerAge = customerAge - 1;
            }
            if ((monthsPassed == 0) && (daysPassed < 0))
            {
                customerAge = customerAge - 1;
            }


            //This is just to make sure we format the date correctly for the database. EX: 08 instead of 8
            bool dayNeeds0 = false;
            bool monthNeeds0 = false;
            if (selectedDay < 10)
            {
                dayNeeds0 = true;
            }

            if (selectedMonth < 10)
            {
                monthNeeds0 = true;
            }


            if (dayNeeds0 == false && monthNeeds0 == false)
            {
                editCustDateTB.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == true && monthNeeds0 == false)
            {
                editCustDateTB.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == false && monthNeeds0 == true)
            {
                editCustDateTB.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == true && monthNeeds0 == true)
            {
                editCustDateTB.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }

            editCustAgeTB.Text = customerAge.ToString();
        }


        //This is a parallel list to hold IDs of corresponding Employees in the edit employee combo box
        List<string> parallelEditEmpList = new List<string>();

        private void editEmpButton_Click(object sender, EventArgs e)
        {
            editEmpPanel.Visible = true;

            editEmpPanel.Location = new Point(22, 25);
            editEmpPanel.Width = 1084;
            editEmpPanel.Height = 590;


            FillEditEmpPanelCombos();
            /*
            //fill the update emp and delete emp comboboxes with employees
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT First_Name, Employee_ID FROM Employee";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Uploads employees into the employee combo box
            while (datareader.Read())
            {
                updateEmpNameCB.Items.Add(datareader[0].ToString());
                delEmpNameCB.Items.Add(datareader[0].ToString());
                parallelEditEmpList.Add(datareader[1].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            */
        }


        private void FillEditEmpPanelCombos()
        {
            //First clear the combo boxes so we have fresh ones to add data to
            updateEmpNameCB.Items.Clear();
            delEmpNameCB.Items.Clear();

            //Now clear the parallel list so we have a clean one to add data to
            parallelEditEmpList.Clear();


            //fill the update emp and delete emp comboboxes with employees
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT First_Name, Employee_ID FROM Employee";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Uploads employees into the employee combo box
            while (datareader.Read())
            {
                updateEmpNameCB.Items.Add(datareader[0].ToString());
                delEmpNameCB.Items.Add(datareader[0].ToString());
                parallelEditEmpList.Add(datareader[1].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }



        private void updateEmpNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Insert data into the fields for editing an employee
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);
            connection.Open(); //Opens the connection to the database
            string sql = "SELECT First_Name, Last_Name, Address, Phone_Number, Email, Status, Type, Hourly_Rate, Hire_Date FROM Employee WHERE Employee_ID = " + parallelEditEmpList[updateEmpNameCB.SelectedIndex];
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Populate the textboxes
            while (datareader.Read())
            {
                editEmpFNameTB.Text = datareader[0].ToString();
                editEmpLNameTB.Text = datareader[1].ToString();
                editEmpAddyTB.Text = datareader[2].ToString();
                editEmpPNumbTB.Text = datareader[3].ToString();
                editEmpEmailTB.Text = datareader[4].ToString();
                editEmpStatusCB.Text = datareader[5].ToString();
                editEmpTypeCB.Text = datareader[6].ToString();
                editEmpHRateTB.Text = datareader[7].ToString();
                editEmpHDateTB.Text = datareader[8].ToString();
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            //Put a value into the edit emp ID textbox
            editEmpIDTB.Text = parallelEditEmpList[updateEmpNameCB.SelectedIndex];
        }

        private void editEmpDateButton_Click(object sender, EventArgs e)
        {
            editEmpMonthCalendar.Visible = true;
            editEmpHideCalendarButton.Visible = true;
        }

        private void editEmpMonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            //Save the selected day, month, and year to variables
            int selectedDay = editEmpMonthCalendar.SelectionRange.Start.Day;
            int selectedMonth = editEmpMonthCalendar.SelectionRange.Start.Month;
            int selectedYear = editEmpMonthCalendar.SelectionRange.Start.Year;

            //This is just to make sure we format the date correctly for the database. EX: 08 instead of 8
            bool dayNeeds0 = false;
            bool monthNeeds0 = false;
            if (selectedDay < 10)
            {
                dayNeeds0 = true;
            }

            if (selectedMonth < 10)
            {
                monthNeeds0 = true;
            }

            //Write the date into the date textbox
            if (dayNeeds0 == false && monthNeeds0 == false)
            {
                editEmpHDateTB.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == true && monthNeeds0 == false)
            {
                editEmpHDateTB.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == false && monthNeeds0 == true)
            {
                editEmpHDateTB.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == true && monthNeeds0 == true)
            {
                editEmpHDateTB.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
        }


        //This function can be called to refresh the employee datagridview... Use it when updateing/deleting/adding new employees
        private void RefreshEmployeeReportComboBox()
        {
            //Clear it out first
            employeeReportComboBox.Items.Clear();

            //Add the non-name items first
            employeeReportComboBox.Items.Add("All Employees");
            employeeReportComboBox.Items.Add("Current Employees");
            employeeReportComboBox.Items.Add("Terminated Employees");
            employeeReportComboBox.Items.Add("Retired Employees");

            //Use this to load employee names from the database into the Employee Report Combo Box
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT First_Name FROM Employee";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Uploads employees into the employee combo box
            while (datareader.Read())
            {
                employeeReportComboBox.Items.Add(datareader[0].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }


        private void updateEmpButton_Click(object sender, EventArgs e)
        {
            double x;
            bool HRateIsDouble = Double.TryParse(editEmpHRateTB.Text, out x);

            if (HRateIsDouble)
            {
                connection = new SqlConnection(connectionstring);
                connection.Open(); //Opens the connection to the database


                int answer;
                string sql = "UPDATE Employee SET First_Name=@FName, Last_Name=@LName, Address=@Addy, Phone_Number=@PNum, Email=@Email, Status=@Status, Type=@Type, Hourly_Rate=@HRate, Hire_Date=@HDate WHERE Employee_ID= " + editEmpIDTB.Text;


                command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@FName", editEmpFNameTB.Text);
                command.Parameters.AddWithValue("@LName", editEmpLNameTB.Text);
                command.Parameters.AddWithValue("@Addy", editEmpAddyTB.Text);
                command.Parameters.AddWithValue("@PNum", editEmpPNumbTB.Text);
                command.Parameters.AddWithValue("@Email", editEmpEmailTB.Text);
                command.Parameters.AddWithValue("@Status", editEmpStatusCB.Text);
                command.Parameters.AddWithValue("@Type", editEmpTypeCB.Text);
                command.Parameters.AddWithValue("@HRate", editEmpHRateTB.Text);
                command.Parameters.AddWithValue("@HDate", editEmpHDateTB.Text);


                answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command

                MessageBox.Show("Successfully updated " + answer + " employee.");

                //Refresh the employee report combobox so that the new employees can be seen
                RefreshEmployeeReportComboBox();

                //Now fill the combos on this panel with fresh employee data
                FillEditEmpPanelCombos();
            }
            else
            {
                MessageBox.Show("Make sure the hourly rate is a number.");
            }
        }

        private void editEmpBackButton_Click(object sender, EventArgs e)
        {
            editEmpPanel.Visible = false;
        }

        private void addEmpDateButton_Click(object sender, EventArgs e)
        {
            addEmpMonthCalendar.Visible = true;
            addEmpHideCalendarButton.Visible = true;
        }

        private void addEmpMonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            //Save the selected day, month, and year to variables
            int selectedDay = addEmpMonthCalendar.SelectionRange.Start.Day;
            int selectedMonth = addEmpMonthCalendar.SelectionRange.Start.Month;
            int selectedYear = addEmpMonthCalendar.SelectionRange.Start.Year;

            //This is just to make sure we format the date correctly for the database. EX: 08 instead of 8
            bool dayNeeds0 = false;
            bool monthNeeds0 = false;
            if (selectedDay < 10)
            {
                dayNeeds0 = true;
            }

            if (selectedMonth < 10)
            {
                monthNeeds0 = true;
            }

            //Write the date into the date textbox
            if (dayNeeds0 == false && monthNeeds0 == false)
            {
                addEmpHDateTB.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == true && monthNeeds0 == false)
            {
                addEmpHDateTB.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == false && monthNeeds0 == true)
            {
                addEmpHDateTB.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == true && monthNeeds0 == true)
            {
                addEmpHDateTB.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
        }

        private void addEmpButton_Click(object sender, EventArgs e)
        {
            double x;
            bool HRateIsDouble = Double.TryParse(addEmpHRateTB.Text, out x);

            if (HRateIsDouble)
            {
                connection = new SqlConnection(connectionstring);
                connection.Open(); //Opens the connection to the database


                int answer;
                string sql = "INSERT INTO Employee VALUES ((SELECT (MAX(Employee_ID) + 1) FROM Employee), @FName, @LName, @Addy, @PNum, @Email, @Status, @Type, @HRate, @HDate, @PWord)"; //The @s are placeholders. Telling system that they will be seen later in the code


                command = new SqlCommand(sql, connection);

                //Connects the correct textbox data with what attribute they will be put into
                command.Parameters.AddWithValue("@FName", addEmpFNameTB.Text);
                command.Parameters.AddWithValue("@LName", addEmpLNameTB.Text);
                command.Parameters.AddWithValue("@Addy", addEmpAddyTB.Text);
                command.Parameters.AddWithValue("@PNum", AddEmpPNumTB.Text);
                command.Parameters.AddWithValue("@Email", addEmpEmailTB.Text);
                command.Parameters.AddWithValue("@Status", addEmpStatusCB.Text);
                command.Parameters.AddWithValue("@Type", addEmpTypeCB.Text);
                command.Parameters.AddWithValue("@HRate", addEmpHRateTB.Text);
                command.Parameters.AddWithValue("@HDate", addEmpHDateTB.Text);
                command.Parameters.AddWithValue("@PWord", addEmpPWordTB.Text);

                answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command

                MessageBox.Show("Employee Added.");

                //Clear the textboxes after the employee is added
                addEmpFNameTB.Text = "";
                addEmpLNameTB.Text = "";
                addEmpAddyTB.Text = "";
                AddEmpPNumTB.Text = "";
                addEmpEmailTB.Text = "";
                addEmpStatusCB.Text = "";
                addEmpTypeCB.Text = "";
                addEmpHRateTB.Text = "";
                addEmpHDateTB.Text = "";
                addEmpPWordTB.Text = "";

                //Refresh the employee report combobox so that the new employees can be seen
                RefreshEmployeeReportComboBox();

                //Now fill the combos on this panel with fresh employee data
                FillEditEmpPanelCombos();
            }
            else
            {
                MessageBox.Show("Make sure the hourly rate is a number.");
            }
        }

        private void editEmpHideCalendarButton_Click(object sender, EventArgs e)
        {
            editEmpMonthCalendar.Visible = false;
            editEmpHideCalendarButton.Visible = false;
        }

        private void addEmpHideCalendarButton_Click(object sender, EventArgs e)
        {
            addEmpMonthCalendar.Visible = false;
            addEmpHideCalendarButton.Visible = false;
        }

        private void delEmpNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Put a value into the delete emp ID textbox
            delEmpIDTB.Text = parallelEditEmpList[delEmpNameCB.SelectedIndex];
        }

        private void delEmpButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionstring);
            connection.Open(); //Opens the connection to the database


            int answer;
            string sql = "DELETE FROM Employee WHERE Employee_ID=@EID";


            command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@EID", delEmpIDTB.Text);

            answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command


            delEmpNameCB.Text = "";
            delEmpIDTB.Text = "";

            MessageBox.Show("Successfully deleted employee.");

            //Refresh the employee report combobox so that the new employees can be seen
            RefreshEmployeeReportComboBox();

            //Now fill the combos on this panel with fresh employee data
            FillEditEmpPanelCombos();
        }

        private void OrderButton_Click(object sender, EventArgs e)
        {
            //Make sure quantity is an int
            int x;
            bool qIsInt = int.TryParse(ingredientQuantityTextBox.Text, out x);

            if (orderIngredientComboBox.SelectedIndex >= 0 && VendorIDComboBox.SelectedIndex >= 0 && ingredientQuantityTextBox.Text != "")
            {
                if (qIsInt)
                {
                    //a/////////////////////////////////////////
                    connection = new SqlConnection(connectionstring);
                    connection.Open();

                    int answer;
                    string sql = "INSERT INTO Purchase_Order VALUES (@Employee_ID, @Vendor_ID, @Ingredient_UPC, @Quantity )";

                    command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Employee_ID", employeeID);
                    command.Parameters.AddWithValue("@Ingredient_UPC", ParalellIngredientList[orderIngredientComboBox.SelectedIndex]);
                    command.Parameters.AddWithValue("@Quantity", ingredientQuantityTextBox.Text);
                    command.Parameters.AddWithValue("@Vendor_ID", ParalellVendorList[VendorIDComboBox.SelectedIndex]);



                    answer = command.ExecuteNonQuery();

                    connection.Close();
                    command.Dispose();

                    string orderText1 = "Successfully entered " + answer + "order";
                    //a////////////////////////////////////////



                    //Now update the inventory
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    connection = new SqlConnection(connectionstring);
                    connection.Open(); //Opens the connection to the database

                    int answerI;
                    string sqlI = "UPDATE Ingredient SET Quantity = ((SELECT Quantity FROM Ingredient WHERE Ingredient_UPC = @UPC) + @Qcmb) WHERE Ingredient_UPC = @UPC2";


                    command = new SqlCommand(sqlI, connection);

                    command.Parameters.AddWithValue("@UPC", ParalellIngredientList[orderIngredientComboBox.SelectedIndex]);
                    command.Parameters.AddWithValue("@UPC2", ParalellIngredientList[orderIngredientComboBox.SelectedIndex]);
                    command.Parameters.AddWithValue("@Qcmb", ingredientQuantityTextBox.Text);

                    answerI = command.ExecuteNonQuery(); //Loading data to the database -- write to the database

                    connection.Close(); //Closes the connection to the database. Don't want to leave it open
                    command.Dispose(); //Disposes of the command

                    MessageBox.Show(orderText1 + " and updated inventory quantity.");
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else
                {
                    MessageBox.Show("Make sure the quantity entered is a whole number.");

                }
            }
            else
            {
                MessageBox.Show("Make sure to enter the required information.");
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            Close();
        }

        //This string holds the item type that is chosen by the customer when ordering. This is what lets specific vendors be chosen based on type. Match the vendor with the variable saved here
        string itemType = "0";
        private void orderIngredientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT Item_Type FROM Ingredient Where Ingredient_UPC = " + ParalellIngredientList[orderIngredientComboBox.SelectedIndex];
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();


            while (datareader.Read())
            {
                itemType = (datareader[0].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader



            //Clear the parallel vendor list and combo box
            ParalellVendorList.Clear();
            VendorIDComboBox.Items.Clear();
            VendorIDComboBox.Text = "";

            //Now fill the vendor combo box with vendors that the selected ingredient could be purchased from
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sqlv = "SELECT Name, Vendor_ID FROM Vendor WHERE Item_Type = '" + itemType + "'";
            command = new SqlCommand(sqlv, connection);
            datareader = command.ExecuteReader();


            while (datareader.Read())
            {
                VendorIDComboBox.Items.Add(datareader[0].ToString());
                ParalellVendorList.Add(datareader[1].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            Close();
        }
    }
}