using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer;
using ConsoleApp1_User;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Collections.ObjectModel;
using System.Text.Json;
//using System.Text.Json.Serialization;

namespace ConsoleApp1_User
{
    internal static class AppLicationContext //: DbContext
    {
       

       public static void SaveUsersToFile(List<Class_User> users)
       {
           string filePath = "C:\\Users\\User\\Desktop\\навчання 3курс\\Домашні роботи\\Користувачі які заповнюються та записуються в файлC#\\ConsoleApp1_User\\UserDetails.json.txt";
      
              try
              {
               List<Class_User> existingUsers = LoadUsersFromFile(filePath);
             
                  // Додати нових користувачів до існуючих
                  foreach (var user in users)
                  {
                      if (!existingUsers.Any(existingUser => existingUser.Phone == user.Phone || existingUser.Email == user.Email))
                      {
                          existingUsers.Add(user);
                      }
                  }
             
               // Зберегти оновлені дані у файл
               string json = JsonSerializer.Serialize(existingUsers, new JsonSerializerOptions { WriteIndented = true });
               File.WriteAllText(filePath, json);
              }
             catch (Exception ex)
             {
                 Console.WriteLine($"Error writing to file: {ex.Message}");
             }
       }
      
      
       public static List<Class_User> LoadUsersFromFile(string filePath)
       {
           List<Class_User> existingUsers = new List<Class_User>();
      
           try
           {
               if (File.Exists(filePath))
               {
                   string json = File.ReadAllText(filePath);
                   existingUsers = JsonSerializer.Deserialize<List<Class_User>>(json);
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine($"Error reading from file: {ex.Message}");
           }
      
           return existingUsers;
       }
      
       public static void RemoveUserByIndexFromFile(int index)
       {
           string filePath = "C:\\Users\\User\\Desktop\\навчання 3курс\\Домашні роботи\\Користувачі які заповнюються та записуються в файлC#\\ConsoleApp1_User\\UserDetails.json.txt";
      
           try
           {
               List<Class_User> existingUsers = LoadUsersFromFile(filePath);
      
               // Перевірити чи індекс знаходиться в межах списку
               if (index >= 0 && index < existingUsers.Count)
               {
                   existingUsers.RemoveAt(index);
      
                   // Зберегти оновлені дані у файл
                   string json = JsonSerializer.Serialize(existingUsers, new JsonSerializerOptions { WriteIndented = true });
                   File.WriteAllText(filePath, json);
      
                   Console.WriteLine("User removed from file.");
               }
               else
               {
                   Console.WriteLine("Invalid index. User not removed.");
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine($"Error removing user from file: {ex.Message}");
           }
       }
        public static void UpdateUsersToFile(List<Class_User> users, int index, Class_User user)
        {
            string filePath = "C:\\Users\\User\\Desktop\\навчання 3курс\\Домашні роботи\\Користувачі які заповнюються та записуються в файлC#\\ConsoleApp1_User\\UserDetails.json.txt";

            try
            {
                List<Class_User> existingUsers = LoadUsersFromFile(filePath);

                // Додати нових користувачів до існуючих
                foreach (var use in users)
                {
                    for(int i = 0; i < existingUsers.Count; i++)
                    {
                    if (i == index)
                    {

                        existingUsers[i] = user;
                    }
                    
                    }
                }

                // Зберегти оновлені дані у файл
                string json = JsonSerializer.Serialize(existingUsers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

    }

}
