using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace StringReadingWriting
{
    class FileOperations
    {
        public void writeToFile(string passName, string userName, string pass)
        {
            var nameToWrite = passName;
            var userNametoWrite = userName;
            var passToWrite = pass;

            Random randomNumber = new Random();

            using (var dbPasswordContext = new PasswordsDbContext())
            {
                var userNamePassword = new Password() { Name = nameToWrite, UserName = userNametoWrite, NewPass = passToWrite };

                dbPasswordContext.Passwords.Add(userNamePassword);
                dbPasswordContext.SaveChanges();

            }
        }

        public string readFromFile(string pathName)
        {
            var textFromFile = File.ReadAllText(pathName);

            return textFromFile;
            
        }

        public string returnSQL(string databaseString)
        {
            List<string> splitString = databaseString.Split(',').ToList();
            var sqlString = "INSERT INTO passwords (Name, UserName, NewPass)VALUES";

            for(int i = 0; i < splitString.Count - 2; )
            {
                sqlString += "(";
                for(int y = 0; y < 3; y++)
                {
                    if (y == 2)
                    {
                        sqlString += "'" + splitString[i] + "'";
                    }
                    else
                    {
                        sqlString += "'" + splitString[i] + "',";
                    }
                    
                    i++;
                }
                sqlString += "),";
            }            

            sqlString = sqlString.Remove(sqlString.LastIndexOf(','));
            sqlString += ";";

            return sqlString;
        }

    }
}
