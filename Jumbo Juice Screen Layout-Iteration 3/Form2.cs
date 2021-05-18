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
    public partial class Form2 : Form
    {
        //Use this to connect to the database
        ////////////////////////////////////////////////////////////////////////////////////
        string connectionstring = "Data Source=essql1.walton.uark.edu;Initial Catalog=ISYS4283Team21;User ID=ISYS4283Team21;Password=KY55kzb$";
        SqlConnection connection; //Function to open an sql database
        SqlCommand command; //Used to execute sql statements I think???
        SqlDataReader datareader;
        ////////////////////////////////////////////////////////////////////////////////////


        //Variable to hold the custoemr who logged in
        string customerID;

        //Variable holding if the customer is a frequent
        string isFrequent;



        //This is a list that holds the selected ingredients. Used to add the items to an sql query
        List<string> selectedIngredientsList = new List<string>();

        //This variable holds the selected juice to use in sql querries
        string selectedJuice;

        //This variable holds the cost of the drink for when the customer checks out
        double drinkCost = 0.0;

        //This variable holds the total cost of the order... found by multiplying the drink cost by the quantity ordered
        double totalCost = 0.0;




        public Form2(string customer, string frequent)
        {
            InitializeComponent();
            //Set the customer ID to the ID selected in form 1 as well as his/her frequency status
            customerID = customer;
            isFrequent = frequent;
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            if ((ingredientsCheckedListBox.CheckedItems.Count == 3) && (juiceListBox.SelectedIndex != -1))
            {
                OrderPanel.Visible = false;
                nutritionPanel.Visible = false;
                checkoutPanel.Visible = true;

                //Set the default number of drinks to 1... index 0
                quantityComboBox.SelectedIndex = 0;


                //Save the ingredients selected in the ingredient combo box into variables to use in a sql statement
                selectedIngredientsList.Clear(); //Clear it first so old values aren't kept
                for (int x = 0; x < ingredientsCheckedListBox.CheckedItems.Count; x++)
                {
                    //Add selected items to the list to hold them
                    selectedIngredientsList.Add(ingredientsCheckedListBox.CheckedItems[x].ToString());
                }

                //Save the selected juice to be used in a sql query
                selectedJuice = juiceListBox.SelectedItem.ToString();


                //Use the if/else statement to check if the customer is a frequent or not. Update pricing depending on the status
                if (isFrequent != "True")
                {
                    //code for not a frequent
                    //Use this to load the price of the drink into the total cost text box
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    connection = new SqlConnection(connectionstring);

                    connection.Open(); //Opens the connection to the database
                    string sql = "SELECT SUM(Sell_Price) FROM Ingredient WHERE Name = '" + selectedIngredientsList[0] + "' OR Name = '" + selectedIngredientsList[1] + "' OR Name = '" + selectedIngredientsList[2] + "' OR Name = '" + selectedJuice + "'";
                    command = new SqlCommand(sql, connection);
                    datareader = command.ExecuteReader();

                    //Save the drink cost to a variable
                    while (datareader.Read())
                    {
                        drinkCost = Convert.ToDouble(datareader[0]);
                    }
                    connection.Close(); //Closes the connection to the database. Don't want to leave it open
                    command.Dispose(); //Disposes of the command
                    datareader.Close(); //Closes the datareader

                    //This function is used to set the total cost textbox to the correct price
                    refreshTotalCostTextBox();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
                else
                {
                    //code for is a frequent
                    perksPanel.Visible = true;
                    //Use this to load the price of the drink into the total cost text box
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    string tempCost = "0"; //Use this to hold the cost, give it a discount, then put it in the total cost textbox
                    connection = new SqlConnection(connectionstring);

                    connection.Open(); //Opens the connection to the database
                    string sql = "SELECT SUM(Sell_Price) FROM Ingredient WHERE Name = '" + selectedIngredientsList[0] + "' OR Name = '" + selectedIngredientsList[1] + "' OR Name = '" + selectedIngredientsList[2] + "' OR Name = '" + selectedJuice + "'";
                    command = new SqlCommand(sql, connection);
                    datareader = command.ExecuteReader();

                    //Adds items to the ingredients list
                    while (datareader.Read())
                    {
                        tempCost = datareader[0].ToString();
                    }
                    connection.Close(); //Closes the connection to the database. Don't want to leave it open
                    command.Dispose(); //Disposes of the command
                    datareader.Close(); //Closes the datareader

                    Double discountedCost = (Convert.ToDouble(tempCost)) - ((Convert.ToDouble(tempCost)) * 0.15);
                    drinkCost = discountedCost;
                    refreshTotalCostTextBox();
                    //totalCostTextBox.Text = "$" + discountedCost.ToString();
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                }
            }
            else
            {
                MessageBox.Show("Select 3 ingredients and a juice to finish your drink and checkout.");
            }


        }



        private void nutritionButton_Click(object sender, EventArgs e)
        {
            if ((ingredientsCheckedListBox.CheckedItems.Count == 3) && (juiceListBox.SelectedIndex != -1))
            {
                OrderPanel.Visible = false;
                checkoutPanel.Visible = false;
                nutritionPanel.Visible = true;

                //Save the ingredients selected in the ingredient combo box into variables to use in a sql statement
                selectedIngredientsList.Clear(); //Clear it first so old values aren't kept
                for (int x = 0; x < ingredientsCheckedListBox.CheckedItems.Count; x++)
                {
                    //Add selected items to the list to hold them
                    selectedIngredientsList.Add(ingredientsCheckedListBox.CheckedItems[x].ToString());
                }

                //Save the selected juice to be used in a sql query
                selectedJuice = juiceListBox.SelectedItem.ToString();

                caloriesTextBox.Text = findNutritionFacts("Calories") + " calories";
                carbsTextBox.Text = findNutritionFacts("Carbs") + " grams";
                fatsTextBox.Text = findNutritionFacts("Fat") + " grams";
                proteinTextBox.Text = findNutritionFacts("Protein") + " grams";
            }
            else
            {
                MessageBox.Show("Select 3 ingredients and a juice to finish your drink and view its nutrition facts.");
            }
        }

        private string findNutritionFacts(string nutritionElement)
        {
            string amount = "0";

            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT SUM(" + nutritionElement + ") FROM Ingredient WHERE Name = '" + selectedIngredientsList[0] + "' OR Name = '" + selectedIngredientsList[1] + "' OR Name = '" + selectedIngredientsList[2] + "' OR Name = '" + selectedJuice + "'";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Adds items to the ingredients list
            while (datareader.Read())
            {
                amount = datareader[0].ToString();
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader

            return amount;
        }



        private void backButton_Click(object sender, EventArgs e)
        {
            OrderPanel.Visible = true;
            checkoutPanel.Visible = false;
            nutritionPanel.Visible = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            OrderPanel.Visible = true;
            checkoutPanel.Visible = false;
            nutritionPanel.Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OrderPanel.Visible = true;
            checkoutPanel.Visible = false;
            nutritionPanel.Visible = false;


            //Use this to load data from the database into the ingredients checkedlistbox
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql = "SELECT Name FROM Ingredient WHERE Is_Juice != 'True' OR Is_Juice IS NULL";
            command = new SqlCommand(sql, connection);
            datareader = command.ExecuteReader();

            //Adds items to the ingredients list
            while (datareader.Read())
            {
                ingredientsCheckedListBox.Items.Add(datareader[0].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



            //Use this to load data from the database into the juices checkedlistbox
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql2 = "SELECT Name FROM Ingredient WHERE Is_Juice = 'True'";
            command = new SqlCommand(sql2, connection);
            datareader = command.ExecuteReader();

            //Adds juices to the juice list
            while (datareader.Read())
            {
                juiceListBox.Items.Add(datareader[0].ToString());
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        }







        //Delete this function later!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private void ingredientsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if(ingredientsCheckedListBox.CheckedItems.Count == 3)
            {
                MessageBox.Show(ingredientsCheckedListBox.SelectedIndex.ToString());
                ingredientsCheckedListBox.SetItemChecked(ingredientsCheckedListBox.SelectedIndex, false);
            }*/
        }






        private void ingredientsCheckedListBox_Click(object sender, EventArgs e)
        {
            //Check to see if more than 3 items were selected. If there are, remove the last selected item
            if ((ingredientsCheckedListBox.CheckedItems.Count >= 3) && (ingredientsCheckedListBox.GetItemChecked(ingredientsCheckedListBox.SelectedIndex) == false))
            {
                MessageBox.Show("You can select a maximum of 3 items to put in your smoothie!");
                if (ingredientsCheckedListBox.CheckedItems.Count > 3)
                {
                    ingredientsCheckedListBox.SetItemChecked(ingredientsCheckedListBox.SelectedIndex, false);
                }
            }
        }



        //Function to find the quantity of ingredients in stock that are on the customer's order
        private int findQuantity(string ingredientName)
        {
            int ingredientQuantity = 0;


            connection = new SqlConnection(connectionstring);

            connection.Open(); //Opens the connection to the database
            string sql2 = "SELECT Quantity FROM Ingredient WHERE Name = '" + ingredientName + "'";
            command = new SqlCommand(sql2, connection);
            datareader = command.ExecuteReader();

            //Adds juices to the juice list
            while (datareader.Read())
            {
                ingredientQuantity = (Convert.ToInt32(datareader[0]));
            }
            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command
            datareader.Close(); //Closes the datareader

            return ingredientQuantity;
        }




        //Function to update the inventory quantity of items purchased
        private void updateInventoryQuantities(string UPC)
        {
            //MessageBox.Show("DELETE LATER: " + UPC + " with quantity chosen of " + quantityComboBox.Text);   //Message for testing purposes

            connection = new SqlConnection(connectionstring);
            connection.Open(); //Opens the connection to the database

            int answer;
            string sql = "UPDATE Ingredient SET Quantity = ((SELECT Quantity FROM Ingredient WHERE Ingredient_UPC = @UPC) - @Qcmb) WHERE Ingredient_UPC = @UPC2";


            command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@UPC", UPC);
            command.Parameters.AddWithValue("@UPC2", UPC);
            command.Parameters.AddWithValue("@Qcmb", quantityComboBox.Text);

            answer = command.ExecuteNonQuery(); //Loading data to the database -- write to the database

            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command

            //MessageBox.Show("DELETE LATER: Inventory is updated");  //Message for testing purposes
        }




        private void submitPaymentutton_Click(object sender, EventArgs e)
        {
            if(cardInfoTextBox.Text != "") //Make sure something is entered in the card information textbox
            {


                //Set to false if there aren't enough ingredients in stock to fulfill the order
                bool enoughInStock = true;

                //Find the quantities of items in stock to ensure there are enough to sell
                int ingredient1Quantity = findQuantity(selectedIngredientsList[0]);
                int ingredient2Quantity = findQuantity(selectedIngredientsList[1]);
                int ingredient3Quantity = findQuantity(selectedIngredientsList[2]);
                int juiceQuantity = findQuantity(selectedJuice);
                //MessageBox.Show("DELETE LATER: " + ingredient1Quantity.ToString() + " " + ingredient2Quantity.ToString() + " " + ingredient3Quantity.ToString() + " " + juiceQuantity.ToString());  //Used for testing

                if ((ingredient1Quantity - Convert.ToInt32(quantityComboBox.Text)) < 0)
                {
                    enoughInStock = false;
                    MessageBox.Show("Not enough " + selectedIngredientsList[0] + " in stock.");
                }
                
                if ((ingredient2Quantity - Convert.ToInt32(quantityComboBox.Text)) < 0)
                {
                    enoughInStock = false;
                    MessageBox.Show("Not enough " + selectedIngredientsList[1] + " in stock.");
                }

                if ((ingredient3Quantity - Convert.ToInt32(quantityComboBox.Text)) < 0)
                {
                    enoughInStock = false;
                    MessageBox.Show("Not enough " + selectedIngredientsList[2] + " in stock.");
                }

                if ((juiceQuantity - Convert.ToInt32(quantityComboBox.Text)) < 0)
                {
                    enoughInStock = false;
                    MessageBox.Show("Not enough " + selectedJuice + " in stock.");
                }



                //If there are enouh ingredients in stock, create a sales order
                if (enoughInStock == true)
                {
                    connection = new SqlConnection(connectionstring);
                    connection.Open(); //Opens the connection to the database


                    int answer;
                    string sql = "INSERT INTO Sales_Order VALUES (@CID," +
                        "(SELECT TOP 1 Employee_ID FROM Employee WHERE Status = 'Active' ORDER BY newid())," + //This will select a random active employee to fill the order
                        "@Quantity, @Amt, @AmtPaid," +
                        "(SELECT Ingredient_UPC FROM Ingredient WHERE Name = '" + selectedIngredientsList[0] + "')," + //subquerry to find the ingredients UPC
                        "(SELECT Ingredient_UPC FROM Ingredient WHERE Name = '" + selectedIngredientsList[1] + "')," + //subquerry to find the ingredients UPC
                        "(SELECT Ingredient_UPC FROM Ingredient WHERE Name = '" + selectedIngredientsList[2] + "')," + //subquerry to find the ingredients UPC
                        "(SELECT Ingredient_UPC FROM Ingredient WHERE Name = '" + selectedJuice + "'))"; //subquerry to find the ingredients UPC


                    command = new SqlCommand(sql, connection);

                    //Connects the correct textbox data with what attribute they will be put into
                    command.Parameters.AddWithValue("@CID", customerID);
                    command.Parameters.AddWithValue("@Quantity", quantityComboBox.Text);
                    command.Parameters.AddWithValue("@Amt", totalCost);
                    command.Parameters.AddWithValue("@AmtPaid", totalCost);


                    answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

                    connection.Close(); //Closes the connection to the database. Don't want to leave it open
                    command.Dispose(); //Disposes of the command

                    MessageBox.Show("Order is on its way!");








                    //update the inventory of the selected items to reflect what was just purchased
                    for (int i = 0; i < selectedIngredientsList.Count; i++)
                    {
                        string UPC = "";

                        /////////////////////////////////////////////////////////////////////////////
                        //find the ingredient UPC to update its inventory
                        connection = new SqlConnection(connectionstring);
                        connection.Open(); //Opens the connection to the database
                        string findUPCsql = "SELECT Ingredient_UPC FROM Ingredient WHERE Name = '" + selectedIngredientsList[i] + "'"; //Coding in C# between the plusses
                        command = new SqlCommand(findUPCsql, connection);
                        datareader = command.ExecuteReader();

                        //Populate textboxes with the information of the item chosen in the listbox
                        while (datareader.Read())
                        {
                            UPC = datareader[0].ToString();
                        }
                        connection.Close(); //Closes the connection to the database. Don't want to leave it open
                        command.Dispose(); //Disposes of the command
                        datareader.Close(); //Closes the datareader
                        /////////////////////////////////////////////////////////////////////////////////


                        updateInventoryQuantities(UPC); //update the inventory of each ingredient in the ingredients list
                    }


                    //also update the inventory of the selected juice
                    string juiceUPC = "";
                    /////////////////////////////////////////////////////////////////////////////
                    //find the ingredient UPC to update its inventory
                    connection = new SqlConnection(connectionstring);
                    connection.Open(); //Opens the connection to the database
                    string findJuiceUPCsql = "SELECT Ingredient_UPC FROM Ingredient WHERE Name = '" + selectedJuice + "'"; //Coding in C# between the plusses

                    command = new SqlCommand(findJuiceUPCsql, connection);
                    datareader = command.ExecuteReader();

                    //Populate textboxes with the information of the item chosen in the listbox
                    while (datareader.Read())
                    {
                        juiceUPC = datareader[0].ToString();
                    }
                    connection.Close(); //Closes the connection to the database. Don't want to leave it open
                    command.Dispose(); //Disposes of the command
                    datareader.Close(); //Closes the datareader
                    /////////////////////////////////////////////////////////////////////////////////
                    updateInventoryQuantities(juiceUPC);

                }
            }
            else
            {
                MessageBox.Show("Enter your card information");
            }
        }



        private void enterLoyaltyButton_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionstring);
            connection.Open(); //Opens the connection to the database


            int answer;
            string sql = "UPDATE Customer SET Frequent_Customer= 'True' WHERE Customer_ID=@CID";


            command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@CID", customerID);

            answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

            connection.Close(); //Closes the connection to the database. Don't want to leave it open
            command.Dispose(); //Disposes of the command

            MessageBox.Show("You are now a Juicy Member!");
        }


        //use this function if the quantity is changed or if new ingredients are selected
        private void refreshTotalCostTextBox()
        {
            //Find the total cost from the drink cost and the selected quantity
            totalCost = drinkCost * (Convert.ToDouble(quantityComboBox.Text));

            //Round to 2 cents
            totalCost = Math.Round(totalCost, 2);


            totalCostTextBox.Text = "$" + totalCost.ToString();
        }

        private void quantityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when a dif quantity is selected, this sets the order to the correct price
            refreshTotalCostTextBox();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
            Close();
        }
    }
}
