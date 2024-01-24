using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;


//using System.ComponentModel;
//using System.Runtime.CompilerServices;


namespace ConsoleApp1_User
{
    internal class Class_User 
    {
       [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        //public string Password;

        public Class_User ( string name, string email, int phone )
        {
           
          Name = name;
          Email = email;
          Phone = phone;
        }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }

    }
}
