using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErweiterteCSharpThemen2
{
    class Program
    {
        // Ein Lambda-Ausdruck ist eine anonyme Funktion , mit der Typen für Delegaten 
        // oder die Ausdrucksbaumstruktur erstellt werden können. (z.B. x<y wird durch eine Ausdruckbaumstrucktur repräsentiert)
        // Mit Lambda-Ausdrücken können lokale Funktionen geschrieben werden, 
        // die als Argumente übergeben oder als Wert von Funktionsaufrufen zurückgegeben werden können.
        // Lambda-Ausdrücke sind besonders für das Schreiben von LINQ-Abfrageausdrücken hilfreich.

        // Ein Delegat ist ein Typ, der ähnlich einem Funktionszeiger in C und C++ eine Methode sicher kapselt. 
        // Im Gegensatz zu C-Funktionszeigern sind Delegate objektorientiert, 
        // typsicher und sicher. Der Typ eines Delegaten wird durch den Namen des Delegaten definiert. 


        static void Main(string[] args)
        {
            //parameter =>ausdruck

            Console.WriteLine("Hallo Welt");



            Console.ReadKey();
        }


        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Square(int i)
        {
            return i * i;
        }

        public static int TimesTen(int i)
        {
            return i * 10;
        }
    }

    //Diese klasse sollte seine eigene Datei haben aber so geht es natürlich schneller....
    public class Number
    {
        public int n { get; set; }
    }
}
