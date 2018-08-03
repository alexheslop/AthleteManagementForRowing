﻿using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;

namespace RowerAthleteManagement.Model
{
    public class AccessDatabaseComms
    {
        public List<Rower> ReadDatabase()
        {
            var rowerList = new List<Rower>();
            var queryString =
                "SELECT FirstName,LastName,Squad,Side,CanScull,BowsideRank,StrokesideRank,ScullRank,ErgTime FROM InitialTable";
            var _con = new OleDbConnection
            {
                ConnectionString = ConfigurationManager
                    .ConnectionStrings["RowerAthleteManagement.Properties.Settings.Sample_DatabaseConnectionString"]
                    .ToString()
            };

            var command = new OleDbCommand(queryString, _con);
            _con.Open();
            var reader = command.ExecuteReader();
            while (reader != null && reader.Read())
            {
                var newRower = new Rower
                {
                    LastName = reader.GetString(1),
                    Squad = reader.GetString(2),
                    Side = reader.GetString(3),
                    CanScull = reader.GetBoolean(4),
                    BowsideRank = reader.GetInt32(5),
                    StrokesideRank = reader.GetInt32(6),
                    ScullRank = reader.GetInt32(7),
                    FirstName = reader.GetString(0)
                };
                //newRower.ErgTime = reader.GetDouble(8);
                rowerList.Add(newRower);
            }

            reader?.Close();
            _con.Close();
            return rowerList;
        }
    }
}