using System;
using System.IO;
using System.Collections.Generic;

namespace SimplePayrollSoftware.ClassLib
{
    public class FileReader
    {
        public List<Staff> ReadFile(){
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = {", "};

            if (File.Exists(path)){
                using (StreamReader sr = new StreamReader(path)){
                    while (!sr.EndOfStream){
                        string[] results = sr.ReadLine().Split(separator[0]);
                        if (result[1].ToLower() == "admin"){
                            myStaff.Add(new Admin(result[0]));
                        } 
                        else if (result[1].ToLower() == "manager"){
                            myStaff.Add(new Manager(result[0]));
                        }
                        else{
                            Console.WriteLine("Role " + result[1] + " not a valid role.");
                        }
                    }
                    sr.Close();
                }
            }
            else {
                Console.WriteLine("File {0} does not exist", path);
            }
            
            return myStaff;
        }
    }
}