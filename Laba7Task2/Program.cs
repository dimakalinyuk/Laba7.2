using System;
using System.Collections;
using System.IO;

namespace Dima_OOP_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Key.KKEY();
        }
    }
    class Teachers : IComparable
    {
        public int Number;
        public DateTime Data;
        public string Kaf;
        public string PIB;
        public string Stup;
        public int Staz;
        public Teachers(int number, string pib, DateTime date, string kaf, string stup, int staz)
        {
            PIB = pib;

            Number = number;
            Data = date;
            Kaf = kaf;
            Stup = stup;
            Staz = staz;
        }
        public int CompareTo(object obj)
        {
            Teachers p = (Teachers)obj;
            if (this.Data > p.Data) return 1;
            if (this.Data < p.Data) return -1;
            return 0;
        }
        public void Data1(Teachers[] a)
        {
            Console.WriteLine("\nСортування за датою:");
            Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15} {5,-10}", "№", "ПІБ", "Дата", "Кафедра", "Ступінь", "Стаж");


            Array.Sort(a);
            foreach (Teachers elem in a) elem.Inf();
        }
        public void Inf()
        {
            Console.WriteLine("{0,-15}{1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", Number, PIB, Data.ToShortDateString(), Kaf, Stup, Staz);
        }
        public class SortByDate : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Teachers p1 = (Teachers)ob1;
                Teachers p2 = (Teachers)ob2;
                if (p1.Data > p2.Data) return 1;
                if (p1.Data < p2.Data) return -1;
                return 0;
            }
        }
        public void One(Teachers[] a)
        {
            Console.WriteLine("\nСортування за датою:");
            Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15} {5,-10}", "№", "ПІБ", "Дата", "Кафедра", "Ступінь", "Стаж");
            Array.Sort(a, new Teachers.SortByDate());
            foreach (Teachers elem in a) elem.Info1();
        }
        public void Info1()
        {
            Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", Number, PIB, Data.ToShortDateString(), Kaf, Stup, Staz);
        }

        public class SortByNumber : IComparer
        {
            int IComparer.Compare(object ob1, object ob2)
            {
                Teachers p1 = (Teachers)ob1;
                Teachers p2 = (Teachers)ob2;
                if (p1.Staz > p2.Staz) return 1;
                if (p1.Staz < p2.Staz) return -1;
                return 0;
            }
        }
        public void Two(Teachers[] a)
        {
            Console.WriteLine("\nСортування за стажом:");
            Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15} {5,-10}", "№", "ПІБ", "Дата", "Кафедра", "Ступінь", "Стаж");
            Array.Sort(a, new Teachers.SortByNumber());
            foreach (Teachers elem in a) elem.Info();
        }
        public void Info()
        {
            Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", Number, PIB, Data.ToShortDateString(), Kaf, Stup, Staz);
        }

        public void Add()
        {
            Console.WriteLine("Write data:");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
    class Key
    {
        public static void KKEY()
        {
            FileStream file1 = File.OpenRead("text.txt");
            byte[] array = new byte[file1.Length];
            file1.Read(array, 0, array.Length);
            string textfromfile = System.Text.Encoding.Default.GetString(array);
            string[] s = textfromfile.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            file1.Close();
            Teachers[] a = new Teachers[s.Length / 6];
            int c = 0;
            while (a[c] != null)
            {
                ++c;
            }
            for (int i = 0; i < s.Length; i += 6)
            {
                a[c + i / 6] = new Teachers(int.Parse(s[i]), s[i + 1], DateTime.Parse(s[i + 2]), s[i + 3], s[i + 4], int.Parse(s[i + 5]));
            }
            bool[] delete = new bool[100];
            Console.WriteLine("Add note: A");
            Console.WriteLine("Edit note: E");
            Console.WriteLine("Remove note: R");
            Console.WriteLine("Show notes: Enter");
            Console.WriteLine("Sort by date: N");
            Console.WriteLine("Sort by staz: D");
            Console.WriteLine("Sort by date: S");
            Console.WriteLine("Exit: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.E:
                    Key.Edit(a);
                    break;

                case ConsoleKey.N:
                    a[0].One(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.D:
                    a[0].Two(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.S:
                    a[0].Data1(a);
                    Key.KKEY();
                    break;

                case ConsoleKey.Enter:
                    Key.Show(a);
                    break;

                case ConsoleKey.A:
                    Key.Add(a, c);
                    break;

                case ConsoleKey.R:
                    Key.Remove(a, delete);
                    break;

                case ConsoleKey.Escape:
                    break;
            }

        }
        public static void Show(Teachers[] a)
        {
            Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15} {5,-10}", "№", "ПІБ", "Дата", "Кафедра", "Ступінь", "Стаж");

            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != null)
                {
                    Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", a[i].Number, a[i].PIB, a[i].Data.ToShortDateString(), a[i].Kaf, a[i].Stup, a[i].Staz);
                }
            }
            Key.KKEY();
        }
        public static void Add(Teachers[] a, int c)
        {
            Console.WriteLine("\nWrite number:");

            string str = Console.ReadLine();

            string[] elements = str.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Key.Parse(elements, true, a, c);
            Key.KKEY();
        }

        private static void Save(Teachers m)
        {
            StreamWriter save = new StreamWriter("text.txt", true);



            save.WriteLine(m.Number);
            save.WriteLine(m.PIB);
            save.WriteLine(m.Data);
            save.WriteLine(m.Kaf);

            save.WriteLine(m.Stup);
            save.WriteLine(m.Staz);

            save.Close();
        }

        public static void Parse(string[] elements, bool save, Teachers[] a, int counter)
        {
            for (int i = 0; i < elements.Length; i += 6)
            {
                a[counter + i / 6] = new Teachers(int.Parse(elements[i]), elements[i + 1], DateTime.Parse(elements[i + 2]), elements[i + 3], elements[i + 4], int.Parse(elements[i + 5]));
                if (save)
                {
                    Save(a[counter + i / 6]);
                }
            }
        }
        public static void Remove(Teachers[] a, bool[] delete)
        {
            Console.Write("\nnumber: ");

            string name = Console.ReadLine();

            bool[] write = new bool[a.Length];
            for (int i = 0; i < a.Length; ++i)
            {
                if (a[i] != null)
                {
                    if (a[i].Number == int.Parse(name))
                    {
                        Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", a[i].Number, a[i].PIB, a[i].Data.ToShortDateString(), a[i].Kaf, a[i].Stup, a[i].Staz);
                        Console.WriteLine("\nDELETE? (Y/N)\n");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {
                            a[i] = null;
                            delete[i] = true;
                            Key.Show(a);
                        }
                        else
                        {
                            delete[i] = false;
                        }
                    }
                }
            }
            Key.KKEY();
        }
        public static void Edit(Teachers[] a)
        {
            Console.WriteLine("\nWhat do you want to edit?");
            string what = Console.ReadLine();
            switch (what)
            {
                case "PIB":
                    Console.WriteLine("What surname: ");
                    string name1 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].PIB == name1)
                            {
                                Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", a[i].Number, a[i].PIB, a[i].Data.ToShortDateString(), a[i].Kaf, a[i].Stup, a[i].Staz);

                                Console.WriteLine("New surname: ");

                                string str = Console.ReadLine();

                                a[i].PIB = str;

                                Key.Show(a);
                            }
                        }
                    }
                    break;

                case "Date":
                    Console.WriteLine("What subject: ");
                    string name2 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Kaf == name2)
                            {
                                Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", a[i].Number, a[i].PIB, a[i].Data.ToShortDateString(), a[i].Kaf, a[i].Stup, a[i].Staz);

                                Console.WriteLine("New date: ");
                                string str = Console.ReadLine();
                                a[i].Data = DateTime.Parse(str);
                                Key.Show(a);
                            }
                        }
                    }
                    break;
                case "Kaf":
                    Console.WriteLine("What subject: ");
                    string name3 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Kaf == name3)
                            {
                                Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", a[i].Number, a[i].PIB, a[i].Data.ToShortDateString(), a[i].Kaf, a[i].Stup, a[i].Staz);
                                Console.WriteLine("New subject: ");
                                string str = Console.ReadLine();
                                a[i].Kaf = str;
                                Key.Show(a);
                            }
                        }

                    }
                    break;

                case "Number":
                    Console.WriteLine("What subject: ");
                    string name5 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Kaf == name5)
                            {
                                Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", a[i].Number, a[i].PIB, a[i].Data.ToShortDateString(), a[i].Kaf, a[i].Stup, a[i].Staz);
                                Console.WriteLine("New number: ");
                                int str = int.Parse(Console.ReadLine());
                                a[i].Number = str;
                                Key.Show(a);
                            }
                        }
                    }
                    break;
                case "Form":
                    Console.WriteLine("What form: ");
                    string name6 = Console.ReadLine();
                    for (int i = 0; i < a.Length; ++i)
                    {
                        if (a[i] != null)
                        {
                            if (a[i].Kaf == name6)
                            {
                                Console.WriteLine("{0,-15} {1,-40}{2,-30}{3,-20}{4,-15}{5,-10} ", a[i].Number, a[i].PIB, a[i].Data.ToShortDateString(), a[i].Kaf, a[i].Stup, a[i].Staz);
                                Console.WriteLine("New login: ");
                                string str = Console.ReadLine();
                                a[i].Stup = str;
                                Key.Show(a);
                            }
                        }

                    }
                    break;
            }
            Key.KKEY();
        }
    }
}
