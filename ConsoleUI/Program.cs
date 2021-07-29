using System;
using System.Data;
using EntityLayer.EntityFramework;
using Microsoft.Data.SqlClient;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = @"Server =DESKTOP-OFJU1E2; Database = Banka; Trusted_Connection = True;";

            int Id,SubeKodu,MusteriNo,EkNo,BakiyeTutar;
            string DovizCinsi, Durum;
            DateTime HesapKapanisTarihi;

            try
            {
                using (SqlConnection conn=new SqlConnection(connString))
                {
                    string spName = @"dbo.[HesapEkle]";
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    SqlParameter param1 = new SqlParameter();
                    param1.ParameterName = "@MusteriNo";

                    cmd.Parameters.Add(param1);
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine(Environment.NewLine + "Executing stored procedure..." + Environment.NewLine);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine(Environment.NewLine + "The stored procedure has been successfully executed." + Environment.NewLine);
                    conn.Close();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
    }
}
