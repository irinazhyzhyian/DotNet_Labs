using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\n\n\n 1. Створити 2 об'єкти типу Team з однаковими даними та перевірити, що посилання на об'єкти різні, а об'єкти рівні, вивести значення хеш-кодів для об'єктів.\n");
            Team t1, t2;
            t1 = new Team("team", 1);
            t2 = new Team("team", 1);
            Console.WriteLine((t1 == t2));
            Console.WriteLine((t1 as object == t2 as object));
            Console.WriteLine("Хеш-коди:" + t1.GetHashCode().ToString() + " // " + t2.GetHashCode().ToString());
            Console.WriteLine();

            Console.WriteLine("\n\n\n 2. В блоці try/catch присвоїти властивості з номером реєстрації некоректне з-ня, а в обробнику виключних ситуацій вивести повідомлення про помилку.\n");
            t1.TeamNum = 0;



            Console.WriteLine("\n\n\n 3. Створити об'єкт типу ResearchTeam, додати елементи в список публікацій та список учасників пректу та вивести дані об'єкту ResearchTeam. \n");
            ResearchTeam teamOne = new ResearchTeam();
            ResearchTeam teamTwo = new ResearchTeam();

            var workers = new Person[]
            {
                new Person( "Worker1", "Workenson1", new DateTime(1965, 5, 1, 8, 30, 52)),
                new Person( "Worker2", "Workenson2", new DateTime(1976, 5, 1, 8, 30, 52)),
                new Person( "Worker3", "Workenson3", new DateTime(1983, 5, 1, 8, 30, 52)),
                new Person( "Worker4", "Workenson4", new DateTime(1990, 5, 1, 8, 30, 52)),
                new Person( "Worker5", "Workenson5", new DateTime(1999, 5, 1, 8, 30, 52)),
            };

            teamTwo.AddMembers(workers);
            Console.WriteLine(teamTwo.ToString());

            Console.WriteLine("\n\n\n 4. Вивести значення властивості Team для об'єкту Research Team.\n");
            Console.WriteLine(teamTwo.Team.ToString());

            Console.WriteLine("\n\n\n 5. За допомогою метода DeepCopy() створити повну копію об'єкта ResearchTeam. Змінити дані у вихідному об'єкті ResearchTeam та вивести копію та оригінал, копія повинна залишатися без змін \n");
            ResearchTeam teamThree = new ResearchTeam();
            teamThree = teamTwo.DeepCopy() as ResearchTeam;

            teamTwo.ReseachTeamTopic = "T2Topic";
            teamTwo.Name = "T2Name";
            teamTwo.TeamNum = 222;

            Console.WriteLine("TeamTwo: " + teamTwo.ToString() + "\n");
            Console.WriteLine("TeamThree: " + teamThree.ToString() + "\n");

            Console.WriteLine("\n\n\n 6. За допомогою оператора foreach для ітератора, визначеного в класі ResearchTeam, вивести список учасників проекту, які не мають публікації \n");
            List<Paper> papers = new List<Paper>();
            papers.Add(new Paper("Worker1`s publication", workers[0], DateTime.Now));
            teamTwo.ResearchTeamPaperList = papers;
            foreach (Person worker in teamTwo.GetPersonEnumerator())
                Console.WriteLine(worker.PersonName + " ");

            Console.WriteLine("\n\n\n 7. За допомогою оператора foreach для ітератора з параметром, визначеного в класі ResearchTeam, вивести список всіх публікай за останні 2 роки. \n");
            foreach (Paper paper in teamTwo.GetPublicationsEnumerator(5))
                Console.WriteLine(paper.PaperName + " ");

            Console.ReadKey();            
            Console.WriteLine ("\n\n\n------------\nS U C C E S S\n----------\n\n\n");
        }
    }
}
