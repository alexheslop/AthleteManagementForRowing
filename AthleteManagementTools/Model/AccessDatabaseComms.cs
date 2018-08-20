using System;
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

        public static ObservableCollection<Rower> SelectSquad(string squad)
        {
            var newstring = "";
            if (squad == "All")
            {
                newstring = "SELECT FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,PB2k,PB5k,PB30r20,UT2Split,MaxHR,MinHR FROM Athletes";
            }
            else if (squad == "Seniors" || squad == "Novices")
            {
                squad = squad.Remove(squad.Length - 1);
                newstring =
                    $"SELECT FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,PB2k,PB5k,PB30r20,UT2Split,MaxHR,MinHR FROM Athletes WHERE Squad LIKE '{squad}%'";
            }
            
            else
            {
                newstring = $"SELECT FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,PB2k,PB5k,PB30r20,UT2Split,MaxHR,MinHR FROM Athletes WHERE Squad = '{squad}'";
            }
            
            var athleteList = ReadAthleteDatabase(newstring);
            return athleteList;
        }
        private static ObservableCollection<Rower> ReadAthleteDatabase(string sqlQuery)
        {
            _rowerList = new ObservableCollection<Rower>();
            var con = new OleDbConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                    .ToString()
            };

            var command = new OleDbCommand(sqlQuery, con);
            con.Open();
            var reader = command.ExecuteReader();
            
            while (reader != null && reader.Read())
            {
                var newRower = new Rower();
                newRower.FirstName = reader.GetString(0);
                newRower.LastName = reader.GetString(1);
                newRower.Squad = reader.GetString(2);
                newRower.Side = reader.GetString(3);
                newRower.CanScull = reader.GetBoolean(4);
                newRower.BowsideRank = reader.GetInt16(5);
                newRower.StrokesideRank = reader.GetInt16(6);
                newRower.ScullRank = reader.GetInt16(7);
                newRower.Pb2K = reader.GetString(8);
                newRower.Pb5K = reader.GetString(9);
                newRower.Pb30R20 = reader.GetString(10);
                newRower.Ut2Split = reader.GetString(11);
                newRower.MaxHr = reader.GetInt16(12);
                newRower.MinHr = reader.GetInt16(13);
                _rowerList.Add(newRower);
            }

            reader?.Close();
            con.Close();
            return _rowerList;
        }

        public static bool WritePersonToDatabase(string firstName, string lastName, string squad, string side, bool canScull,
            int bowsideRank, int strokesideRank, int scullRank, string pb2K, string pb5K, string pb30R20, string ut2Split)
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
                    "INSERT INTO [Athletes](FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,PB2k,PB5k, PB30r20, UT2Split)VALUES(@fnm, @lnm, @squad, @side, @canscull, @bowsiderank, @strokesiderank, @scullrank, @pb2k, @pb5k, @pb30r20, @Ut2split)"
            };
            command.Parameters.AddWithValue("@fnm", firstName);
            command.Parameters.AddWithValue("@lnm", lastName);
            command.Parameters.AddWithValue("@squad", squad);
            command.Parameters.AddWithValue("@side", side);
            command.Parameters.AddWithValue("@canscull", canScull);
            command.Parameters.AddWithValue("@bowsiderank", bowsideRank);
            command.Parameters.AddWithValue("@strokesiderank", strokesideRank);
            command.Parameters.AddWithValue("@scullrank", scullRank);
            command.Parameters.AddWithValue("@pb2k", pb2K);
            command.Parameters.AddWithValue("@pb5k", pb5K);
            command.Parameters.AddWithValue("@pb30r20", pb30R20);
            command.Parameters.AddWithValue("@Ut2split", ut2Split);
            
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
            //command.Parameters.AddWithValue("@bnm", boatName);
            command.Parameters.AddWithValue("@seat", seats);
            command.Parameters.AddWithValue("@cox", cox);
            command.Parameters.AddWithValue("@scull", scull);
            command.Parameters.AddWithValue("@clRank", classRank);

            command.Connection = con;


            command.ExecuteNonQuery();
            con.Close();

            return true;
        }

        public static bool UpdateRowerFromErgProfile(string firstName, string lastName, string pb2K, string pb5K, string pb30R20, string ut2Split, int maxHr, int minHr)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                .ToString();

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    "UPDATE Athletes SET PB2k = ?, PB5k = ?, PB30r20 = ?, UT2Split = ?, MaxHR = ?, MinHR = ? WHERE FirstName = ? and LastName = ?";

                var p1 = command.CreateParameter();
                p1.Value = pb2K;
                command.Parameters.Add(p1);

                var p2 = command.CreateParameter();
                p2.Value = pb5K;
                command.Parameters.Add(p2);

                var p3 = command.CreateParameter();
                p3.Value = pb30R20;
                command.Parameters.Add(p3);

                var p4 = command.CreateParameter();
                p4.Value = ut2Split;
                command.Parameters.Add(p4);
                
                var p5 = command.CreateParameter();
                p5.Value = maxHr;
                command.Parameters.Add(p5);

                var p6 = command.CreateParameter();
                p6.Value = minHr;
                command.Parameters.Add(p6);

                var p7 = command.CreateParameter();
                p7.Value = firstName;
                command.Parameters.Add(p7);

                var p8 = command.CreateParameter();
                p8.Value = lastName;
                command.Parameters.Add(p8);

                /*var result = $"Records affected: {command.ExecuteNonQuery()}";
                MessageBox.Show(result);*/
            }
            return false;
        }

        public static bool UpdateRowerFromDetails(string firstName, string lastName, string squad, string side,
            bool canScull, int bowsideRank, int strokesideRank, int scullRank)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                .ToString();

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    "UPDATE Athletes SET Squad = ?, Side = ?, CanScull = ?, BowsideRank = ?, StrokesideRank = ?, ScullRank = ? WHERE FirstName = ? and LastName = ?";

                var p1 = command.CreateParameter();
                p1.Value = squad;
                command.Parameters.Add(p1);

                var p2 = command.CreateParameter();
                p2.Value = side;
                command.Parameters.Add(p2);

                var p3 = command.CreateParameter();
                p3.Value = canScull;
                command.Parameters.Add(p3);

                var p4 = command.CreateParameter();
                p4.Value = bowsideRank;
                command.Parameters.Add(p4);

                var p5 = command.CreateParameter();
                p5.Value = strokesideRank;
                command.Parameters.Add(p5);

                var p6 = command.CreateParameter();
                p6.Value = scullRank;
                command.Parameters.Add(p6);

                var p7 = command.CreateParameter();
                p7.Value = firstName;
                command.Parameters.Add(p7);

                var p8 = command.CreateParameter();
                p8.Value = lastName;
                command.Parameters.Add(p8);

                /*var result = $"Records affected: {command.ExecuteNonQuery()}";
                MessageBox.Show(result);*/
            }
            return false;
        }

        public static bool RemoveRowerFromDatabase(string firstName, string lastName)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["AthleteManagementTools.Properties.Settings.RowingDatabaseConnectionString"]
                .ToString();

            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    "DELETE FROM Athletes WHERE FirstName = ? and LastName = ?";

                var p1 = command.CreateParameter();
                p1.Value = firstName;
                command.Parameters.Add(p1);

                var p2 = command.CreateParameter();
                p2.Value = lastName;
                command.Parameters.Add(p2);

                /*var result = $"Records affected: {command.ExecuteNonQuery()}";
                MessageBox.Show(result);*/
            }
            return false;
        }
    }
}