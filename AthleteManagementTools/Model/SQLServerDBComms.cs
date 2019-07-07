using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AthleteManagementTools.Model
{
    class SqlServerDbComms
    {
        private static ObservableCollection<Rower> _rowerList;

        public static ObservableCollection<Rower> SelectSquad(string squad, string side, string sort)
        {
            const string datastring = "SELECT FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,PB2k,PB5k,PB30r20,UT2Split,MaxHR,MinHR,Injured FROM Athletes";

            var sqlQueryString = datastring + GenerateSquadString(squad) + GenerateSideString(side) +
                                 GenerateOrderString(sort, side);


            var athleteList = ReadAthleteDatabase(sqlQueryString);
            return athleteList;
        }

        private static string GenerateOrderString(string sort, string side)
        {
            var output = "";
            switch (sort)
            {
                case "First Name":
                    output = " ORDER BY FirstName ASC, LastName ASC";
                    break;
                case "Last Name":
                    output = " ORDER BY LastName ASC, FirstName ASC";
                    break;
                case "Injured":
                    output = " ORDER BY Injured DESC, Squad DESC, LastName ASC";
                    break;
                case "Scull Rank":
                    output = " ORDER BY Squad DESC, ScullRank ASC";
                    break;
                case "Sweep Rank":
                    output = $" ORDER BY Squad DESC, Side DESC, {side}Rank ASC";
                    break;
                default:
                    output = " ORDER BY Squad DESC, LastName ASC";
                    break;

            }

            return output;
        }

        private static string GenerateSideString(string side)
        {
            var output = "";
            switch (side)
            {
                case "Bowside":
                case "Strokeside":
                    output = $" AND (Side = '{side}' OR Side = 'Both')";
                    break;
                case "Scullers":
                    output = " AND (CanScull = true)";
                    break;
                default:
                    output = "";
                    break;

            }

            return output;
        }

        private static string GenerateSquadString(string squad)
        {
            var output = "";
            switch (squad)
            {
                case "All":
                    output = " WHERE (Squad LIKE 'Senior%' OR Squad LIKE 'Novice%')";
                    break;
                case "Seniors":
                case "Novices":
                    squad = squad.Remove(squad.Length - 1);
                    output = $" WHERE (Squad LIKE '{squad}%')";
                    break;
                case "Injured":
                    output = " WHERE (Injured = true)";
                    break;
                default:
                    output = $" WHERE (Squad = '{squad}')";
                    break;

            }

            return output;
        }

        private static ObservableCollection<Rower> ReadAthleteDatabase(string sqlQuery)
        {
            _rowerList = new ObservableCollection<Rower>();
            var con = new SqlConnection()
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["SQLServerInstance"]
                    .ToString()
            };

            var command = new SqlCommand(sqlQuery, con);
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
                newRower.BowsideRank = reader.GetInt32(5);
                newRower.StrokesideRank = reader.GetInt32(6);
                newRower.ScullRank = reader.GetInt32(7);
                newRower.Pb2K = reader.GetString(8);
                newRower.Pb5K = reader.GetString(9);
                newRower.Pb30R20 = reader.GetString(10);
                newRower.Ut2Split = reader.GetString(11);
                newRower.MaxHr = reader.GetInt32(12);
                newRower.MinHr = reader.GetInt32(13);
                newRower.Injured = reader.GetBoolean(14);
                _rowerList.Add(newRower);
            }

            reader?.Close();
            con.Close();
            return _rowerList;
        }

        public static bool WritePersonToDatabase(string firstName, string lastName, string squad, string side, bool canScull,
            int bowsideRank, int strokesideRank, int scullRank, string pb2K, string pb5K, string pb30R20, string ut2Split)
        {
            var con = new SqlConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["SQLServerInstance"]
                    .ToString()
            };
            var cmd = new SqlCommand();
            if (con.State != ConnectionState.Open)
                con.Open();
            cmd.Connection = con;
            var command = new SqlCommand
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
            var con = new SqlConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["SQLServerInstance"]
                    .ToString()
            };
            const string queryString = "SELECT BoatName,Seats,Cox,Scull,classRank FROM Boats";

            var command = new SqlCommand(queryString, con);
            con.Open();
            var reader = command.ExecuteReader();
            while (reader != null && reader.Read())
            {
                var newRower = new Boat
                {
                    BoatName = reader.GetString(0),
                    Seats = reader.GetInt32(1),
                    Cox = reader.GetBoolean(2),
                    Scull = reader.GetBoolean(3),
                    ClassRank = reader.GetInt32(4),
                };

                boatCollection.Add(newRower);
            }

            reader?.Close();
            con.Close();
            return boatCollection;
        }

        public static bool WriteBoatToDatabase(string boatName, int seats, bool cox, bool scull, int classRank)
        {
            var con = new SqlConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["SQLServerInstance"]
                    .ToString()
            };
            if (con.State != ConnectionState.Open)
                con.Open();
            var command = new SqlCommand
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

        public static bool UpdateRowerFromErgProfile(string firstName, string lastName, string pb2K, string pb5K, string pb30R20, string ut2Split, int maxHr, int minHr)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["SQLServerInstance"]
                .ToString();

            using (var connection = new SqlConnection(connectionString))
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

                command.ExecuteNonQuery();
            }
            return false;
        }

        public static bool UpdateRowerFromDetails(string firstName, string lastName, string squad, string side,
            bool canScull, int bowsideRank, int strokesideRank, int scullRank, bool injured)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["SQLServerInstance"]
                .ToString();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    "UPDATE Athletes SET Squad = ?, Side = ?, CanScull = ?, BowsideRank = ?, StrokesideRank = ?, ScullRank = ?, Injured = ? WHERE FirstName = ? and LastName = ?";

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
                p7.Value = injured;
                command.Parameters.Add(p7);

                var p8 = command.CreateParameter();
                p8.Value = firstName;
                command.Parameters.Add(p8);

                var p9 = command.CreateParameter();
                p9.Value = lastName;
                command.Parameters.Add(p9);

                command.ExecuteNonQuery();
                /*var result = $"Records affected: {command.ExecuteNonQuery()}";
                MessageBox.Show(result);*/
            }
            return false;
        }

        public static bool RemoveRowerFromDatabase(string firstName, string lastName)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["SQLServerInstance"]
                .ToString();

            using (var connection = new SqlConnection(connectionString))
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

                command.ExecuteNonQuery();
                /*var result = $"Records affected: {command.ExecuteNonQuery()}";
                MessageBox.Show(result);*/
            }
            return false;
        }
    }
}
