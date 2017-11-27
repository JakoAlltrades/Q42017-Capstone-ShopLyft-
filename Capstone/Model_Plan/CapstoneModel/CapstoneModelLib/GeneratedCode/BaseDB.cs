﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseDB 
{
    public BaseDB(string dbAddress)
    {
        this.dbAddress = dbAddress;
        //Connect(); Comment for now Will swich to mongoDB ASP .NET service for the application
    }

	public string dbAddress
	{
		get;
		set;
	}

	private string dbPass
	{
		get;
		set;
	}

	private string dbLogin
	{
		get;
		set;
	}

    public MongoClient client { get; private set; }

	public virtual async void Connect()
	{
        //var connectionString = "mongodb://192.168.1.200:27017";
        //var client = new MongoClient(new MongoUrl("mongodb://127.0.0.1:27017"));
        client = new MongoClient(new MongoUrl(dbAddress));
        client.Settings.ConnectTimeout = new TimeSpan(0, 1, 30);
        client.ListDatabases();
        var state = client.Cluster.Description.State;
        if(state.ToString() != "Connected")
        {
            throw new Exception("Failed to connect to database");
        }
        /*Console.Write("State: " + state.ToString());
        var database = client.GetDatabase("personalshopperdb");
        //database.CreateCollection("users");
        var collection = database.GetCollection<BsonDocument>("users");

        BsonDocument address = new BsonDocument
            {
            {"Street", BsonValue.Create("356 s 1200 e") },
            {"City", BsonValue.Create("Salt Lake City") },
            {"Zipcode", BsonValue.Create("84102") },
            {"State", BsonValue.Create("UT") },
            {"apt#", BsonValue.Create("7") }
            };

        BsonDocument doc = new BsonDocument
            {
            {"fName", BsonValue.Create("John") },
            {"lName", new BsonString("Priem") },
            {"username", new BsonString("jpriem") },
            {"passhash", new BsonArray() },
            {"address",  address},
            {"userID", BsonValue.Create("1") }
            };
            */
        /*
         * To insert into the user table creates the user and stores their address as well
         * 

        await collection.InsertOneAsync(doc);*/

        /*
         * for reading enteries from the database
        using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
        {
            while(await cursor.MoveNextAsync())
            {
                IEnumerable<BsonDocument> batch = cursor.Current;
                foreach (BsonDocument document in batch)
                {
                    Console.WriteLine(document.ToString());
                    Console.WriteLine();
                }
            }
        }
        */

        //string json = doc.ToJson();
    }

}

