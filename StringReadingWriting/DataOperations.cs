using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.Sql;


namespace StringReadingWriting
{
    class DataOperations
    {
        public string ReturnEntireDatabase()
        {
            var allData = String.Empty;

            using (var dbPasswordContext = new PasswordsDbContext())
            {
                foreach (var d in dbPasswordContext.Passwords)
                {
                    allData += d.UserName + "," + d.Name + "," + d.NewPass + ",";
                }
            }

            return allData;

        }
        
        public void WriteToNewDatabase(string dataToWrite)
        {
            using (var createNewTable = new PasswordsDbContext())
            {
                var dataFlag = 0;

                foreach (var item in createNewTable.Passwords)
                {
                    if (item.Name == "")
                    {
                        dataFlag = 0;
                    }
                    else
                    {
                        dataFlag = 1;
                    }
                }

                if (dataFlag == 0)
                {
                    createNewTable.Database.ExecuteSqlCommand(dataToWrite);
                }

            }

        }

        public void WriteToFile()
        {
            string toWrite = ReturnEntireDatabase();

            System.IO.Directory.CreateDirectory(@"C:\StringReadWrite");

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\StringReadWrite\backup.txt"))
            {
                writer.WriteLine(toWrite);
            }
        }

        public void DropTables()
        {
            using (var dropTablesContext = new PasswordsDbContext())
            {
                IList<Password> passwordList = new List<Password>();

                foreach (var entry in dropTablesContext.Passwords)
                {
                    passwordList.Add(entry);
                }

                dropTablesContext.Passwords.RemoveRange(passwordList);
                dropTablesContext.SaveChanges();

            }

        }

    }
}
