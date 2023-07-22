﻿using BussinessObject.Models;
using CinemaSystemWebapp.Utils;
using DataAccess.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Dao
{
    internal class UserDao
    {
        private static UserDao instance = null;
        private static object locked = new object();
        public static UserDao Instance
        {
            get
            {
                lock (locked)
                {
                    if (instance == null)
                    {
                        instance = new UserDao();
                    }
                    return instance;
                }

            }
        }

        public User getUserById(int id)
        {
            using var dbcontext = new CinemaSystemContext();
            User user = dbcontext.Users.FirstOrDefault(e => e.Id == id);
            return user;
        }

        public void updateUserInfor(User user, string name, string email, string? avatar)
        {
            using CinemaSystemContext dbcontext = new();
            user.Name = name.Trim();
            user.Email = email.Trim();
            if (avatar is not null)
            {
                user.AvatarUrl = $"/assets/{avatar}";
            }
            dbcontext.Users.Update(user);
            dbcontext.SaveChanges();
        }

        internal void AddToCard(User user, double money)
        {
            using CinemaSystemContext dbcontext = new();
            user.Balance += money;
            dbcontext.Users.Update(user);
            dbcontext.SaveChanges();
        }

        internal void changePassword(User user, string newPassword, string confirmPassword, string oldPassword)
        {

            if (!user.Password.Equals(Crypto.SHA256(oldPassword)))
            {
                throw new Exception("Old password not correct");
            }
            checkPassword(newPassword,confirmPassword ,user.Password);
          
            user.Password = Crypto.SHA256(newPassword);
            using var dbcontext = new CinemaSystemContext();
            dbcontext.Users.Update(user);
            dbcontext.SaveChanges();
        }

        internal User? findByEmail(string email)
        {
            using var dbcontext = new CinemaSystemContext();
            return dbcontext.Users.FirstOrDefault(u => u.Email == email);
        }

        internal User? Login(string email, string password)
        {
            using var dbcontext = new CinemaSystemContext();
            return dbcontext.Users.FirstOrDefault(u => u.Email == email && u.Password == Crypto.SHA256(password));
        }

        internal void ResetPassword(string password, string confirmPassword, User u)
        {
            checkPassword(password,confirmPassword,u.Password);
            u.Password = Crypto.SHA256(password);
            using var dbcontext = new CinemaSystemContext();
            dbcontext.Users.Update(u);
            dbcontext.SaveChanges();

        }

        internal void Signup(User user)
        {
            if (user is null)
            {
                throw new Exception("Data cannot be null");
            }

            if (!StringUtils.CheckPasswordValidate(user.Password))
            {
                throw new Exception("Password must conform regex");
            }
            using var dbcontext = new CinemaSystemContext();
            if (dbcontext.Users.SingleOrDefault(e => e.Email == user.Email) != null)
            {
                throw new Exception("Email already exits!!");
            }
            user.Password = Crypto.SHA256(user.Password);
            dbcontext.Users.Add(user);
            dbcontext.SaveChanges();

        }

        private void checkPassword(string newPassword, string confirmPassword, string oldPassword)
        {
            if ((oldPassword == Crypto.SHA256(newPassword)))
            {
                throw new Exception("New password and current password are the same");
            }
            if (!StringUtils.CheckPasswordValidate(newPassword))
            {
                throw new Exception("Password must conform regex");
            }
            if (newPassword != confirmPassword)
            {
                throw new Exception("Password and confirm-password are not the same");

            }

        }
    }
}
