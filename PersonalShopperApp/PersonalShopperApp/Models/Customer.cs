﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Android.OS;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalShopperApp.Models
{
    public class Customer : User
    {
        public Customer(int ID, string userName, byte[] passHash, string fName, string lName, Address address) : base(ID, userName, passHash, fName, lName, address)
        {
        }

    }
}

