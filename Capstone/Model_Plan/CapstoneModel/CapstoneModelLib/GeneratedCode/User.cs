﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using CapstoneModelLib.GeneratedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class User
{
    public User(int ID, string userName, string passHash, string fName, string lName)
    {
        userID = ID;
        Username = userName;
        this.passHash = passHash;
        this.fName = fName;
        this.lName = lName;
    }

	public string Username
	{
		get;
		set;
	}

	private Address streetAddress
	{
		get;
		set;
	}

	private string passHash
	{
		get;
		set;
	}

	private string fName
	{
		get;
		set;
	}

	private string lName
	{
		get;
		set;
	}

	public virtual int userID
	{
		get;
		set;
	}

	public virtual bool Login(string enteredPass)
	{
        //would connect to the UserActionDBClass and allow them to login this method
		throw new System.NotImplementedException();
	}

}

