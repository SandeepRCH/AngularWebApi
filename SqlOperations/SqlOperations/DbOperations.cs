using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlOperations
{
    class DbOperations
    {
        DataSet dataSet = new DataSet();
        readonly string conString = "data source = GGKU4MPC71; database=SandeepDB; integrated security=SSPI";
        public void InsertToDb(string tableName)
        {
            SqlConnection Connection = new SqlConnection(conString);
            Connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from " + tableName, Connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(dataAdapter);
            dataAdapter.Fill(dataSet, tableName);
            DataRow row = dataSet.Tables[tableName].NewRow();
            try
            {
                for (int i = 0; i < dataSet.Tables[tableName].Columns.Count; i++)
                {
                    Console.WriteLine("Enter the values of " + dataSet.Tables[tableName].Columns[i].ColumnName);
                    row[dataSet.Tables[tableName].Columns[i].ColumnName] =
                        Convert.ChangeType(Console.ReadLine(), dataSet.Tables[tableName].Columns[i].DataType);
                }
                dataSet.Tables[tableName].Rows.Add(row);
                dataAdapter.Update(dataSet, tableName);
                Console.WriteLine("inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine("not inserted");
                Console.WriteLine(e.Message);
            }
            Connection.Close();
        }
        public void SelectFromDb(string tableName)
        {
            SqlConnection Connection = new SqlConnection(conString);
            Connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from " + tableName, Connection);
            dataAdapter.Fill(dataSet, tableName);
            try
            {
                Console.WriteLine("Enter number of columns");
                string commands = "select ";
                int i = Convert.ToInt32(Console.ReadLine());
                for (int j = 0; j < dataSet.Tables[tableName].Columns.Count; j++)
                {
                    Console.WriteLine(j + ". " + dataSet.Tables[tableName].Columns[j].ColumnName);
                }
                Console.WriteLine("select rows required");
                for (int j = 0; j < i; j++)
                {
                    if (i - 1 != j)
                    {
                        commands = commands + dataSet.Tables[tableName].Columns[Convert.ToInt32(Console.ReadLine())].ColumnName + ",";
                    }
                    else
                    {
                        commands = commands + dataSet.Tables[tableName].Columns[Convert.ToInt32(Console.ReadLine())].ColumnName;
                    }
                }
                commands = commands + " From " + tableName;
                SqlCommand command = new SqlCommand(commands, Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int j = 0; j < reader.FieldCount; j++)
                    {
                        Console.Write(reader[j] + "   ");
                    }
                    Console.WriteLine();
                }
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("not selected");
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateDb(string tableName)
        {
            SqlConnection Connection = new SqlConnection(conString);
            Connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from " + tableName, Connection);
            dataAdapter.Fill(dataSet, tableName);
            try
            {
                Console.WriteLine("Enter which column to refer");
                for (int j = 0; j < dataSet.Tables[tableName].Columns.Count; j++)
                {
                    Console.WriteLine(j + " " + dataSet.Tables[tableName].Columns[j].ColumnName);
                }
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter update " + dataSet.Tables[tableName].Columns[a].ColumnName + " to select row");
                int i = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter column number to modify");
                for (int j = 0; j < dataSet.Tables[tableName].Columns.Count; j++)
                {
                    if (dataSet.Tables[tableName].Columns[a].DataType == typeof(string))
                    {
                        Console.WriteLine(j + " " + dataSet.Tables[tableName].Columns[j].ColumnName);
                    }
                    else
                    {
                        Console.WriteLine(j + " " + dataSet.Tables[tableName].Columns[j].ColumnName);
                    }
                }
                int k = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter updating value");
                string commands;
                if (dataSet.Tables[tableName].Columns[k].DataType == typeof(string)|| 
                    dataSet.Tables[tableName].Columns[k].DataType == typeof(DateTime))
                {
                    commands = "update " + tableName + " set " + 
                        dataSet.Tables[tableName].Columns[k].ColumnName + " = '" + Console.ReadLine() + "' where " + 
                        dataSet.Tables[tableName].Columns[0].ColumnName + " = " + i;
                }
                else
                {
                    commands = "update " + tableName + " set " + 
                        dataSet.Tables[tableName].Columns[k].ColumnName + " = " + Console.ReadLine() + " where " + 
                        dataSet.Tables[tableName].Columns[0].ColumnName + " = " + i;
                }
                SqlCommand command = new SqlCommand(commands, Connection);
                command.ExecuteNonQuery();
                Console.WriteLine("updated");
                Connection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("not updated");
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteFromDb(string tableName)
        {
            SqlConnection Connection = new SqlConnection(conString);
            Connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from " + tableName, Connection);
            dataAdapter.Fill(dataSet, tableName);
            int m = 0;
            Console.WriteLine("enter column number to check");
            for (int j = 0; j < dataSet.Tables[tableName].Columns.Count; j++)
            {
                Console.WriteLine(j + " . " + dataSet.Tables[tableName].Columns[j].ColumnName);
            }
            m = Convert.ToInt32(Console.ReadLine());
            string commands;
            try
            {
                Console.WriteLine("Enter " + dataSet.Tables[tableName].Columns[m] + " value to delete column");
                if (dataSet.Tables[tableName].Columns[m].DataType == typeof(string)|| 
                    dataSet.Tables[tableName].Columns[m].DataType == typeof(DateTime))
                {
                    commands = "Delete from " + tableName + " where " + 
                        dataSet.Tables[tableName].Columns[m].ColumnName + " = " + "'" + 
                        Convert.ChangeType(Console.ReadLine(), dataSet.Tables[tableName].Columns[m].DataType) + "'";
                }
                else
                {
                    commands = "Delete from " + tableName + " where " + 
                        dataSet.Tables[tableName].Columns[m].ColumnName + " = " + 
                        Convert.ChangeType(Console.ReadLine(), dataSet.Tables[tableName].Columns[m].DataType);
                }
                Console.WriteLine(commands);
                SqlCommand command = new SqlCommand(commands, Connection);
                command.ExecuteNonQuery();
                Connection.Close();
                Console.WriteLine("Deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine("not deleted");
                Console.WriteLine(e.Message);
            }
        }
    }
}