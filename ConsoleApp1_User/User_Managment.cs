using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1_User;
using System.Windows;
using System.Data;
using System.Data.Common;
using SQLite;


namespace ConsoleApp1_User
{
    internal class User_Managment
    {
        public List<Class_User> Users { get; set; }

        public User_Managment()
        {
        Users = new List<Class_User>();
           
        }

        public void ADDUser(Class_User user)
        {
            Users.Add(user);
           
        }

        public void DeleteUser(int index)
        {
            Users.RemoveAt(index);
            AppLicationContext.RemoveUserByIndexFromFile(index);
        }

        public void ShowOllUsers()
        {
            foreach (Class_User user in Users)
            {
                Console.WriteLine(user.Name);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Phone);
            }

        }

        public void ShowUsersByName(string name)
        {
            foreach (Class_User user in Users)
            {
                if (user.Name == name || user.Email == name)
                {
                    Console.WriteLine(user.Name);
                    Console.WriteLine(user.Email);
                    Console.WriteLine(user.Phone);
                }
              

            }

        }

        public void SaveUserToFile()
        {
            AppLicationContext.SaveUsersToFile(Users);
        }

       
        public void UpdateUser(List<Class_User> Users, int index, Class_User user)
        {
          

               for (int i = 0; i < Users.Count; i++)
               {
                   if (i==index )
                   {
                  
                   Users[i] = user;
                   break;
                   }
               }
                    AppLicationContext.UpdateUsersToFile( Users ,index, user);
             
        }

    }
}
