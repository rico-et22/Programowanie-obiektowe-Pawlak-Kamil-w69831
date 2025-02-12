﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    public abstract class User
    {
        public string Username { get; set; }
        public User(string username)
        {
            Username = username;
        }
        public abstract void ShowMenu();
    }
}
