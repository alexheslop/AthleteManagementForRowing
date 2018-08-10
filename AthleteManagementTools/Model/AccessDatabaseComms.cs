using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace AthleteManagementTools.Model
{
    
    public static class AccessDatabaseComms
    {
        private static ObservableCollection<Rower> _rowerList;
        public static ObservableCollection<Rower> ReadDatabase()
        {
            _rowerList = new ObservableCollection<Rower>();
            var con = new OleDbConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                    .ToString()
            };
            const string queryString = "SELECT FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,ErgTime FROM Athletes";

            var command = new OleDbCommand(queryString, con);
            con.Open();
            var reader = command.ExecuteReader();
            while (reader != null && reader.Read())
            {
                var newRower = new Rower
                {
                    FirstName = reader.GetString(0),
                    LastName = reader.GetString(1),
                    Squad = reader.GetString(2),
                    Side = reader.GetString(3),
                    CanScull = reader.GetBoolean(4),
                    BowsideRank = reader.GetInt16(5),
                    StrokesideRank = reader.GetInt16(6),
                    ScullRank = reader.GetInt16(7),
                    ErgTime = reader.GetDouble(8)
                };
                
                _rowerList.Add(newRower);
            }

            reader?.Close();
            con.Close();
            return _rowerList;
        }

        public static bool WritePersonToDatabase(string firstName, string lastName, string squad, string side, bool canScull, int bowsideRank, int strokesideRank, int scullRank, double ergTime)
        {
            var con = new OleDbConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                    .ToString()
            };
            var cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            var command = new OleDbCommand
            {
                CommandText =
                    "INSERT INTO [Athletes](FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,ErgTime)VALUES(@fnm, @lnm, @squad, @side, @canscull, @bowsiderank, @strokesiderank, @scullrank, @ergtime)"
            };
            command.Parameters.AddWithValue("@fnm", firstName);
            command.Parameters.AddWithValue("@lnm", lastName);
            command.Parameters.AddWithValue("@squad", squad);
            command.Parameters.AddWithValue("@side", side);
            command.Parameters.AddWithValue("@canscull", canScull);
            command.Parameters.AddWithValue("@bowsiderank", bowsideRank);
            command.Parameters.AddWithValue("@strokesiderank", strokesideRank);
            command.Parameters.AddWithValue("@scullrank", scullRank);
            command.Parameters.AddWithValue("@ergtime", ergTime);

            command.Connection = con;


            command.ExecuteNonQuery();
            con.Close();

            return true;
        }

        public static ObservableCollection<Boat> ReadBoatFromDatabase()
        {
            var boatCollection = new ObservableCollection<Boat>();
            var con = new OleDbConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                    .ToString()
            };
            const string queryString = "SELECT BoatName,Seats,Cox,Scull,classRank FROM Boats";

            var command = new OleDbCommand(queryString, con);
            con.Open();
            var reader = command.ExecuteReader();
            while (reader != null && reader.Read())
            {
                var newRower = new Boat
                {
                    BoatName = reader.GetString(0),
                    Seats = reader.GetInt16(1),
                    Cox = reader.GetBoolean(2),
                    Scull = reader.GetBoolean(3),
                    ClassRank = reader.GetInt16(4),
                };

                boatCollection.Add(newRower);
            }

            reader?.Close();
            con.Close();
            return boatCollection;
        }

        public static bool WriteBoatToDatabase(string boatName, int seats, bool cox, bool scull, int classRank)
        {
            var con = new OleDbConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                    .ToString()
            };
            var cmd = new OleDbCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            var command = new OleDbCommand
            {
                CommandText =
                    "INSERT INTO [Boats](BoatName,Seats,Cox,Scull,classRank)VALUES(@bnm, @seat, @cox, @scull, @clRank)"
            };
            command.Parameters.AddWithValue("@bnm", boatName);
            command.Parameters.AddWithValue("@seat", seats);
            command.Parameters.AddWithValue("@cox", cox);
            command.Parameters.AddWithValue("@scull", scull);
            command.Parameters.AddWithValue("@clRank", classRank);

            command.Connection = con;


            command.ExecuteNonQuery();
            con.Close();

            return true;
        }
    }
}