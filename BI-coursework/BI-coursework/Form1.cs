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
                OleDbCommand getDates = new OleDbCommand("SELECT [Order Date], [Ship Date] FROM Sheet1", connection);

                reader = getDates.ExecuteReader();
                while (reader.Read())
                {
                    Dates.Add(reader[0].ToString());
                    Dates.Add(reader[1].ToString());
                }
            }

            List<string> DatesFormatted = new List<string>();

            char prev = Convert.ToChar(" ");

            foreach (string date in Dates)
            {
                //creates data that can be split with a / to allow for spaces within data
                var dates = date.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                DatesFormatted.Add(dates[0]);

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

        private void insertTimeDimension(string date, string dayName, Int32 dayNumber, string monthName, Int32 monthNumber, Int32 weekNumber, Int32 year, Boolean weekend, Int32 dayOfYear)
        {
            //Create a connection to the MDF file
            string connectionStringDestination = Properties.Settings.Default.DestinationDatabaseConnectionString;

            using (SqlConnection myConnection = new SqlConnection(connectionStringDestination))
            {
                //open the SQL connection
                myConnection.Open();

                //check the date already exsists in the database
                SqlCommand command = new SqlCommand("SELECT id FROM Time where date = @date", myConnection);
                command.Parameters.Add(new SqlParameter("date", date));

                //create a variable and assign it
                Boolean exists = false;
                //run the command
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //if there are rows it means it exsists so update the var
                    if (reader.HasRows == true)
                    {
                        exists = true;
                    }
                }

                if (exists == false)
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
                    // int affectedRecords = insertCommand.ExecuteNonQuery();
                    // Console.WriteLine("Records Affected: " + affectedRecords);
                }
            }
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

        private int GetDateId(string date)
        {
            //splitting data down
            string[] arrayDate = date.Split('/');
            Int32 year = Convert.ToInt32(arrayDate[2]);
            Int32 month = Convert.ToInt32(arrayDate[1]);
            Int32 day = Convert.ToInt32(arrayDate[0]);

            DateTime myDate = new DateTime(year, month, day);

            string dbDate = myDate.ToString("M/dd/yyyy");

            //create a connection
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

        private void insertIntoFactTable(int productId, int timeId, int customerId, double value, double discount, double profit, double quantity)
        {
            //Create a connection to the MDF file
            string connectString = Properties.Settings.Default.DestinationDatabaseConnectionString;

            using (SqlConnection myConnection = new SqlConnection(connectString))
            {
                //Build the query
                myConnection.Open();

                SqlCommand command = new SqlCommand("SELECT productId, timeId, customerId FROM NewFactTable " +
                    "WHERE productId = @productId AND timeId = @timeId AND customerId = @customerId", myConnection);
                command.Parameters.Add(new SqlParameter("productId", productId));
                command.Parameters.Add(new SqlParameter("timeId", timeId));
                command.Parameters.Add(new SqlParameter("customerId", customerId));

                bool exists = false;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) exists = true;                    
                }
             
                if (exists == false)
                {
                    SqlCommand insertCommand = new SqlCommand("INSERT INTO NewFactTable " +
                    "(productId, timeId, customerId, regionId, value, discount, profit, quantity) " +
                    " VALUES (@productId, @timeId, @customerId, @regionId, @value, @discount, @profit, @quantity)", myConnection);
                    insertCommand.Parameters.Add(new SqlParameter("@productId", productId));
                    insertCommand.Parameters.Add(new SqlParameter("@timeId", timeId));
                    insertCommand.Parameters.Add(new SqlParameter("@customerId", customerId));
                    insertCommand.Parameters.Add(new SqlParameter("@value", value));
                    insertCommand.Parameters.Add(new SqlParameter("@discount", discount));
                    insertCommand.Parameters.Add(new SqlParameter("@profit", profit));
                    insertCommand.Parameters.Add(new SqlParameter("@quantity", quantity));

                    int recordsAffected = insertCommand.ExecuteNonQuery();
                    Console.WriteLine("Fact Table Records affected" + recordsAffected);
                }
            }
        }

        private void btnBuildFactTable_Click(object sender, EventArgs e)
        {
            //HAD ERROR WITH LINE 310 BELOW! WOULDNT EXECUTE SO COMMENTED IT OUT TO MAKE IT ALL FUNCTIONABLE!


            //string connectionString = Properties.Settings.Default.Data_set_1ConnectionString;

            //using (OleDbConnection connection = new OleDbConnection(connectionString))
            //{
            //    connection.Open();
            //    OleDbDataReader reader = null;
            //    OleDbCommand getDates = new OleDbCommand("SELECT ID, [Row ID], [Order ID], [Order Date], [Ship Date], " +
            //        " [Ship Mode], [Customer ID], [Customer Name], Segment, Country, City, State, [Postal Code], [Product ID], " +
            //        " Region, Category, [Sub-Category], [Product Name], Sales, Quantity, Porfit, Discount FROM Sheet1", connection);

            //    reader = getDates.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        //get the numeric values
            //        Decimal sales = Convert.ToDecimal(reader["Sales"]);
            //        Int32 quantity = Convert.ToInt32(reader["Quantity"]);
            //        Decimal profit = Convert.ToDecimal(reader["Profit"]);
            //        Decimal discount = Convert.ToDecimal(reader["Discount"]);

            //        //get the dimension IDS
            //        // Int32 productId = 0;
            //        Int32 timeId = GetDateId(reader["Order Date"].ToString());
            //        //Int32 customerId = 0;

            //    }
            //}

            GetFactTable();

        }

        private void GetFactTable()
        {
            //Create a list
            List<string> records = new List<string>();
            //clear existing data source
            listBoxFactTable.DataSource = null;
            //empty lstFactTable
            listBoxFactTable.Items.Clear();

            //Connect to the source
            string dataConnect = Properties.Settings.Default.Data_set_1ConnectionString;

            using (OleDbConnection connection = new OleDbConnection(dataConnect))
            {
                //Get the data
                connection.Open();
                OleDbDataReader reader = null;
                OleDbCommand getRecord = new OleDbCommand("SELECT [Product ID], [Customer ID], [Order ID], [Row ID], [Sales], [Profit], [Discount], [Quantity] FROM Sheet1", connection);

                reader = getRecord.ExecuteReader();
                while (reader.Read())
                {
                    records.Add(reader[0].ToString());
                    records.Add(reader[1].ToString());
                }
            }

            List<string> RecordsFormatted = new List<string>();

            char prev = Convert.ToChar(" ");

            foreach (string record in records)
            {
                //creates data that can be split with a / to allow for spaces within data
                var Records = record.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                RecordsFormatted.Add(Records[0]);
            }
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            List<string> nameList = new List<string>(new String[] {"01/08/2019", "02/08/2019", "03/08/2019", "04/08/2019", "05/08/2019", "06/08/2019", "07/08/2019", "08/08/2019", "09/08/2019", "10/08/2019"});
            List<int> idList = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Dictionary<int, int> salesCount = new Dictionary<int, int>();

            //create a connection
            String connectionStringDestination = Properties.Settings.Default.DestinationDatabaseConnectionString;

            foreach (int id in idList)
            {
                using (SqlConnection myConnection = new SqlConnection(connectionStringDestination))
                {
                    //open connection
                    myConnection.Open();
                    SqlCommand command = new SqlCommand("SELECT COUNT(timeId) as Ids FROM " + "FactTable " + "WHERE timeId = @id", myConnection);
                    command.Parameters.Add(new SqlParameter("@id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows == true)
                        {
                            while (reader.Read())
                            {
                                salesCount.Add(id, Convert.ToInt32(int.Parse(reader["Ids"].ToString())));
                            }
                        }
                        else
                        {
                            salesCount.Add(id, 0);
                        }
                    }
                }
            }
            //barchart
            dateBarChart.DataSource = salesCount;
            dateBarChart.Series[0].XValueMember = "Key";
            dateBarChart.Series[0].YValueMembers = "Value";
            dateBarChart.DataBind();
            //piechart
            datePieChart.DataSource = salesCount;
            datePieChart.Series[0].XValueMember = "Key";
            datePieChart.Series[0].YValueMembers = "Value";
            datePieChart.DataBind();
        }







        /// <summary>
        /// //////////////////////////Parts for group memebers but didnt copy over from orginal work/////////////////////////
        /// </summary>
      


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
        
    }
}
