using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TranspSredstvlib;
using ArrayExceptionHandling;

namespace program_14
{
    class MyList<T> : IEnumerable<T>
    {
        T[] arr;
        int current;
        public int Capacity { get { return arr.Length; } }
        public int Count { get; private set; } = 0;

        ////для обращения к элементу класса через свойство
        //public int Current
        //{
        //    get { return current; }
        //    set
        //    {
        //        if (value < 0 || value >= Capacity) throw new IndexOutOfRangeException();
        //        else current = value;
        //    }
        //}
        ////обращение к элементу класса с индексом current
        //public T Item
        //{
        //    get
        //    {
        //        if (Current >= Count) throw new Exception("значение Current не может быть больше, чем значение индекса последнего элемента.");
        //        else return arr[Current];
        //    }
        //    set
        //    {
        //        if (value is T) arr[Current] = value;
        //        else throw new InvalidCastException();
        //    }
        //}

        //Итератор

        public T this[int index]
        {
            get
            {
                index = ExceptionHandlingArray.TestIndex(index + 1, Count);
                return arr[index - 1];
            }
            set
            {
                index = ExceptionHandlingArray.TestIndex(index + 1, Count);
                arr[index - 1] = value;
            }
        }

        public MyList()
        {
            arr = new T[0];
        }

        //заполняет коллекции рандомными элементами
        public MyList(int Capasity)
        {
            arr = new T[Capasity];
        }

        public MyList(MyList<T> c)
        {
            arr = new T[c.Capacity];
            for (int i = 0; i < c.Count; i++)
            {
                Count++;
                this[i] = c[i];
            }
        }

        //Конструктор через массив элементов(для клонирования)
        public MyList(T[] arr)
        {
            this.arr = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                Count++;
                this[i] = arr[i];
            }
        }

        //Добавление элемента
        public void Add(T value)
        {
            if(Count < Capacity)
            {
                Count++;
                this[Count - 1] = value;
            }
            else
            {
                Resize();
                Count++;
                this[Count - 1] = value;
            }
        }

        //Выделение большего кол-ва памяти под массив
        private void Resize()
        {
            T[] arr_buf;
            if(Capacity == 0) arr_buf = new T[4];
            else arr_buf = new T[Capacity * 2];
            for (int i = 0; i < Count; i++)
            {
                arr_buf[i] = this[i];
            }
            arr = arr_buf;
        }

        //Очистка массива
        public void Clear()
        {
            arr = new T[4];
            Count = 0;
        }

        //Клонирование
        public MyList<T> Clone()
        {
            T[] buf = new T[Count];
            for(int i = 0; i < Count; i++)
            {
                buf[i] = arr[i];
            }
            return new MyList<T>(buf);
        }

        //Возвращает первое вхождение данного элемента или -1
        public int IndexOf(T obj)
        {
            for(int i = 0; i < Count; i++)
            {
                if ((object)obj == (object)this[i]) return i;
            }
            return -1;
        }

        //Вставка элемента в конкретное место коллекции
        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException("index");
            else
            {
                T[] buf = new T[Count - index ];
                for (int i = 0, j = index; j < Count; i++, j++)
                {
                    buf[i] = arr[j];
                }
                arr[index] = value;
                Count++;
                for (int i = index + 1, j = 0; i < Count; i++, j++)
                {
                    arr[i] = buf[j];
                }
            }
        }

        //Поиск последнего вхождения элемента в коллекцию
        public int LastIndexOf(T value)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if ((object)value == (object)this[i]) index = i;
            }
            return index;
        }

        //Удаление первого вхождения заданного элемента в массив
        public int Remove(T value)
        {
            bool flag = true;
            T[] arr_buf = new T[Capacity];
            for (int i = 0, j = 0; i < Count; i++)
            {
                if ((object)value == (object)this[i] && flag)
                {
                    flag = false;
                    continue;
                }
                arr_buf[j] = this[i];
                j++;
            }
            if (!flag)
            {
                Count--;
                arr = arr_buf;
                return 0;
            }
            else return 1;
        }

        //Удаление через индекс
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
            T[] arr_buf = new T[Capacity];
            for (int i = 0, j = 0; i < Count; i++)
            {
                if (i == index) continue;
                arr_buf[j] = this[i];
                j++;
            }
                Count--;
                arr = arr_buf;
        }

        //Переворот массива
        public void Reverse()
        {
            T buf;
            for (int i = 0, j = Count - 1; i < Count / 2; i++, j--)
            {
                buf = arr[i];
                arr[i] = arr[j];
                arr[j] = buf;
            }
        }

        //Сортировка
        public void Sort()
        {
            T[] buf = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                buf[i] = arr[i];
            }
            Array.Sort(buf);
            for (int i = 0; i < Count; i++)
            {
                arr[i] = buf[i];
            }
        }

        //Печать массива
        public void Show()
        {
            for(int i = 0; i < Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, arr[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++) yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
