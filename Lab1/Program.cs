using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("\n\n\nСтворити один об'єкт типу ResearchTeam, перетворити данi в рядок методом ToShortString() i вивести данi:\n");
            ResearchTeam teamOne = new ResearchTeam();

            Console.WriteLine(teamOne.ToShortString());


            Console.WriteLine("\n\n\nВивести значення iндексатора для значень iндекса TimeFrame.Year, TimeFrame.TwoYears, TimeFrame.Long:\n");
            Console.WriteLine(teamOne[TimeFrame.Year]);
            Console.WriteLine(teamOne[TimeFrame.TwoYears]);
            Console.WriteLine(teamOne[TimeFrame.Long]);


            Console.WriteLine("\n\n\nПрисвоiiти значення в типi ResearchTeam властивостям, перетворити данi в текстовий вигляд за допомогою методу ToString() та вивести данi:\n");
            ResearchTeam teamTwo = new ResearchTeam("Topic_1", "Team#1", 777, TimeFrame.Long);
            Console.WriteLine(teamTwo.ToString());


            Console.WriteLine("\n\n\nЗа допомогою методу AddPapers(params Paper[]) добавити елементи в список публікацiй та вивести данi об'єкту ResearchTeam:\n");
            var works = new Paper[]
            {
                new Paper("Paper_1", new Person("Author_1", "Surname_1", new DateTime(1997, 5, 1, 8, 30, 52)), new DateTime(2007, 5, 1, 8, 30, 52)),
                new Paper("Peper_2", new Person("Author_2", "Surname_2", new DateTime(1957, 5, 1, 8, 30, 52)), new DateTime(2008, 5, 1, 8, 30, 52)),
                new Paper("Paper_3", new Person("Author_3", "Surname_3", new DateTime(1987, 5, 1, 8, 30, 52)), new DateTime(2019, 5, 1, 8, 30, 52)),
                new Paper("Paper_4", new Person("Author_4", "Surname_4", new DateTime(1947, 5, 1, 8, 30, 52)), new DateTime(2015, 5, 1, 8, 30, 52)),
               
            };
            teamTwo.AddPapers(works);
            Console.WriteLine(teamTwo.ToString());


            Console.WriteLine("\n\n\nВивести значення властивостi, яке повертає посилання на публiкацiю, яка вийшла останньою:\n");
            Console.WriteLine(teamTwo.LastPaper);

            Console.WriteLine("\n\n\n6. Порiвняти час виконання операцiй з елементами одновимiрного, двовимiрного прямокутного, та двовимiрних зубчастих масивiв з однаковим числом елементiв типу Paper:\n");

            Paper[] linearArray = new Paper[1000000];
            Paper[,] rectArray = new Paper[1000, 1000];
            var jaggedArray = new Paper[1000][];

            for (int i = 0; i < jaggedArray.Length; i++)
                jaggedArray[i] = new Paper[1000];


            var time = Stopwatch.StartNew();

            for (int i = 0; i < 1000000; i++)
                linearArray[i] = null;

            time.Stop();
            Console.WriteLine(time.Elapsed + " " + "Одновимiрний масив");
            Console.WriteLine("----------------------------------- \n");

            time = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    rectArray[i, j] = null;

            time.Stop();
            Console.WriteLine(time.Elapsed + " " + "Двовимiрний масив");
            Console.WriteLine("----------------------------------- \n");


            time = Stopwatch.StartNew();

            for (int i = 0; i < 1000; i++)
                for (int j = 0; j < 1000; j++)
                    jaggedArray[i][j] = null;

            time.Stop();
            Console.WriteLine(time.Elapsed + " " + "Зубчатий масив");
            Console.WriteLine("----------------------------------- \n");

            Console.ReadKey();
        }
    }
}
