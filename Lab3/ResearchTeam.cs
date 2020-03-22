using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        private string _researchTeamTopic;
        private string _researchTeamOrganization;
        private int _researchTeamNumber;
        private TimeFrame _researchTeamTimeFrame;
        System.Collections.Generic.List<Paper> _researchTeamPaperList = new List<Paper>(); //для списку публікацій
        System.Collections.Generic.List<Person> _researchTeamPersonList = new List<Person>(); //дл сптску учасників проекту

        //конструктор з параметрами типу string, string, int, TimeFrame для ініціалізації всіх полів 
        public ResearchTeam(string topic, string organization, int number, TimeFrame timeframe) : base(organization, number)
        {
            _researchTeamTopic = topic;
            _researchTeamTimeFrame = timeframe;
        }

        //конструктор без параметрів для ініціалізації всіх полів деякими значення
        public ResearchTeam() : base()
        {
            _researchTeamTopic = "Topic";
            _researchTeamTimeFrame = TimeFrame.Year;
        }

        //властивість типу string з темою дослідження
        public string ReseachTeamTopic
        {
            get
            {
                return _researchTeamTopic;
            }
            set
            {
                _researchTeamTopic = value;
            }
        }

        //властивість типу string з назвою Організації
        public string ReseachTeamOrganization
        {
            get
            {
                return _researchTeamOrganization;
            }
            set
            {
                _researchTeamOrganization = value;
            }
        }

        //властивість типу int з реїстраційним номером
        public int ReseachTeamNumber
        {
            get
            {
                return _researchTeamNumber;
            }
            set
            {
                _researchTeamNumber = value;
            }
        }

        //властивість типу TimeFrame з інформацією про тривалість дослідження
        public TimeFrame ResearchTeamTimeframe
        {
            get
            {
                return _researchTeamTimeFrame;
            }
            set
            {
                _researchTeamTimeFrame = value;
            }
        }

        //властивість для доступу до поля зі списком публікацій
        public List<Paper> ResearchTeamPaperList
        {
            get
            {
                return _researchTeamPaperList;
            }

            set
            {
                _researchTeamPaperList = value;
            }
        }

        //властивість для доступу до поля зі списком учасників проекту
        public List<Person> ResearchTeamPersonList
        {
            get

            {
                return _researchTeamPersonList;
            }

            set

            {
                _researchTeamPersonList = value;
            }
        }

        //властивість типу Paper (тільки для читання), що повертає посилання на останню публікацію, якщо сисок порожній, то повертає null
        public Paper LastPaper
        {
            get
            {
                if (!_researchTeamPaperList.Any())
                    return null;


                int i = 0;
                int newestPaperIndex = 0;

                foreach (Paper paper in _researchTeamPaperList)
                {
                    if (paper.PaperDate > _researchTeamPaperList[newestPaperIndex].PaperDate)
                        newestPaperIndex = i;

                    i++;

                }

                return _researchTeamPaperList[newestPaperIndex];

            }
        }

        //індексатор булевого типу (тiльки з методом get) з одним параметром типу TimeFrame
        //значення індексатора рівне true, якщо значення поля з інформацією про тривалість дослідження співпадає із значенням індекса
        //і false якщо ні
        public bool this[TimeFrame time]
        {
            get
            {
                if (_researchTeamTimeFrame == time)
                    return true;

                return false;
            }
        }

        //метод void AddPapers(params Paper[]) для додавання елементів у список публікацій
        public void AddPapers(params Paper[] array)
        {
            _researchTeamPaperList.AddRange(array);

        }

        //метод void AddMembers ( params Person[] ) для добавлення учасників у список учасників дослідження 
        public void AddMembers(params Person[] list)
        {
            _researchTeamPersonList.AddRange(list);
        }

        //перезавантажений метод ToString(); для формування рядка з значеннями всіх полів
        public override string ToString()
        {
            string researchTeamDataStr = " ";


            researchTeamDataStr = _researchTeamTopic + " "
                                 + base.ToString() + "  "
                                 + _researchTeamTimeFrame + " "
                                 + researchTeamDataStr;

            if (_researchTeamPaperList!=null && _researchTeamPersonList!=null)
            {

                foreach (Person person in _researchTeamPersonList)
                    researchTeamDataStr = researchTeamDataStr + " " + person.PersonName;

                foreach (Paper paper in _researchTeamPaperList)
                    researchTeamDataStr = researchTeamDataStr + " " + paper.PaperName;
            }
            return researchTeamDataStr;
        }

        // віртуальний метод для формування рядка із значень всіх полів окрім поля зі списком публікацій
        public virtual string ToShortString()
        {
            return "Topic: " + _researchTeamTopic + " " + base.ToString() + " " + "Time frame: " + _researchTeamTimeFrame + "\n";
        }

        //визначити перезавантажену версію виртуального методу object DeepCopy().
        public new object DeepCopy()
        {
            ResearchTeam reserchTeamCopy = new ResearchTeam(_researchTeamTopic, name, teamNum, _researchTeamTimeFrame);
            reserchTeamCopy._researchTeamPaperList = _researchTeamPaperList;
            reserchTeamCopy._researchTeamPersonList = _researchTeamPersonList;
            return reserchTeamCopy as object;
        }

        //властивість типу Team; метод get повертає об'єкт типу Team, дані якого співпадають з даними підоб'єкту базового класу,
        //метод set присвоює значення полям з базового класу
        public Team Team
        {
            get
            {
                return new Team("name", 444);
            }

            set
            {
                name = value.Name;
                teamNum = value.TeamNum;
            }
        }

        //ітератор для послідовного перебору учасників проекту(об'єктів типу Person), що не мають публікації
        public IEnumerable<Person> GetPersonEnumerator()
        {
            //.ElementAt(0)
            bool FoundMatch;
            //int matchIndex;

            for (int WorkerIndex = 0; WorkerIndex < _researchTeamPersonList.Count; WorkerIndex++)
            {

                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < _researchTeamPaperList.Count; PaperIndex++)
                {

                    if (_researchTeamPaperList.ElementAt(PaperIndex).PaperAuthor == _researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (!FoundMatch)
                    yield return _researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }


        //ітератор з параметром типу int для перебору публікацій, що вийшли за останні n років, де n параметр ітератора
        public IEnumerable<Paper> GetPublicationsEnumerator(int inputTimeRange)
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - inputTimeRange), 1, 1, 1, 1, 1);
            for (int index = 0; index < _researchTeamPaperList.Count; index++)
            {
                if (_researchTeamPaperList[index].PaperDate.Ticks > inputTimeFrame.Ticks)
                    yield return _researchTeamPaperList[index]; // Yield each paper of the team.
            }
        }

        //реалізувати інтерфейс System.Collections.IEnumerable для перебору учасникв проекту(об'єкти типу Person), у яких є публікації;
        //для цього визначити допоміжний клас ResearchTeamEnumerator, що реалізує інтерфейс System.Collections.IEnumerator
        public IEnumerable<Person> GetWorkersEnumerator()
        {
            //.ElementAt(0)
            bool FoundMatch;
            //int matchIndex;

            for (int WorkerIndex = 0; WorkerIndex < _researchTeamPersonList.Count; WorkerIndex++)
            {

                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < _researchTeamPaperList.Count; PaperIndex++)
                {

                    if (_researchTeamPaperList.ElementAt(PaperIndex).PaperAuthor == _researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (FoundMatch)
                    yield return _researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }


        //визначити іторетор для перебору учасників проекту(об'єктів типу Person), що мають більше однієї публікації; для цього визначити
        //метод, що містить блок ітератора та використовує оператор yield;
        public IEnumerable<Person> GetGoodWorkersEnumerator()
        {
            //.ElementAt(0)
            bool FoundMatch;
            //int matchIndex;
            int hasWorks = 0;

            for (int WorkerIndex = 0; WorkerIndex < _researchTeamPersonList.Count; WorkerIndex++)
            {
                hasWorks = 0;
                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < _researchTeamPaperList.Count; PaperIndex++)
                {

                    if (_researchTeamPaperList.ElementAt(PaperIndex).PaperAuthor == _researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        hasWorks++;
                        break;
                    }

                }
                if (FoundMatch && hasWorks > 1)
                    yield return _researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }


        //визначити ітератор для перебору публікацій(об'єктів типу Paper), що вийшли за останній рік; для цього визначити метод, що містить
        //блок іторатора та використовує оператор yield;
        public IEnumerable<Paper> GetYearPublicationsEnumerator()
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - 1), 1, 1, 1, 1, 1);
            for (int index = 0; index < _researchTeamPaperList.Count; index++)
            {
                if (_researchTeamPaperList[index].PaperDate.Ticks > inputTimeFrame.Ticks)
                    yield return _researchTeamPaperList[index]; // Yield each paper of the team.
            }



        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x._researchTeamTopic.CompareTo(y._researchTeamTopic);
        }
    }
}
