using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lecture;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrintable obj1 = new Message();
            obj1.Print();

            IHttpServlet obj2 = new Message();
            obj2.DoPost();


            // просходит упаковка, т.к. Twit - это структура
            // и приводим к её ссылочному типу
            IHttpServlet obj3 = new Twit();

            Console.WriteLine(Max(3, 5));
            Console.WriteLine(Max(3.5, 2.8));

            //var q = new Lecture.Program();
            //Lecture.Program.Main(new { "Added references"});
            Lecture.Program.Main(new string[] { "Added references" });
        }

        interface IPrintable
        {
            void Print();
        }

        interface IHttpServlet
        {
            void DoGet();
            void DoPost();
        }

        class Message : IPrintable, IHttpServlet
        {
            // явная реализация интерфейса
            public void Print()
            {

            }

            void IHttpServlet.DoGet()
            {

            }

            // не можем использовать какие-либо спецификаторы, т.к. в этом отношении это бесспысленно
            void IHttpServlet.DoPost()
            {
                Console.WriteLine("IHttpServlet.DoPost works");
            }
        }

        struct Twit : IHttpServlet
        {
            public void DoGet()
            {
                Console.WriteLine("DoGet method works");
            }
            public void DoPost()
            {
                Console.WriteLine("DoPost method works");
            }
        }

        static T Max<T>(T x, T y) where T: IComparable<T>
        {
            return x.CompareTo(y) > 0 ? x : y;
        }
    }
}
