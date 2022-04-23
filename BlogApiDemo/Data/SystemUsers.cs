using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApiDemo.Data
{
    public class SystemUsers
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public static List<SystemUsers> FillModel()
        {
            var model = new List<SystemUsers>();

            model.Add(new SystemUsers()
            {
                ID = 132453,
                UserName = "admin",
                Password = "A*a1*2*3!!@#",
                Role = "Admin"
            });
            model.Add(new SystemUsers()
            {
                ID = 132453,
                UserName = "manager",
                Password = "*Aa123!!*",
                Role = "Manager"
            });
            model.Add(new SystemUsers()
            {
                ID = 132453,
                UserName = "user",
                Password = "Aa123!!",
                Role = "User"
            });

            return model;
        }
    }
}
