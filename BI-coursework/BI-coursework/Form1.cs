using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BI_coursework
{
    public partial class Form1 : Form
    {

        //Leave this alone
        public Form1()
        {
            InitializeComponent();
        }

        //Leave this alone
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //This needs replacing with whatever button we decide to make
        private void GetDataFromSource_Click(object sender, EventArgs e)
        {
            GetDatesFromSource();
            GetProductFromSource();
            GetCustomerFromSource();
        }

        private void btnGetDates_Click(object sender, EventArgs e)
        {
            GetDatesFromSource();
        }

        private void GetDatesFromSource()
        {
            List<string> Dates = new List<string>();
            //clear the list box to ensure no old data
            listBoxDates.DataSource = null;
            listBoxDates.Items.Clear();

            //create the database string
            string connectionString = Properties.Settings.Default.Data_set_1ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbDataReader reader = null;
                OleDbCommand getDates = new OleDbCommand("SELECT [Order Date], [Ship Date] FROM Sheet1, Connection");

                reader = getDates.ExecuteReader();
                while (reader.Read())
                {
                    Dates.Add(reader[0].ToString() + "/" + reader[1].ToString() + "/" + reader[2].ToString());
                }
            }

            List<string> DatesFormatted = new List<string>();
            //one list for formatting, one for displaying
            List<string> datesFormat = new List<string>();
            List<string> datesDisplay = new List<string>();

            char prev = Convert.ToChar(" ");

            foreach (string date in Dates)
            {//creates data that can be split with a / to allow for spaces within data
                var theseDates = date.Split('/');
                //if the reference is the same in the previous record this isnt run
                if (prev != date[6])
                {
                    datesDisplay.Add(theseDates[0]);
                    datesFormat.Add(theseDates[0]);
                    datesFormat.Add(theseDates[1]);
                    datesFormat.Add(theseDates[2]);
                    
                }
                //sets the current record to the variable prev
                prev = date[2]; 
            }

            listBoxDates.DataSource = DatesFormatted;

            //split the dates and insert every date
            foreach (string date in DatesFormatted)
            {
                splitDates(date);
            }

        }

        private void splitDates(string date)
        {
            //splitting data down
            string[] arrayDate = date.Split('/');
            Int32 year = Convert.ToInt32(arrayDate[2]);
            Int32 month = Convert.ToInt32(arrayDate[1]);
            Int32 day = Convert.ToInt32(arrayDate[0]);

            DateTime myDate = new DateTime(year, month, day);
            Console.WriteLine("Day of week: " + myDate.DayOfWeek);

            String dayOfWeek = myDate.DayOfWeek.ToString();
            Int32 dayOfYear = myDate.DayOfYear;
            String monthName = myDate.ToString("MMMM");
            Int32 weekNumber = dayOfYear / 7;
            Boolean weekend = false;
            if (dayOfWeek == "Saturday" || dayOfWeek == "Sunday") weekend = true;

            //convert this to a database format
            string dbDate = myDate.ToString("M/dd/yyyy");

            insertTimeDimension(date, dayOfWeek, day, monthName, month, weekNumber, year, weekend, dayOfYear);
        }

        private void GetProductFromSource()
        {
            //Create a list

            //Connect to the source

            //Get the data

            //Add data to list

        }

        private void GetCustomerFromSource()
        {
            //Create a list

            //Connect to the source

            //Get the data

            //Add data to list
        }


        private void insertTimeDimension(string date, string dayName, Int32 dayNumber, string monthName, Int32 monthNumber, Int32 weekNumber, Int32 year, Boolean weekend, Int32 dayOfYear)
        {
            //Create a connection to the MDF file
            string connectionStringDestination = Properties.Settings.Default.DestinationDatabaseConnectionString;

            using (SqlConnection myConnection = new SqlConnection(connectionStringDestination))
            {
                //open the SQL connection
                myConnection.Open();

                //check the date already exsists in the database
                SqlCommand command = new SqlCommand("SELECT id FROM Time where date = @Date", myConnection);
                command.Parameters.Add(new SqlParameter("date", date));

                //create a variable and assign it
                Boolean exists = false;

                //run the command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //if there are rows it means it exsists so update the var
                    if (reader.HasRows) exists = true;
                }

                if(exists == false)
                {
                    SqlCommand insertCommand = new SqlCommand(
                        "INSERT INTO Time (dayName, dayNumber, monthName, monthNumber, weekNumber, year, weekend, date, dayOfYear)" +
                        " VALUES (@dayName, @dayNumber, @monthName, @monthNumber, @weekNumber, @year, @weekend, @date, @dayOfYear) ", myConnection);
                    insertCommand.Parameters.Add(new SqlParameter("dayName", dayName));
                    insertCommand.Parameters.Add(new SqlParameter("dayNumber", dayNumber));
                    insertCommand.Parameters.Add(new SqlParameter("monthName", monthName));
                    insertCommand.Parameters.Add(new SqlParameter("monthNumber", monthNumber));
                    insertCommand.Parameters.Add(new SqlParameter("weekNumber", weekNumber));
                    insertCommand.Parameters.Add(new SqlParameter("year", year));
                    insertCommand.Parameters.Add(new SqlParameter("weekend", weekend));
                    insertCommand.Parameters.Add(new SqlParameter("date", date));
                    insertCommand.Parameters.Add(new SqlParameter("dayOfYear", dayOfYear));

                    //insert the line
                    int recordsAffected = insertCommand.ExecuteNonQuery();
                    Console.WriteLine("RecordsAffected: " + recordsAffected);
                }
            }
        }

        private void insertProductDimension(string category, string subcategory, string name, string reference)
        {
            //Create a connection to the MDF file

            //Build the query

            //Insert the data
        }

        private void insertCustomerDimension(string name, string country, string city, string state, string postCode, string region, string reference)
        {
            //Create a connection to the MDF file

            //Build the query

            //Insert the data
        }

        private void btnGetDimension_Click(object sender, EventArgs e)
        {
            GetAllDatesFromDimension();
        }

        private void GetAllDatesFromDimension()
        {
            //create a list to store the data in
            List<string> DestinationDates = new List<string>();

            //clear the lists box
            listBoxDatesDimension.DataSource = null;
            listBoxDatesDimension.Items.Clear();

            //create a connection to MDF file
            string connectionStringDestination = Properties.Settings.Default.DestinationDatabaseConnectionString;

            using (SqlConnection myConnection = new SqlConnection(connectionStringDestination))
            {
                //open the sql connection
                myConnection.Open();
                //check if the date already exists
                SqlCommand command = new SqlCommand("SELECT id, dayName, dayNumber, monthName, monthNumber, weekNumber, year, " +
                    " weekend, date, dayOfYear FROM Time", myConnection);


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read()) //loop gets the data
                        {
                            //do something with each record
                            //build what i want the list box to show
                            string id = reader["id"].ToString();
                            string dayName = reader["dayName"].ToString();
                            string dayNumber = reader["dayNumber"].ToString();
                            string monthName = reader["monthName"].ToString();
                            string monthNumber = reader["monthNumber"].ToString();
                            string weekNumber = reader["weekNumber"].ToString();
                            string year = reader["year"].ToString();
                            string weekend = reader["weekend"].ToString();
                            string date = reader["date"].ToString();
                            string dayOfYear = reader["dayOfYear"].ToString();

                            string text;

                            text = "ID = " + id + ", Day Name = " + dayName + ", Day Number = " + dayNumber +
                                ", Month Name = " + monthName + ", Month Number = " + monthNumber + ", Week Number = " + weekNumber +
                                ", Year = " + year + ", Weekend = " + weekend + ", Date = " + date + " Day of year = " + dayOfYear;

                            DestinationDates.Add(text);
                        }
                    }
                    else //there was no data, show error
                    {
                        DestinationDates.Add("No data present in the Time Dimension");
                    }
                }
            }

            //bind the list box
            listBoxDatesDimension.DataSource = DestinationDates;
        }  
        
        
        private void GetAllProductsFromDimension()
        {
            //Create new list to store the named results in.

            //Create the database string

            //Run the query

            //Bind the listbox to the list.
        }

        private void GetAllCustomersFromDimension()
        {
            //Create new list to store the named results in.

            //Create the database string

            //Run the query

            //Bind the listbox to the list.
        }

        private int GetDateId(string date)
        {
            //splitting data down
            string[] arrayDate = date.Split('/');
            Int32 year = Convert.ToInt32(arrayDate[2]);
            Int32 month = Convert.ToInt32(arrayDate[1]);
            Int32 day = Convert.ToInt32(arrayDate[0]);

            DateTime myDate = new DateTime(year, month, day);

            string dbDate = myDate.ToString("M/dd/yyyy");

            string connectionStringDestination = Properties.Settings.Default.DestinationDatabaseConnectionString;

            using (SqlConnection myConnection = new SqlConnection(connectionStringDestination))
            {
                //open the SQL connection
                myConnection.Open();

                //check the date already exsists in the database
                SqlCommand command = new SqlCommand("SELECT id FROM Time where date = @Date", myConnection);
                command.Parameters.Add(new SqlParameter("date", date));

                //run the command and read results
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //if there are rows it means it exsists so update the var
                    if (reader.HasRows)
                    {
                        return Convert.ToInt32(reader["id"]);
                    }

                }
            }
             //return the details
             return 0;

        }
        private int GetProductId(string reference)
        {
            //Remove the timestamps

            //Split the clean date down and assign it to variables for later use.

            //Create a connection to the MDF file

            //Run the command & read the results

            //return the details
            return 0;
        }

        private int GetCustomerId(string reference)
        {

            //Remove the timestamps

            //Split the clean date down and assign it to variables for later use.

            //Create a connection to the MDF file

            //Run the command & read the results

            //return the details
            return 0;
        }
        private void insertIntoFactTable(int productId, int timeId, int customerId, double value, double discount, double profit, double quantity)
        {
            //Create a connection to the MDF file

            //Build the query

            //Insert the data
        }

        private void GetFactTable() //DO THIS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        {
            //Create new list to store the named results in.

            //Create the database string

            //Run the query

            //Bind the listbox to the list.
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void listBoxDates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
