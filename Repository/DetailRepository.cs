using Dapper;
using HDot_Vew.Interface;
using HDot_Vew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HDot_Vew.Repository
{
    public class DetailRepository : IDetails
    {
        private IEnumerable<DetailsModel> alldatas;
        private IEnumerable<DetailsModel> alldata;

        private IConfiguration _configuration { get; set; }
        public DetailRepository(IConfiguration config)
        {
            _configuration = config;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqliteConnection(@"Data source=./Database/Demo3.db");
            }
        }
        string IDetails.insertdata(DetailsModel model)
        {
            string msg = null;
            try
            {
                using (var dbConnection =Connection)
                {
                    string sQuery = "INSERT INTO Details (name,age) Values(@Name,@Age)";
                    dbConnection.Open();
                    dbConnection.Execute(sQuery, new
                    {
                        Name=model.Name,
                        Age=model.Age

                    });
                    dbConnection.Close();
                    msg = "success";
                    return msg;
                  
                }
            }
            catch(Exception e) {
                msg = "fail";
                Console.WriteLine(e);
            }
            return msg;
        }

        public IEnumerable<DetailsModel> GetDetails()
        {
            using (var dbConnecction = Connection)
            {
                string sQuery = "SELECT * FROM Details";
                dbConnecction.Open();
                alldatas = dbConnecction.Query<DetailsModel>(sQuery);
                dbConnecction.Close();

            }
            return alldatas;
        }

        public string deletedata(DetailsModel model)
        {
            using (var dbConnection =Connection)
            {
                string sQuery = "DELETE FROM Details where name=@name AND age=@age";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new
                {
                    name = model.Name,
                    age=model.Age
                }) ;
                dbConnection.Close();
                return "deleted";

            }
        }

        public string editdata(DetailsModel model)
        {
            using (var dbConnection = Connection)
            {
                string uQuery = "UPDATE Details SET name=@Name,age=@Age where name=@Name";
                dbConnection.Open();
                dbConnection.Execute(uQuery, new
                {
                    Name = model.Name,
                    Age = model.Age
                });
                dbConnection.Close();
                return "Edited!";
            }
        }

        public string login(LoginModel model)
        {
            return "successs";
        }



        //string IDetails.GetDetails()
        //{


        //    using (var dbConnection = Connection)
        //    {
        //        string sQuery = "SELECT * FROM Details";
        //        dbConnection.Open();
        //        //alldata=dbConnection.Execute(sQuery);
        //        alldata = dbConnection.Query<DetailsModel>(sQuery);
        //        dbConnection.Close();
        //    }

        //    return "ok";
        //}
    }
}