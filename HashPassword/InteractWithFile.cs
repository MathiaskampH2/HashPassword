using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HashPassword
{
    public class InteractWithFile
    {

        public void SaveUserCredentialsToFile(string username, string hashedPassword)
        {
            string path = (@".\userTable\" + username + ".txt");

            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(hashedPassword);
                sw.Close();
            }
            
        }


        public List<string> ReadPasswordFromFile(string username)
        {
            List<string> passwordList = new List<string>();
            string path = (@".\userTable\" + username + ".txt");

            passwordList = File.ReadAllLines(path).ToList();
            
            return passwordList;
        }

    }
}