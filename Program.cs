using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public delegate int SomeMath(int i);
        public delegate bool Compare(int i, Number n);  // Vergleichen eine Klasse mit ein integer...wie soll es gehen? siehe Unten

        static void Main(string[] args)
        {
            // parameter =>ausdruck
            // (param1, param2) =>ausdruck

            DoSomething();

            Console.ReadKey();
        }

        public static void DoSomething()
        {
            //SomeMath math = new SomeMath(Square); // das geht, der Delegate bekommt 
            //SomeMath math = new SomeMath(Add); // macht fehler, da es 2 parameter erwartet
            SomeMath math = new SomeMath(TimesTen); //das geht auch
            Console.WriteLine(math(8));
            Console.WriteLine();  


            //jetzt mit Liste...
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13,14,15,16 };
            //Gerade Nummern
            List<int> evenNumbers = list.FindAll(delegate(int i)
            {
                return (i % 2 == 0);
            });
            //WTF WAS SOLL DAS FÜR EINE SYNTAX, KANN MAN GAR NICHT FOLGEN V******* NOCHMAL!!
            Console.WriteLine("Gerade");

            foreach (int even  in evenNumbers)
            {
                Console.WriteLine(even);
            }

            // "Herausforderung"... das gleiche fü ungerade WAS FÜR EIN BLÖDES HERAUSFORDERUNG...!!
            // es ist copy paste anstatt ==0 ersetzen mit !=0 oder ==1.....NICHT HILFREICH!!
            //Ungerade Nummern
            Console.WriteLine("Ungerade");
            List<int> oddNumbers = list.FindAll(delegate (int i)
            //wir übergeben für oddNumbers ein delegate der ein muster hat und es übergibt
            {
                // beide Optionen sind hier ok
                // return (i % 2 != 0);
                return (i % 2 == 1);
            });
            //WTF WAS SOLL DAS FÜR EINE SYNTAX, KANN MAN GAR NICHT FOLGEN V******* NOCHMAL!!
            foreach (int even in oddNumbers)
            {
                Console.WriteLine(even);
            }

            // JETZT VIA LAMBDA AUSDRÜCKE Diese 2 Linien ersetzen das ganze herausforderung oben...
            Console.WriteLine("Ungerade via LAMBDA");
            List<int> oddNumbers2 = list.FindAll(i => i % 2 == 1);  // was auch immer das bedeuten soll...
                                                                    // hier  übergeben wir dierkt das Lambda
                                                                    // oddNumbers2.ForEach(i => Console.WriteLine(i)); // einfahc die Nummern ausgeben
                                                                    // etwas mehr ausgeben:
            oddNumbers2.ForEach(i => {
                Console.WriteLine("ungerade Zahl");
                Console.WriteLine(i);
                // in der geschweifte klammer kann man einfach weitere Linien schreiben, code hinzufügen....etc..
                });

            // hier wird das ganze oddNumbers ausgegeben


            // jetzt wieder mit den Delegate math mist bauen
            // math mit ein cube funktion überschreiben
            math = new SomeMath(x => x =x * x * x);
            Console.WriteLine($"Der CUBE von 8 ist:  {math(8)}");
            Console.WriteLine($"Der CUBE von 5 ist:  {math(5)}");


            // "jetzt was interessantes..." mit den Nummer Klasse
            // OBEN DEKLARIERT:  public delegate bool Compare(int i, Number n);  // Vergleichen eine Klasse mit ein integer...wie soll es gehen?
            Compare comp = (a, number) => a == number.n;

            //parameter =>ausdruck
            //(param1, param2) =>ausdruck
            Console.WriteLine(comp(5, new Number { n = 5 }));
            Console.WriteLine(comp(4, new Number { n = 5 }));

            //die ganze dingens werden "Später weitererklärt" oder direkt verwendet in LINQ Kapitel.... TOLL NOCHMAL
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
