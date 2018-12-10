using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TranspSredstvlib;
using InputNumber;

namespace program_14
{
    class Program
    {
        //Через LINQ
        static void Menu1()
        {
            int cmd = 0;
            bool sform = false;
            MyCollections collections = null;

            do
            {
                Console.WriteLine("1. Создать коллекции.\n" +
                                  "2. Имена водителей в городе, отсортированные по алфавиту.\n" +
                                  "3. Кол-во машин на вокзале.\n" +
                                  "4. Суммарное кол-во пассажиров в поездах на вокзале.\n" +
                                  "5. Самый быстрый экспресс.\n" +
                                  "6. Машины, которые в городе, но не на вокзале.\n" +
                                  "7. Печать коллекций.\n" +
                                  "8. Выход.\n");
                cmd = InputNum.Input_int("Выберите действие: ");
                switch(cmd)
                {
                    case 1:
                        Console.Clear();
                        int size = InputNum.Input_int("Введите кол-во транспортных средств в городе: ");
                        Console.Clear();
                        collections = new MyCollections(size);
                        Console.Clear();
                        Console.WriteLine("Коллекции сформированы!\n");
                        sform = true;
                        break;
                    case 2:
                        Console.Clear();
                        if (sform)
                        {
                            string[] str = collections.GetNameVodLINQ();
                            if (str.Length == 0) Console.WriteLine("В коллекциях нет элементов.");
                            else for (int i = 0; i < str.Length; i++) Console.WriteLine("{0}. {1}", i + 1, str[i]);
                        }
                        else Console.WriteLine("Коллекции не сформированы!");
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Clear();
                        if (sform)
                        {
                            int cnt = collections.GetKolAutoLINQ();
                            if (cnt == -1) Console.WriteLine("На вокзале нет машин.");
                            else Console.WriteLine("Кол-во машин на вокзале: " + cnt);
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 4:
                        Console.Clear();
                        if (sform)
                        {
                            int kol_pas = collections.GetKolPasTrainLINQ();
                            if (kol_pas == -1) Console.WriteLine("На вокзале нет поездов.");
                            else Console.WriteLine("Кол-во пассажиров во всех поездах на вокзале: " + kol_pas);
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 5:
                        Console.Clear();
                        if (sform)
                        {
                            TranspSredstv[] t = collections.GetMaxSpeedExpressLINQ();
                            if (t == null) Console.WriteLine("В городе нет экспрессов.");
                            else
                            {
                                Console.WriteLine("Самые быстрые экспрессы:");
                                for(int i = 0; i < t.Length; i++)
                                {
                                    Console.WriteLine("{0}. {1}", i + 1, t[i]);
                                }
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 6:
                        Console.Clear();
                        if (sform)
                        {
                            TranspSredstv[] t = collections.GetKolAutoCityLINQ();
                            if (t.Length == 0) Console.WriteLine("В городе и не на вокзале нет транспортных средств.");
                            else
                            {
                                for (int i = 0; i < t.Length; i++) Console.WriteLine("{0}. {1}", i + 1, t[i]);
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 7:
                        Console.Clear();
                        if(sform)
                        {
                            collections.Show();
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 8:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Такого действия нет.\n");
                        break;
                }
            } while (cmd != 8);
        }

        //Через методы расширения
        static void Menu2()
        {
            int cmd = 0;
            bool sform = false;
            MyCollections collections = null;

            do
            {
                Console.WriteLine("1. Создать коллекции.\n" +
                                  "2. Имена водителей в городе, отсортированные по алфавиту.\n" +
                                  "3. Кол-во машин на вокзале.\n" +
                                  "4. Суммарное кол-во пассажиров в поездах на вокзале.\n" +
                                  "5. Самый быстрый экспресс.\n" +
                                  "6. Машины, которые в городе, но не на вокзале.\n" +
                                  "7. Печать коллекций.\n" +
                                  "8. Выход.\n");
                cmd = InputNum.Input_int("Выберите действие: ");
                switch (cmd)
                {
                    case 1:
                        Console.Clear();
                        int size = InputNum.Input_int("Введите кол-во транспортных средств в городе: ");
                        Console.Clear();
                        collections = new MyCollections(size);
                        Console.Clear();
                        Console.WriteLine("Коллекции сформированы!\n");
                        sform = true;
                        break;
                    case 2:
                        Console.Clear();
                        if (sform)
                        {
                            string[] str = collections.GetNameVodMeth();
                            if (str.Length == 0) Console.WriteLine("В коллекциях нет элементов.");
                            else for (int i = 0; i < str.Length; i++) Console.WriteLine("{0}. {1}", i + 1, str[i]);
                        }
                        else Console.WriteLine("Коллекции не сформированы!");
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.Clear();
                        if (sform)
                        {
                            int cnt = collections.GetKolAutoMeth();
                            if (cnt == -1) Console.WriteLine("На вокзале нет машин.");
                            else Console.WriteLine("Кол-во машин на вокзале: " + cnt);
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 4:
                        Console.Clear();
                        if (sform)
                        {
                            int kol_pas = collections.GetKolPasTrainMeth();
                            if (kol_pas == -1) Console.WriteLine("На вокзале нет поездов.");
                            else Console.WriteLine("Кол-во пассажиров во всех поездах на вокзале: " + kol_pas);
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 5:
                        Console.Clear();
                        if (sform)
                        {
                            TranspSredstv[] t = collections.GetMaxSpeedExpressMeth();
                            if (t == null) Console.WriteLine("В городе нет экспрессов.");
                            else
                            {
                                Console.WriteLine("Самые быстрые экспрессы:");
                                for (int i = 0; i < t.Length; i++)
                                {
                                    Console.WriteLine("{0}. {1}", i + 1, t[i]);
                                }
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 6:
                        Console.Clear();
                        if (sform)
                        {
                            TranspSredstv[] t = collections.GetKolAutoCityMeth();
                            if (t.Length == 0) Console.WriteLine("В городе и не на вокзале нет транспортных средств.");
                            else
                            {
                                for (int i = 0; i < t.Length; i++) Console.WriteLine("{0}. {1}", i + 1, t[i]);
                            }
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 7:
                        Console.Clear();
                        if (sform)
                        {
                            collections.Show();
                            Console.WriteLine();
                        }
                        else Console.WriteLine("Коллекции не сформированы!\n");
                        break;
                    case 8:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Такого действия нет.\n");
                        break;
                }
            } while (cmd != 8);
        }

        static void Main(string[] args)
        {
            int cmd;
            do
            {
                Console.WriteLine("1. Запросы через LINQ.\n" +
                              "2. Запросы через методы расширения.\n" +
                              "3. Выход.\n");
                cmd = InputNum.Input_int("Выберите действие: ");
                switch(cmd)
                {
                    case 1:
                        Console.Clear();
                        Menu1();
                        break;
                    case 2:
                        Console.Clear();
                        Menu2();
                        break;
                    case 3:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Такого действия нет.\n");
                        break;
                }
            } while (cmd != 3);

            //MyCollections collections = new MyCollections(0);
            //collections.Show();
            //Console.WriteLine();

            //string[] str = collections.GetNameVodMeth();
            //for (int i = 0; i < str.Length; i++) Console.WriteLine("{0}. {1}", i + 1, str[i]);



            //int kol_pas = collections.GetKolPasTrainLINQ();
            //Console.WriteLine("Кол-во пассажиров во всех поездах на вокзале: " + kol_pas);
        }
    }
}
