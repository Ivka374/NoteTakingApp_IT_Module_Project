﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace NoteTakingApp_IT_Module_Project.Data
{
    class Database
    {
        //CRUDUsingDBCommands Method
        //NOTE: Add Connection String ASAP!!!
        //Connection String Template: "Server=localhost; Database=databaseName; username = someUsername; password = somePassword"
        private static string connectionString = "Server=localhost; Database=noteapp; username = root; password = 54321ati";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
