﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OrderItem
{
    public OrderItem(string name, double maxPrice, double actualPrice, int amount)
    {
        this.name = name;
        this.maxPrice = maxPrice;
        this.actualPrice = actualPrice;
        this.amount = amount;
    }

	public virtual string name
	{
		get;
		set;
	}

	public virtual double maxPrice
	{
		get;
		set;
	}

	public virtual double actualPrice
	{
		get;
		set;
	}

    public virtual int amount
    {
        get;
        set;
    }

	public virtual void NotifyCustomer()
	{
        //this method would use the DBconnector to send the Customer a notification
		throw new System.NotImplementedException();
	}

}

