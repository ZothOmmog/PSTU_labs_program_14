using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TranspSredstvlib;
using InputNumber;
using ArrayExceptionHandling;

namespace program_14
{
    class MyCollections
    {
        static Random rand = new Random();
        MyList<TranspSredstv> city;
        MyList<TranspSredstv> terminal;

        public MyCollections(int size_city)
        {
            size_city = ExceptionHandlingArray.TestSize(size_city);

            city = new MyList<TranspSredstv>();
            terminal = new MyList<TranspSredstv>();
            
            for(int i = 0; i < size_city; i++)
            {
                TranspSredstv buf = RandElem.Rand();
                city.Add(buf);
                if (rand.Next(1, 3) == 2) terminal.Add(buf);
            }
        }



        //Имена водителей в городе, отсортированные по алфавиту
        //через LINQ-запросы
        public string[] GetNameVodLINQ()
        {
            string[] rez = (from i in city orderby i.Name_vod select i.Name_vod).ToArray();
            return rez;
        }
        //через методы расширения
        public string[] GetNameVodMeth()
        {
            string[] rez = city.OrderBy(i => i.Name_vod).Select(i => i.Name_vod).ToArray();
            return rez;
        }



        //Кол-во машин на вокзале
        //через LINQ-запросы
        public int GetKolAutoLINQ()
        {
            int rez = (from i in terminal where i is Auto select i).Count();
            return rez;
        }
        //через методы расширения
        public int GetKolAutoMeth()
        {
            int rez = terminal.Where(i => i is Auto).Select(i => i).Count();
            return rez;
        }



        //Суммарное кол-во пассажиров в поездах на вокзале
        //через LINQ-запросы
        public int GetKolPasTrainLINQ()
        {
            var buf = from i in terminal where i is Train select i.Kol_pas;
            int rez;
            if (buf.Count() == 0) rez = -1;
            else rez = buf.Aggregate((a, b) => a + b);
            return rez;
        }
        //через методы расширения
        public int GetKolPasTrainMeth()
        {
            var buf = terminal.Where(i => i is Train).Select(i => i.Kol_pas);
            int rez;
            if (buf.Count() == 0) rez = -1;
            else rez = buf.Aggregate((a, b) => a + b);
            return rez;
        }



        //Самый быстрые экспресс
        //через LINQ-запросы
        public TranspSredstv[] GetMaxSpeedExpressLINQ()
        {
            var buf_arr = (from i in terminal where i is Express select i);
            if (buf_arr.Count() == 0) return null;
            else
            {
                int speed = buf_arr.Max(a => ((Express)a).Speed);
                TranspSredstv[] rez = (from i in terminal where i is Express && ((Express)i).Speed == speed select i).ToArray();
                return rez;
            }
        }
        //через методы расширения
        public TranspSredstv[] GetMaxSpeedExpressMeth()
        {

            var buf_arr = terminal.Where(i => i is Express).Select(i => i);
            if (buf_arr.Count() == 0) return null;
            else
            {
                int speed = buf_arr.Max(a => ((Express)a).Speed);
                TranspSredstv[] rez = terminal.Where(i => i is Express && ((Express)i).Speed == speed).Select(i => i).ToArray();
                return rez;
            }
        }

        //Машины, которые в городе, но не на вокзале
        //через LINQ-запросы
        public TranspSredstv[] GetKolAutoCityLINQ()
        {
            TranspSredstv[] rez = (from i in city where i is Auto select i).Except(from i in terminal where i is Auto select i).ToArray();
            return rez;
        }
        //через методы расширения
        public TranspSredstv[] GetKolAutoCityMeth()
        {
            TranspSredstv[] rez = (city.Where(a => a is Auto).Select(a => a).Except(terminal.Where(a => a is Auto).Select(a => a))).ToArray();
            return rez;
        }

        //Печать коллекций
        public void Show()
        {
            if (city.Count == 0) Console.WriteLine("В городе нет транспортных средств.");
            else
            {
                Console.WriteLine("Город: ");
                city.Show();
                Console.WriteLine();
                if (terminal.Count == 0) Console.WriteLine("На вокзале нет транспортных средств.");
                else
                {
                    Console.WriteLine("Вокзал: ");
                    terminal.Show();
                }
            }
        }
    }

    
}
