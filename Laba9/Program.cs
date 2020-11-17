using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba9
{
    public class iPadOS
    {
        public iPadOS(int version)
        {
            Version = version;
            IsWorking = false;
        }
        public static int Version { get; set; }
        public static bool IsWorking { get; set; }
        public Upgrading Upgrade = () =>
        {
            Console.WriteLine("I have new version! Please download and install it");
            Version++;
            return Version;
        };

        public Upgrading Downgrade = () =>
        {
            Console.WriteLine(":(\nWhy do you hate this version?");

            if (Version > 1)
            {
                Version--;
            }
            return Version;
        };
        public Working Work = () =>
        {
            Console.WriteLine("I am working");

            IsWorking = true;
            return true;
        };
        public Working Relax = () =>
        {
            Console.WriteLine("I'm so tired");

            IsWorking = false;
            return false;
        };
    }
    public class iOS
    {
        public static int Version { get; set; }
        public static bool IsWorking { get; set; }
        public iOS(int version)
        {
            Version = version;
            IsWorking = false;
        }
        public Upgrading Upgrade = () =>
        {
            Console.WriteLine("I have new version! Please download and install it");
            Version++;
            return Version;
        };

        public Upgrading Downgrade = () =>
        {
            Console.WriteLine(":(\nWhy do you hate this version?");

            if (Version > 1)
            {
                Version--;
            }
            return Version;
        };
        public Working Work = () =>
        {
            Console.WriteLine("I am working");

            IsWorking = true;
            return true;
        };
        public Working Relax = () =>
        {
            Console.WriteLine("I'm so tired");

            IsWorking = false;
            return false;
        };
    }
    public class macOS
    {
        public macOS(int version)
        {
            Version = version;
            IsWorking = false;
        }
        public static int Version { get; set; }
        public static bool IsWorking { get; set; }
        public Upgrading Upgrade = () =>
        {
            Console.WriteLine("I have new version! Please download and install it");
            Version++;
            return Version;
        };

        public Upgrading Downgrade = () =>
        {
            Console.WriteLine(":(\nWhy do you hate this version?");
            if (Version > 1)
            {
                Version--;
            }
            return Version;
        };
        public Working Work = () =>
        {
            Console.WriteLine("I am working");
            IsWorking = true;
            return true;
        };
        public Working Relax = () =>
        {
            Console.WriteLine("I'm so tired");
            IsWorking = false;
            return false;
        };
    }

    public delegate int Upgrading();
    public delegate bool Working();
    public class User
    {
        public event Upgrading Upgrade;
        string Version { get; set; }
        public event Working Work;
        public void onUpgrade()
        {
            Console.WriteLine("Upgrade starting");
            Upgrade();
        }

        public void onWork()
        {
            Console.WriteLine("Working proccess will start soon");
            Work();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            iOS ios = new iOS(13);
            iPadOS ipados = new iPadOS(13);
            macOS macos = new macOS(11);
            User user = new User();
            //SomeDelegat test();
            user.Upgrade += ipados.Upgrade;
            user.Work += ios.Work;
            user.Work += macos.Work;
            user.Upgrade += macos.Downgrade;
            user.onUpgrade();
            user.onWork();
            Console.WriteLine($"{iOS.Version}, {iOS.IsWorking}, {iPadOS.Version}, {iPadOS.IsWorking}, {macOS.Version}, {macOS.IsWorking}");
            string str1 = "GoOd  mornin";
            Func<string, string> func;
            Action<string, char> action;
            func = ChangeString.OneSpace;
            str1 = func(str1);
            Console.WriteLine(str1);
            action = ChangeString.AddLetter;
            action(str1, 'g');
            func += ChangeString.Oo;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ChangeString.MyToApper;
            str1 = func(str1);
            Console.WriteLine(str1);
            func += ChangeString.AddPoint;
            str1 = func(str1);
            Console.WriteLine(str1);
        }
        static public class ChangeString
        {



            public static string OneSpace(string str)
            {
                int del = 0;
                for (int i = 0; i < str.Length; i++)
                {

                    if (str[i] == ' ')
                        if (str[i + 1] == ' ')
                            del = i + 1;
                }
                str = str.Remove(del, 1);


                return str;
            }

            public static void AddLetter(string str, char letter)
            {
                str = str + letter;
                Console.WriteLine(str);


            }

            public static string AddPoint(string str)
            {
                str = str + ".";

                return str;
            }

            public static string MyToApper(string str)
            {
                str = str.ToUpper();

                return str;
            }

            public static string Oo(string str)
            {
                str = str.Replace("O", "o");

                return str;
            }


        }
    }
}
