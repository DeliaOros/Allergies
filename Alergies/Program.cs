using System;
using System.Collections.Generic;
using System.Text;


namespace Allergies
{
    class Program
    {
        static void Main(string[] args)
        {

            AllergicPerson person = new AllergicPerson("Tom", 6758);

            Console.WriteLine("------------");
            Console.WriteLine(person.Name);
            Console.WriteLine("------------");           
            Console.WriteLine(person.Score);
            Console.WriteLine("------------");            
            Console.WriteLine(person.IsAlergic);
            Console.WriteLine("------------");
            Console.WriteLine(person.ToString());
            Console.WriteLine("-----------------");                      

            


        }


    }

}
