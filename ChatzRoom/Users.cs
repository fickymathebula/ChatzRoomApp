using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChatzRoom
{
    class Users
    {
        private readonly string usersFile = @"C:\DataFiles\user.txt";
        //string usersData = "";
        private List<string> userFileData = new List<string>();
        
        public List<string> ReadUsersFile()
        {
            if (File.Exists(usersFile))
            {
                using (var str = new StreamReader(usersFile))
                {
                    String text;
                    while ((text = str.ReadLine()) != null)
                    {
                        //usersData += text + "\n";
                        userFileData.Add(text);
                    }
                }
            }
            else
            {
                Console.WriteLine("The file users.txt not found.");
            }

            return userFileData;
        }

    }
}


          

           