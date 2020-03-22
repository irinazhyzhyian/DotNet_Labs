using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1. Створити 2 колекції ResearchTeamCollection; \n");
            ResearchTeamCollection rcol1 = new ResearchTeamCollection();
            ResearchTeamCollection rcol2 = new ResearchTeamCollection();
            rcol1.CollectionName = "Collection 1";
            rcol2.CollectionName = "Collection 2";

            Console.Write("2. Створити 2 oб'єкти типу TeamsJournal один об'єкт пiдписати на подіїї ResearhTeamAdded та ResearhTeamInserted з першої колекції, інший на події ResearhTeamAdded та ResearhTeamInserted з обох колекцій; \n");
            TeamsJournal tj1 = new TeamsJournal();
            TeamsJournal tj2 = new TeamsJournal();

            rcol1.ResearchTeamAdded += tj1.EventHandler;
            rcol1.ResearchTeamInserted += tj1.EventHandler;

            rcol2.ResearchTeamAdded += tj1.EventHandler;
            rcol2.ResearchTeamAdded += tj2.EventHandler;
            rcol2.ResearchTeamInserted += tj1.EventHandler;
            rcol2.ResearchTeamInserted += tj2.EventHandler;

            Console.Write("3. Внести зміни в колекції; \n");
            //--------------Add Elements---------------------
            rcol1.AddDefaults();
            rcol2.AddDefaults();

            //-------------Insert---------------------------
            ResearchTeam r1 = new ResearchTeam("topic1", "organization1", 100, TimeFrame.TwoYears);          
            ResearchTeam r2 = new ResearchTeam("topic2", "organization2", 101, TimeFrame.TwoYears);           
            ResearchTeam r3 = new ResearchTeam("topic3", "organzation3", 102, TimeFrame.Long);          
            ResearchTeam r4 = new ResearchTeam("topic4", "organzation4", 103, TimeFrame.Year);
            

            rcol1.InsertAt(1, r1);
            rcol2.InsertAt(2, r2);

            rcol1.InsertAt(24, r3);
            rcol2.InsertAt(45, r4);

            Console.Write("4. Вивести дені обох об'єктів TeamsJournal. \n\n");
            Console.Write("Перший об'єкт TeamsJournal(для двох кол.):\n ");
            Console.WriteLine(tj1.ToString());
            Console.Write("Другий об'єкт TeamsJournal(для другої кол.):\n ");
            Console.WriteLine(tj2.ToString());

            Console.ReadKey();
        }
    }
}
