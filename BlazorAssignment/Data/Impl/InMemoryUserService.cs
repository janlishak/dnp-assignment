﻿using BlazorAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAssignment.Data.Impl
{
    public class InMemoryUserService : IUserService
    {
        private List<User> users;

        public InMemoryUserService()
        {
            users = new[]
                {
                new User
                {
                    UserName = "Lenka",
                    Password="password",
                    SecurityLevel = 3
                },
                new User
                {
                    UserName = "Lucia",
                    Password="pass",
                    SecurityLevel= 1
                }
            }.ToList();
        }
        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if(first==null)
            {
                throw new Exception("User not found");

            }
            if(!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }
            return first;
        }
    }
}
