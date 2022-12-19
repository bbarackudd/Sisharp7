using System.Runtime.ConstrainedExecution;

namespace Csharp7
{
    internal class Program
    {
        static void Main()
        {
            Console.Clear();
            string path = " ";
            List<Prop> props = new List<Prop>();
            while (true)
            {
                Console.SetCursorPosition(0, 1);
                if (path == " ")
                {
                    DriveInfo[] diski = DriveInfo.GetDrives();
                    foreach (DriveInfo disk in diski)
                    {
                        double vsego = disk.TotalSize;
                        double svobodno = disk.AvailableFreeSpace;
                        string name = $"Имя диска:{disk.Name}: cвободно {svobodno} из {vsego}";
                        props.Add(new Prop(name, disk.Name, true));
                    }
                }

                else
                {
                    props.Clear();
                    props = Papka.Get(path);
                }

                int stop = 0;
                Strelka strelka = new Strelka();
                strelka.pos = 1;
                strelka.minpos = 0;
                strelka.maxpos = 1;

                foreach (Prop prop in props)
                {
                    strelka.maxpos++;
                    Console.WriteLine("  " + prop.name);
                }

                while (stop != 1)
                {

                    Console.SetCursorPosition(0, strelka.pos);
                    Console.Write("→");
                    Console.SetCursorPosition(0, strelka.pos + 1);
                    ConsoleKey key = Console.ReadKey().Key;
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            Console.SetCursorPosition(0, strelka.pos);
                            Console.Write(" ");

                            strelka.pos--;

                            if (strelka.pos == strelka.minpos)
                            {
                                strelka.pos++;
                            }

                            break;

                        case ConsoleKey.DownArrow:
                            Console.SetCursorPosition(0, strelka.pos);
                            Console.Write(" ");

                            strelka.pos++;

                            if (strelka.pos == strelka.maxpos)
                            {
                                strelka.pos--;
                            }

                            break;
                        case ConsoleKey.Enter:
                            stop++;
                            Prop prop = props[strelka.pos - 1];
                            if (prop.papka)
                            {
                                path = prop.path;
                                Console.Clear();
                            }
                            break;
                    }
                }
            }
        }
    }
}
