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
    public partial class Form1 : Form
    {
        //Use this to connect to the database
        ////////////////////////////////////////////////////////////////////////////////////
        string connectionstring = "Data Source=essql1.walton.uark.edu;Initial Catalog=ISYS4283Team21;User ID=ISYS4283Team21;Password=KY55kzb$";
        SqlConnection connection; //Function to open an sql database
        SqlCommand command; //Used to execute sql statements I think???
        SqlDataReader datareader;
        ////////////////////////////////////////////////////////////////////////////////////


        /// This is all to find the age and birthday of a customer creating an account
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        //Find the current year, month, and day
        int todaysDay = DateTime.Now.Day;
        int todaysMonth = DateTime.Now.Month;
        int todaysYear = DateTime.Now.Year;

        //Variables to save the customer's selected birth year, month, and day
        int selectedDay;
        int selectedMonth;
        int selectedYear;

        //Variables to save how many years the current date is ahead of the selected one. Do the same for month and day
        int yearsPassed;
        int monthsPassed;
        int daysPassed;

        //Variable to save the age
        int customerAge;
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>




        public Form1()
        {
            InitializeComponent();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            customerLoginPanel.Visible = true;
            employeeLoginPanel.Visible = false;
            orderButton.Visible = false;
            EmpLoginButton.Visible = false;
            createCustomerPanel.Visible = false;
        }

        private void CustomerLoginButton_Click(object sender, EventArgs e)
        {
            if (custEmailBox.Text != "" && custPasswordBox.Text != "")
            {
                //Use this to save the password from the database to test against what was entered in the password textbox
                string customerPassword = "";

                //find the customer logging in and save his/her Customer ID and if they are a frequent customer
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                string customerID = "-1";  //send this to form 2 to keep track of what customer is ordering
                string isFrequent = "false";
                connection = new SqlConnection(connectionstring);
                connection.Open(); //Opens the connection to the database
                string sql = "SELECT Customer_ID, Frequent_Customer, Customer_Password FROM Customer WHERE Email = '" + custEmailBox.Text.ToString() + "'"; //Coding in C# between the plusses
                command = new SqlCommand(sql, connection);
                datareader = command.ExecuteReader();

                //Populate textboxes with the information of the item chosen in the listbox
                while (datareader.Read())
                {
                    customerID = datareader[0].ToString();
                    isFrequent = datareader[1].ToString();
                    customerPassword = datareader[2].ToString();
                }
                connection.Close(); //Closes the connection to the database. Don't want to leave it open
                command.Dispose(); //Disposes of the command
                datareader.Close(); //Closes the datareader
                //MessageBox.Show("DELETE LATER: " + customerID + " " + isFrequent);  //Message for testing
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                


                if (customerPassword == custPasswordBox.Text /*custEmailBox.Text != "Enter Email" && custPasswordBox.Text != "Enter Password"*/)  //Remove the commented code later. Want to save it for testing
                {
                    this.Hide();
                    Form2 f2 = new Form2(customerID, isFrequent);  //Send the customer ID and frequency to form 2 when you open the form
                    f2.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Password does not match email. Try again");
                }
            }
        }

        private void custEmailBox_MouseClick(object sender, MouseEventArgs e)
        {
            custEmailBox.Text = "";
        }

        private void custPasswordBox_MouseClick(object sender, MouseEventArgs e)
        {
            custPasswordBox.Text = "";
        }

        private void employeeLoginButton_Click(object sender, EventArgs e)
        {
            int x;
            bool idIsNum = int.TryParse(empIDBox.Text, out x);
            if (empIDBox.Text != "" && empPasswordBox.Text != "" && idIsNum)
            {
                string EmployeeID = "";
                string EmployeePass = "";


                connection = new SqlConnection(connectionstring);
                connection.Open();
                string sql2 = "SELECT Employee_ID, Employee_Password FROM Employee WHERE Employee_ID = '" + empIDBox.Text.ToString() + "'";
                command = new SqlCommand(sql2, connection);
                datareader = command.ExecuteReader();


                while (datareader.Read())
                {
                    EmployeeID = datareader[0].ToString();
                    EmployeePass = datareader[1].ToString();

                }

                connection.Close();
                command.Dispose();
                datareader.Close();

                if (EmployeeID == empIDBox.Text && EmployeePass == empPasswordBox.Text)
                {
                    this.Hide();
                    Form3 f3 = new Form3(EmployeeID);
                    f3.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Invalid ID or Password");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID or Password");
            }





            /*if (empEmailBox.Text != "" && empPasswordBox.Text != "")
            {
                if (empEmailBox.Text != "Enter Email" && empPasswordBox.Text != "Enter Password")
                {
                    //custPasswordBox.Text = "lol";
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.ShowDialog();
                    Close();
                }
            }*/
        }

        private void EmpLoginButton_Click(object sender, EventArgs e)
        {
            customerLoginPanel.Visible = false;
            employeeLoginPanel.Visible = true;
            orderButton.Visible = false;
            EmpLoginButton.Visible = false;
            createCustomerPanel.Visible = false;
        }

        private void empEmailBox_Click(object sender, EventArgs e)
        {
            empIDBox.Text = "";
        }

        private void empPasswordBox_Click(object sender, EventArgs e)
        {
            empPasswordBox.Text = "";
        }

        private void empCancelButton_Click(object sender, EventArgs e)
        {
            customerLoginPanel.Visible = false;
            employeeLoginPanel.Visible = false;
            orderButton.Visible = true;
            EmpLoginButton.Visible = true;
            createCustomerPanel.Visible = false;
        }

        private void custCancelButton_Click(object sender, EventArgs e)
        {
            customerLoginPanel.Visible = false;
            employeeLoginPanel.Visible = false;
            orderButton.Visible = true;
            EmpLoginButton.Visible = true;
            createCustomerPanel.Visible = false;
        }

        private void startNewAccountButton_Click(object sender, EventArgs e)
        {
            customerLoginPanel.Visible = false;
            employeeLoginPanel.Visible = false;
            orderButton.Visible = false;
            EmpLoginButton.Visible = false;
            createCustomerPanel.Visible = true;
        }

        private void CreateCustCancelButton_Click(object sender, EventArgs e)
        {
            customerLoginPanel.Visible = true;
            employeeLoginPanel.Visible = false;
            orderButton.Visible = false;
            EmpLoginButton.Visible = false;
            createCustomerPanel.Visible = false;

            monthCalendar1.Visible = false;
        }

        private void createAccountButton_Click(object sender, EventArgs e)
        {
            if (fNameTextBox.Text != "" && lNameTextBox.Text != "" && phoneNumberTextBox.Text != "" && emailTextBox.Text != "" && CardNumberTextBox.Text != "" && cityTextBox.Text != "" && streetTextBox.Text != "" && zipTextBox.Text != "" && postalTextBox.Text != "" && genderComboBox.Text != "" && pwordTextBox.Text != "" && ageTextBox.Text != "")
            {
                bool correctBDay = Int32.Parse(ageTextBox.Text) >= 0; //Checks to see if age is a possible number. Allows anyone zero and up to make an account (no people who haven't been born yet tho lol)

                if (correctBDay)
                {
                    connection = new SqlConnection(connectionstring);
                    connection.Open(); //Opens the connection to the database


                    int answer;
                    string sql = "INSERT INTO Customer VALUES((SELECT (MAX(Customer_ID) + 1) FROM Customer), @FName, @LName, @PNumb, @Email, @BDay, @Age, @CNumb, @City, @Gender, @Postal, @Str, @Zip, @Freq, @PWord)"; //The @s are placeholders. Telling system that they will be seen later in the code


                    command = new SqlCommand(sql, connection);

                    //Connects the correct textbox data with what attribute they will be put into
                    command.Parameters.AddWithValue("@FName", fNameTextBox.Text);
                    command.Parameters.AddWithValue("@LName", lNameTextBox.Text);
                    command.Parameters.AddWithValue("@PNumb", phoneNumberTextBox.Text);
                    command.Parameters.AddWithValue("@Email", emailTextBox.Text);
                    command.Parameters.AddWithValue("@BDay", bdayTextBox.Text);
                    command.Parameters.AddWithValue("@Age", ageTextBox.Text);
                    command.Parameters.AddWithValue("@CNumb", CardNumberTextBox.Text);
                    command.Parameters.AddWithValue("@City", cityTextBox.Text);
                    command.Parameters.AddWithValue("@Gender", genderComboBox.Text);
                    command.Parameters.AddWithValue("@Postal", postalTextBox.Text);
                    command.Parameters.AddWithValue("@str", streetTextBox.Text);
                    command.Parameters.AddWithValue("@Zip", zipTextBox.Text);
                    command.Parameters.AddWithValue("@Freq", "False");
                    command.Parameters.AddWithValue("@PWord", pwordTextBox.Text);

                    answer = command.ExecuteNonQuery(); //Loading rata to the database -- write to the database

                    connection.Close(); //Closes the connection to the database. Don't want to leave it open
                    command.Dispose(); //Disposes of the command

                    MessageBox.Show("Account Created!\n" + "You can now log in");
                }
                else
                {
                    MessageBox.Show("Make sure to enter a valid birthday.");

                }
            }
            else
            {
                MessageBox.Show("Make sure to enter a value for all fields.");
            }
        }

        private void selectDateButton_Click(object sender, EventArgs e)
        {
            monthCalendar1.Location = new Point(64,125);
            monthCalendar1.Visible = true;
        }

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
                bdayTextBox.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if(dayNeeds0 == true && monthNeeds0 == false)
            {
                bdayTextBox.Text = selectedYear.ToString() + "-" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == false && monthNeeds0 == true)
            {
                bdayTextBox.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }
            else if (dayNeeds0 == true && monthNeeds0 == true)
            {
                bdayTextBox.Text = selectedYear.ToString() + "-0" + selectedMonth.ToString() + "-0" + selectedDay.ToString(); //DB format = yyyy-mo-dy
            }

            ageTextBox.Text = customerAge.ToString();
        }
    }
}
