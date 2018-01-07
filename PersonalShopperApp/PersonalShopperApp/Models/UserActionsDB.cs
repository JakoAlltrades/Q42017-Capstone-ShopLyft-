﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PersonalShopperApp.Models
{
    public class UserActionsDB : BaseDB
    {
        private int curUserID;
        private byte[] passwordSalt =
        {
            90,152,15,166,227,113,149,89,123,90,28,129,147,99,79,214,
            121,141,229,245,189,116,128,251,190,200,26,65,54,53,118,161,
            195,252,161,244,112,87,169,10,110,0,220,170,17,103,201,200,
            215,136,11,156,67,196,47,113,45,196,237,95,219,218,240,52,
            169,168,140,75,27,228,31,94,17,250,20,38,139,1,42,208,
            92,208,184,95,216,64,20,88,51,10,70,198,231,23,19,190,
            0,92,1,89,217,227,110,5,144,132,249,242,67,19,144,107,
            116,54,192,217,5,20,40,33,76,97,254,108,181,160
        };

        public UserActionsDB() : base()
        {
        }

        public int GetCurUserIDAsync()
        {
            List<int> IDs = new List<int>();
            int curID = 0;
            try
            {
                connection.Open();
                ConnectionState state = connection.State;
                if (state == ConnectionState.Open)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("SELECT userID ");
                        sb.Append("FROM dbo.Users ");
                        String sql = sb.ToString();

                            using (SqlCommand command = new SqlCommand(sql, connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        IDs.Add(reader.GetInt32(0));
                                    }
                                }
                            }
                        }
                        else
                        {
                            //error
                        }
                        
                        for (int j = 0; j < IDs.Count; j++)
                        {
                            if (curID <= IDs.ElementAt(j))
                            {
                                curID = IDs.ElementAt(j) + 1;
                            }
                        }
                    }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            
            return curID;
        }

        private User curUser
        {
            get;
            set;
        }

        public byte[] Hash(string value)
        {
            return Hash(Encoding.UTF8.GetBytes(value));
        }

        public byte[] Hash(byte[] value)
        {
            byte[] saltedValue = value.Concat(passwordSalt).ToArray();

            return new SHA256Managed().ComputeHash(saltedValue);
        }

        public bool ConfirmPassword(string password, byte[] storedHash)
        {
            byte[] passwordHash = Hash(password);

            return storedHash.SequenceEqual(passwordHash);
        }

        public virtual User SignIn(String userName, string Password)
        {
            User user = null;
            if (connection.State == ConnectionState.Open)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * ");
                sb.Append("FROM dbo.Users ");
                sb.Append("Where userName='" + userName + "'");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int zipCode, apt;
                            int? aptNum;
                            Int32.TryParse(reader.GetString(8), out zipCode);
                            if(!Int32.TryParse(reader.GetString(9), out apt))
                            {
                                aptNum = null;
                            }
                            else
                            {
                                aptNum = apt;
                            }
                            user = new User(reader.GetInt32(0), reader.GetString(1), reader.GetSqlBytes(2).Value, reader.GetString(3), reader.GetString(4), new Address(reader.GetString(5), reader.GetString(6), reader.GetString(7), zipCode, aptNum));
                        }
                    }
                }
            }
            else
            {
                //error
            }
            return user;
        }

        public async System.Threading.Tasks.Task<bool> CheckIfUsernameUsedAsync(string newUsername)
        {
            bool usernameUsed = false;
            List<string> userNames = new List<string>();
            if (connection.State == ConnectionState.Open)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT userName ");
                sb.Append("FROM dbo.Users ");
                sb.Append("Where userName='" + newUsername+"'");
                String sql = sb.ToString();

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            usernameUsed = true;
                        }
                    }
                }
            }
            else
            {
                //error
            }
            return usernameUsed;
        }

        public virtual async System.Threading.Tasks.Task<bool> CreateUserAsync(User user)
        {
            bool userCreated = false;
            if (!(CheckIfUsernameUsedAsync(user.Username).Result))
            {
            //    var database = client.GetDatabase("personalshopperdb");
            //    var collection = database.GetCollection<User>("users");
            //    BsonDocument doc = new BsonDocument();
            //    BsonDocumentWriter documentWriter = new BsonDocumentWriter(doc);
            //    BsonSerializer.Serialize(documentWriter, typeof(User), user);
            //    if (!doc.IsBsonNull)
            //    {
            //        await collection.InsertOneAsync(user);
            //        //check if new User/customer was inserted via linq
            //        User pulledUser = collection.AsQueryable<User>().Where(x => x.userID == user.userID).Select(x => x).First();
            //        //User pulledUser = BsonSerializer.Deserialize<User>(pulledDoc);
            //        if (pulledUser.userID == user.userID)
            //        {
            //            userCreated = true;
            //            curUser = user;
            //        }

            //    }
            }
            return userCreated;
        }

        public virtual async System.Threading.Tasks.Task<bool> EditUserAsync(User user)
        {
            bool userUpdated = false;
            if (user.userID == curUser.userID)
            {
            //    var database = client.GetDatabase("personalshopperdb");
            //    var collection = database.GetCollection<BsonDocument>("users");
            //    BsonDocument bsonUser = new BsonDocument();
            //    BsonDocumentWriter documentWriter = new BsonDocumentWriter(bsonUser);
            //    BsonSerializer.Serialize(documentWriter, typeof(User), user);
            //    if (!bsonUser.IsBsonNull)
            //    {
            //        using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
            //        {
            //            while (await cursor.MoveNextAsync())
            //            {
            //                IEnumerable<BsonDocument> batch = cursor.Current;
            //                foreach (BsonDocument document in batch)
            //                {
            //                    User temp = BsonSerializer.Deserialize<User>(document);
            //                    if (temp.userID == curUser.userID)
            //                    {
            //                        collection.UpdateOne<BsonDocument>(x => x == document, bsonUser);
            //                        userUpdated = true;
            //                    }
            //                }
            //            }
            //        }

            //    }
            }
            else
            {
                throw new Exception("MAJOR ERROR: the userID has changed between Editing the user and the current signed in user");
            }
            return userUpdated;
        }

    }

}