using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RegistryTask
{
    class Program
    {
       static string subfolderPath  ;
        static string KeyName;
       static void Write()
        {
        RegistryKey BaseFolderPath = Registry.CurrentUser;
            RegistryKey registryKey = BaseFolderPath;
            RegistryKey SubKey = registryKey.CreateSubKey(KeyName);
            Console.WriteLine("Enter Text");
           string text= Console.ReadLine();
            
            SubKey.SetValue(KeyName, text);
        }

        static void Read1()
        {
            RegistryKey BaseFolderPath = Registry.CurrentUser;

            RegistryKey registryKey = BaseFolderPath;
            RegistryKey SubKey = registryKey.OpenSubKey(subfolderPath);

            if (SubKey != null)
            {
                list.Add(SubKey.GetValue(KeyName).ToString());
            }
            }
            static void Read2()
        {
            RegistryKey BaseFolderPath = Registry.ClassesRoot;

            RegistryKey registryKey = BaseFolderPath;
            RegistryKey SubKey = registryKey.OpenSubKey(subfolderPath);

            if (SubKey != null)
            {
                list.Add(SubKey.GetValue(KeyName).ToString());
            }

        }

            static void Read3()
        {
            RegistryKey BaseFolderPath = Registry.LocalMachine;

            RegistryKey registryKey = BaseFolderPath;

            RegistryKey SubKey = registryKey.OpenSubKey(subfolderPath);

            if (SubKey != null)
            {

                list.Add(SubKey.GetValue(KeyName).ToString());


            }

        }
        static void Read4()
        {
            RegistryKey BaseFolderPath = Registry.Users;

            RegistryKey registryKey = BaseFolderPath;
            RegistryKey SubKey = registryKey.OpenSubKey(subfolderPath);

            if (SubKey != null)
            {
                list.Add(SubKey.GetValue(KeyName).ToString());
            }

        }
        static void Read5()
        {
            RegistryKey BaseFolderPath = Registry.CurrentConfig;

            RegistryKey registryKey = BaseFolderPath;
            RegistryKey SubKey = registryKey.OpenSubKey(subfolderPath);

            if (SubKey != null)
            {
                list.Add(SubKey.GetValue(KeyName).ToString());
                

            }
            
        }






        static string Read()
        {
            RegistryKey BaseFolderPath = Registry.CurrentConfig;

            RegistryKey registryKey = BaseFolderPath;
            RegistryKey SubKey = registryKey.OpenSubKey(subfolderPath);
            
            if(SubKey != null)
            {
            return  SubKey.GetValue(KeyName).ToString();

            }
            return null;

        }
        static Task task1;
        static Task task2;
       static Task task3;
       static Task task4;
        static Task task5;
       static List<string> list = new List<string>();
        static AutoResetEvent ManualResetEvent = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            KeyName = "aKele";
            subfolderPath = "aKele";
        var tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;
            task1 = Task.Run(() => Read1());
            task2 = Task.Run(() => Read2());
            task3 = Task.Run(() => Read3());
            task4 = Task.Run(() => Read4());
            task5 = Task.Run(() => Read5());
            Task.WaitAll(task1, task2, task3, task4, task5);
            if(list.Count!=0)
            {

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            }
            else
            {
                Console.WriteLine("FolderName");
                Console.ReadLine();
                Console.WriteLine("Enter FileName");
                KeyName = Console.ReadLine();
                if (Read() != null)
                {
                    Console.WriteLine(Read());
                }
                else
                {
                    Write();
                }

            }
        }
    }
}
