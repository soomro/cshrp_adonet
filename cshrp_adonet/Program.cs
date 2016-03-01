using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cshrp_adonet
{
    class Program
    {
        static void Main(string[] args)
        {
            // sql connection
            string connectionString = "Provider=MSDASQL.1;Persist Security Info=False;Data Source=northwindodbc";

            // sql query
            string QueryStr = "SELECT ID, UnitPrice, ProdName from dbo.products "
                + "WHERE UnitPrice > @pricePoint "
                + "ORDER BY UnitPrice DESC;";

            // parameters
            int paramVal = 5;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // SqlCommand 
                SqlCommand cmd = new SqlCommand(QueryStr, con);

                cmd.Parameters.AddWithValue("@pricePoint", paramVal);

                try
                {
                    con.Open();
                    
                    // SqlDataReader
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}", 
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
                Console.ReadKey();
            }
        }
    }
}
