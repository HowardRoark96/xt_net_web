using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task5
{
    class Program
    {
        public static string FolderPath;

        public static string BackupPath;

        public static string RestorePath;

        //public static string FolderPath = @"C:\tmp\folder";

        //public static string BackupPath = @"C:\tmp\backUp";

        //public static string RestorePath = @"C:\tmp\storage";

        public static Dictionary<int, StateFolder> State = new Dictionary<int, StateFolder>();
        
        static void Main(string[] args)
        {
            int select = 0;

            SetPath();
            Console.Clear();

            do
            {
                try
                {
                    ShowMenu();

                    do
                    {
                        Console.Write("Choose the mode: ");
                    } while (!int.TryParse(Console.ReadLine(), out select));

                    switch (select)
                    {
                        case 1:
                            FileSystemWatcher watcher = CallWatcher();

                            if (File.Exists(BackupPath + "\\log.dat"))
                            {
                                ReadLog();
                            }
                            else
                            {
                                CopyFiles(FolderPath, BackupPath);
                                GetState();
                                WriteLog();
                            }

                            watcher.EnableRaisingEvents = true;

                            Console.WriteLine("Enter 0 for exit.");
                            while (Console.ReadLine() != "0") ;

                            watcher.EnableRaisingEvents = false;
                            break;

                        case 2:
                            if (File.Exists(BackupPath + "\\log.dat"))
                            {
                                ReadLog();
                            }
                            BackUpMode();
                            break;

                        case 3:
                            SetPath();
                            break;

                        case 0:
                            break;

                        default:
                            throw new ArgumentException("Invalid input value. Try again.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error : " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Press any button to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            while (select != 0);
        }

        static void ShowMenu()
        {
            Console.WriteLine("Task 05 FILES");
            Console.WriteLine(" 1. Watching mode\n" +
                              " 2. Backup mode\n" +
                              " 3. Set paths\n" +
                              " 0. Exit \n" +
                              new string('-', 30));
        }
        private static void OnRename(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("Is renamed : {0}  to  {1} ", e.OldName, e.Name);
            GetState();
            WriteLog();
            string tmp = BackupPath + "\\" + e.Name;

            if (File.Exists(e.FullPath))
            {
                Directory.CreateDirectory(tmp);
                File.Copy(e.FullPath, tmp + "\\" + DateTime.Now.ToString("HH_mm_ss_ffff"));
            }
        }

        private static void OnCreate(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Is created : {0}", e.Name);
            GetState();
            WriteLog();

            string tmp = BackupPath + "\\" + e.Name;

            if (File.Exists(e.FullPath))
            {
                Directory.CreateDirectory(tmp);
                File.Copy(e.FullPath, tmp + "\\" + DateTime.Now.ToString("HH_mm_ss_ffff"));
            }
        }

        private static void OnDelete(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("Is deleted : {0}", e.Name);
            GetState();
            WriteLog();
        }

        private static void OnChange(object sender, FileSystemEventArgs e)
        {
            var a = State.Last().Value.State.Where(x => x.Name == e.Name);
            foreach (var item in a)
            {
                FileInfo file = new FileInfo(e.FullPath);
                if (item.ChangeTime == file.CreationTime)
                {
                    Console.WriteLine("It's the same file.");
                    return;
                }
            }

            Console.WriteLine("Is changed : {0}", e.Name);
            GetState();
            WriteLog();

            string tmp = BackupPath + "\\" + e.Name;

            if (File.Exists(e.FullPath))
            {
                Directory.CreateDirectory(tmp);
                File.Copy(e.FullPath, tmp + "\\" + DateTime.Now.ToString("HH_mm_ss_ffff"));
            }
        }

        public static FileSystemWatcher CallWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher(FolderPath);

            watcher.IncludeSubdirectories = true;

            watcher.NotifyFilter =
                NotifyFilters.LastAccess |
                NotifyFilters.LastWrite |
                NotifyFilters.Size |
                NotifyFilters.FileName |
                NotifyFilters.DirectoryName;

            watcher.Filter = "*.*";

            watcher.Changed += OnChange;
            watcher.Deleted += OnDelete;
            watcher.Created += OnCreate;
            watcher.Renamed += OnRename;

            return watcher;
        }

        public static void SetPath()
        {
            Console.WriteLine("Enter the path for watching : ");
            string tmp = Console.ReadLine();

            if (!Directory.Exists(tmp))
            {
                throw new Exception("The folder dosen't exist.");
            }
            FolderPath = tmp;

            Console.WriteLine("Enter the path for store : ");

            tmp = Console.ReadLine();
            if (!Directory.Exists(tmp))
            {
                throw new Exception("The folder dosen't exist.");
            }
            BackupPath = tmp;

            Console.WriteLine("Enter the path for restore : ");

            tmp = Console.ReadLine();
            if (!Directory.Exists(tmp))
            {
                Console.WriteLine("The folder dosen't exist.");
                Console.WriteLine("Do you want to create the folder? (Y/N) :");
                string choose = Console.ReadLine();
                while (choose == "Y" && choose == "y" && choose == "N" && choose == "n")
                {
                    Console.WriteLine("Invalid value, try again.");
                    choose = Console.ReadLine();
                }

                choose = choose.ToUpper();

                switch (choose)
                {
                    case "Y":
                        Directory.CreateDirectory(tmp);
                        break;

                    case "N":
                        break;
                    default:
                        break;
                }

            }
            RestorePath = tmp;
        }

        public static void BackUpMode()
        {
            if (State.Count == 0)
            {
                throw new Exception("The storage is empty.");
            }

            foreach (KeyValuePair<int, StateFolder> item in State)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value.StateTime);
            }

            int key;

            StateFolder StateRestoreFolder;

            do
            {
                Console.WriteLine("Choose the time to backup : ");
            }
            while (!int.TryParse(Console.ReadLine(), out key) || !State.TryGetValue(key, out StateRestoreFolder));

            RestoreFiles(StateRestoreFolder);
        }

        public static void WriteLog()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(BackupPath + "\\log.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, State);
            }
        }

        public static void ReadLog()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(BackupPath + "\\log.dat", FileMode.OpenOrCreate))
            {
                //State = (List<StateFolder>)formatter.Deserialize(fs);

                State = (Dictionary<int, StateFolder>)formatter.Deserialize(fs);
            }
        }

        public static void GetState()
        {
            DirectoryInfo dir = new DirectoryInfo(FolderPath);

            State.Add(State.Count, new StateFolder(DateTime.Now));

            foreach (FileInfo item in dir.GetFiles("*", SearchOption.AllDirectories))
            {
                var a = State.Last();
                a.Value.AddStateFile(item);
            }
        }

        public static void RestoreFiles(StateFolder StateTime)
        {
            foreach (var item in Directory.GetFiles(RestorePath, "*.*", SearchOption.AllDirectories))
            {
                File.Delete(item);
            }

            if (Directory.Exists(RestorePath))
            {
                Directory.Delete(RestorePath, true);
            }

            Directory.CreateDirectory(RestorePath);

            foreach (StateFile item in StateTime.State)
            {
                DirectoryInfo dir = new DirectoryInfo(BackupPath + "\\" + item.Name);

                FileInfo a = null;

                FileInfo file = new FileInfo(item.Path);

                List<FileInfo> store = new List<FileInfo>();

                a = (from obj in dir.GetFiles()
                     where obj.CreationTime >= StateTime.StateTime
                     select obj).FirstOrDefault();

                if (a == null)
                {
                    a = dir.GetFiles().Last();
                }

                if (a != null)
                {
                    DirectoryInfo parent = new DirectoryInfo(RestorePath + file.DirectoryName.Remove(0, FolderPath.Length));
                    do
                    {
                        if (!Directory.Exists(parent.FullName))
                        {
                            Directory.CreateDirectory(parent.FullName);
                        }
                        parent = parent.Parent;
                    } while (!Directory.Exists(parent.FullName));

                    File.Copy(a.FullName, RestorePath + item.Path.Remove(0, FolderPath.Length));

                    Console.WriteLine("Files restored.");
                }
            }


        }

        public static void CopyFiles(string formPath, string toPath)
        {
            DirectoryInfo dir = new DirectoryInfo(formPath);

            foreach (FileInfo item in dir.GetFiles("*", SearchOption.AllDirectories))
            {
                if (!Directory.Exists(toPath + item.Name))
                {
                    Directory.CreateDirectory(toPath + "\\" + item.Name);
                }

                File.Copy(item.FullName, toPath + "\\" + item.Name + "\\" + DateTime.Now.ToString("HH_mm_ss_ffff"));
            }
        }
    }
}
