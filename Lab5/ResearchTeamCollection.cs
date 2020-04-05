using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class ResearchTeamCollection
    {
        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);

        //делегат
        private List<ResearchTeam> _researchTeams = new List<ResearchTeam>();

        //подія, яка генерується при додаванні елементу в кінець списку; передає через об'єкт TeamListHandlerEventArgs
        //ім'я колекції, рядок з інформ про те, що був доданий елемент та номер цього елементу в списку 
        public event TeamListHandler ResearchTeamAdded;

        //подія яка генерується, коли новий елемент вставляється перед одним з елементів списку
        public event TeamListHandler ResearchTeamInserted;

        //публічна автовластивість типу string з назвою колекції
        public string CollectionName
        {
            get; set;
        }

        //метод void InsertAt(int j, ResearchTeam researchTeam), який вставляє елемент researchTeam в список List<ResearchTeam> перед елементом з номером j;
        //якщо в в списку немає елементу з номером j, метод додає елемент в кінецю списку
        public void InsertAt(int j, ResearchTeam researchTeam)
        {
            ResearchTeam rt = _researchTeams.ElementAtOrDefault(j);

            if ((object)rt == null)
            {
                _researchTeams.Add(researchTeam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", _researchTeams.Count - 1));
            }
            else
            {
                _researchTeams.Insert(j, researchTeam);
                ResearchTeamInserted(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Inserted", j));
            }
        }

        //індексатор типу ResearchTeam(з методами get та set) з цілочисленим індексом для доступу до елементу списку з заданим номером
        public ResearchTeam this[int i]
        {
            get
            {
                return _researchTeams[i];
            }
            set
            {
                _researchTeams[i] = value;
            }
        }





        //метод void AddDefaults() за допомогою якого в список List<ResearchTeam> можна додавати деяке
        //число елементів типу ResearchTeam для ініціалізації колекції за замовчуванням
        public void AddDefaults()
        {
            for (int i = 0; i < 5; i++)
            {
                int num = _researchTeams.Count();
                ResearchTeam team = new ResearchTeam($"topic{i}", $"name{i}", i * 10, TimeFrame.Year);
                for (int j = 0; j < 5; j++)
                {
                    Person person = new Person($"Person{j}", $"{j}inch", new DateTime(1980 + j + i, 5, 1, 8, 30, 52));
                    Paper paper = new Paper($"paper{j}", person, new DateTime(i + j + 2000, 5, 1, 8, 30, 52));
                    team.AddPapers(paper);
                    team.AddMembers(person);
                }
                _researchTeams.Add(team);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", _researchTeams.Count - 1));
            }
        }

        //метод void AddResearchTeam(params ResearchTeam[]) для додавання елементів в список List<ResearchTeam>
        public void AddResearchTeams(params ResearchTeam[] teams)
        {
            foreach (ResearchTeam team in teams)
            {
                try
                {
                    _researchTeams.Add(team);
                    ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", _researchTeams.Count - 1));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Error!");
                }

            }

        }

        //перезавантажену версію віртуального метода string ToString() для формування рядка з інформацією про всі
        //елементи списку List<ResearchTeam>, який містить значення всіх полів, список учасників проекту та список публікацій 
        //для кожного елементу ResearchTeam

        public override string ToString()
        {
            string researchTeamData = "";
            foreach (ResearchTeam team in _researchTeams)
            {
                researchTeamData += team.ToString() + "\n";
            }
            return researchTeamData;
        }

        //віртуальний метод string ToShortList(), який формує рядок з інформацією про всі елементи списку List<ResearchTeam>, 
        //виключно зі значеннями всіх полів, число учасників проекту та число публікацій для кожного елементу ResearchTeam, але
        //без спискув учасників та пулікацій
        public virtual string ToShortString()
        {
            string data = "";
            foreach (ResearchTeam team in _researchTeams)
            {
                data += team.ToShortString()
                    + "К-сть учасникiв: " + team.ResearchTeamPersonList.Count() + "\n"
                    + "К-сть публiкацiй: " + team.ResearchTeamPaperList.Count() + "\n\n";

            }
            return data;
        }

        //сортування за номером реєстрації з використанням інтерфейса IComparable, реалізованого в класі Team
        public void SotrByTeamNumber()
        {

            _researchTeams.Sort();
        }

        //сортування за назвою теми дослідженнь з викристанням інтерфейсу IComparer(ResearchTeam>, реалізованого в
        //класі ResearchTeam
        public void SortByTopic()
        {
            _researchTeams.Sort(new ResearchTeam());
        }

        //сортування по к-сті публікацій з використанням інтерфейса IComparer<ResearchTeam>, реалізованого в допоміжному класі
        public void SortByCountPapers()
        {
            _researchTeams.Sort(new ResearchTeamComparer());
        }

        //властивість типу int(тільки для читання), що повертає мінімальне значення номера реєстрації для елементів списку List<ResearchTeam>;
        //якщо в колекції немає елементів, властивість повертає деяке значення за замовчуванням; для пошуку мінімального значення номеру реєстрації
        //потрібно використати метод Min класу Sestem.Linq>Enumerable;
        public int MinNumber
        {
            get
            {
                if (!_researchTeams.Any())
                    return -1;
                else
                    return _researchTeams.Min(team => team.ReseachTeamNumber);
            }
        }

        //властивість типу IEnumerable<ResearchTeam>(тільки для читання), що повертає підмножину елементів 
        //списку List<ResearchTeam> з тривалістю досліджень TimeFrame.TwoYears;
        //для вормуванння підмножини використати метод Where класу Sestem.Linq>Enumerable;
        public IEnumerable<ResearchTeam> ResearchTeamsGroup
        {
            get
            {
                return _researchTeams.Where(team => team.ResearchTeamTimeframe.Equals(TimeFrame.TwoYears));
            }
        }

        //метод List<ResearchTeam>NGroup(int value), який повертає список, в який входять елементи ResearchTeam з заданим числом учасників дослідженння;
        //для формування списку використати методи Group(???) та ToList класу System.Linq.Enumerable.
        public List<ResearchTeam> NGroup(int value)
        {
            List<ResearchTeam> resteamList = new List<ResearchTeam>();

            var regnumberQuery = from resteam in _researchTeams
                                 where resteam.ResearchTeamPersonList.Count == value
                                 group resteam by resteam.ReseachTeamNumber;



            IEnumerable<ResearchTeam> resTeam = regnumberQuery.SelectMany(group => group);
            resteamList = resTeam.ToList();

            return resteamList;
            //return _researchTeams.Where(team => team.ResearchTeamPersonList.Count == value).ToList();
        }


    }
}
