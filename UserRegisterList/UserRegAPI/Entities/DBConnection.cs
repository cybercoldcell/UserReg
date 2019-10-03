using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegAPI.Entities
{
    public class DBConnection
    {
        public static string DBConnectionString()
        {
            IConfigurationBuilder objBuilder = new ConfigurationBuilder();
            objBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var objConfig = objBuilder.Build();
            String objConnectionString = "";

            return   objConnectionString = objConfig.GetConnectionString("UserRegContext");
        }
    }
}
