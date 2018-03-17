using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lecture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Закрываем обобщение, т.е.
             * создаём конкретный экземляр объекта(функции или класса)
             * согласно шаблону
             */
            MyClass<int> c = new MyClass<int>();
            MyClass<double> x = new MyClass<double>();
            MyClass<int> q = new MyClass<int>();
            MyClass<float> a = new MyClass<float>();

            Parent obj1 = new Parent();
            Parent obj2 = new Child(); // ссылочная совместимость

            Storage<Parent> storage1 = new Storage<Parent>();
            // Storage<Parent> storage2 = new Storage<Child>(); // не можем так сделать,
            // т.к. Storage<Parent> и Storage<Child> разные классы
        }

        class Counter
        {
            protected static int cnt;
        }
        class MyClass<T> : Counter
        {
            //private static int cnt;

            public MyClass()
            {
                cnt++;
                Console.WriteLine(cnt);
            }
        }

        class Parent
        {
            public int a;
        }

        class Child : Parent
        {
            public int c;
        }
        class Storage<T> where T: class
        {
            //TODO
        }


        // нельзя наследоваться от джинериков
        // Открываем обобщение
        class ExampleClassToShowForbiddenInheritance<T> where T : new()
        {
            T[] array;
            const int n = 3;
            public ExampleClassToShowForbiddenInheritance()
            {
                array = new T[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = new T();
                }
            }

            //public ExampleClassToShowForbiddenInheritance
        }

        // но нельзя так
        // class ThisClassWantsToInheritAnotherClass:ExampleClassToShowForbiddenInheritance<Int32>
        // и нельзя так
        // class ThisClassWantsToInheritAnotherClass<T> : ExampleClassToShowForbiddenInheritance<T>
        // но можно так
        // class ThisClassWantsToInheritAnotherClass<T>:ExampleClassToShowForbiddenInheritance<Int32>
        /*class ThisClassWantsToInheritAnotherClass<T> : ExampleClassToShowForbiddenInheritance<T>
        {
            public ThisClassWantsToInheritAnotherClass()
            {

            }

            // 
        }*/

    }
}
