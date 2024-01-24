using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1_User;

namespace ConsoleApp1_User
{
    internal class Menu_User
    {
        static void Main()
        {
            string Name;
            string Email;
            int Phone;
            int index = 0;
            Class_User user = new Class_User( "Sara", "sara@ua.fm", 0977128555);
            Class_User user2 = new Class_User("Max", "max@gmail.com", 0632152230);

            User_Managment userManagment = new User_Managment();
            
            userManagment.ADDUser(user);
            userManagment.ADDUser(user2);


                Console.WriteLine("        Menu\n 1. ADD new User\n 2.Show Oll Users\n 3.Show Users by Name and Email\n 4. Delete Users\n 5.Update Users\n 6.Seve and Read from file\n 7.Exit\n ");
            do
            {
                //Console.Clear();
                index = int.Parse(Console.ReadLine());
                switch (index)
                {
                    
                    case 1:
                        {
                            Console.WriteLine("Name =");
                            Name = Console.ReadLine();
                            Console.WriteLine("Email =");
                            Email = Console.ReadLine();
                            Console.WriteLine("Phone =");
                            Phone = int.Parse(Console.ReadLine());
                            Class_User user3 = new Class_User(Name, Email, Phone);
                            userManagment.ADDUser(user3);
                            //.ShowOllUsers();

                        }
                        break;
                    case 2:
                        {
                            userManagment.ShowOllUsers();

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Name =");
                            Name = Console.ReadLine();
                            userManagment.ShowUsersByName(Name);
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Id_Users =");
                            int Id_Users = int.Parse(Console.ReadLine());
                            userManagment.DeleteUser(Id_Users);
                        }
                        break;
                    case 5:
                        {
                            Console.WriteLine("Name =");
                            Name = Console.ReadLine();
                            Console.WriteLine("Email =");
                            Email = Console.ReadLine();
                            Console.WriteLine("Phone =");
                            Phone = int.Parse(Console.ReadLine());
                            Class_User user3 = new Class_User(Name, Email, Phone);
                            Console.WriteLine("Id_Users =");
                            int Id_Users = int.Parse(Console.ReadLine());
                            userManagment.UpdateUser(userManagment.Users, Id_Users, user3);

                        }
                        break;
                    case 6:
                        {
                            userManagment.SaveUserToFile();
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Enter number correctly");
                        }
                        break;

                }

            }
            while (index != 7);
        }

    }
}
