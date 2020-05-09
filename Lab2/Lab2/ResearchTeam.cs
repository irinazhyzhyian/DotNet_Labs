using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    class ResearchTeam: Team, INameAndCopy
    {
        private string researchTeamTopic;
        private string researchTeamOrganization;
        private int researchTeamNumber;
        private TimeFrame researchTeamTimeFrame;
        List<Paper> researchTeamPaperList = new List<Paper>(); //для списку публікацій
        List<Person> researchTeamPersonList = new List<Person>(); //дл сптску учасників проекту

        //конструктор з параметрами типу string, string, int, TimeFrame для ініціалізації всіх полів 
        public ResearchTeam(string topic, string organization, int number, TimeFrame timeframe):base (organization, number)
        {
            researchTeamTopic = topic;
            researchTeamTimeFrame = timeframe;
        }

        //конструктор без параметрів для ініціалізації всіх полів деякими значення
        public ResearchTeam():base ()
        {
            researchTeamTopic = "Topic";
            researchTeamTimeFrame = TimeFrame.Year;
        }

        //властивість типу string з темою дослідження
        public string ReseachTeamTopic
        {
            get
            {
                return researchTeamTopic;
            }
            set
            {
                researchTeamTopic = value;
            }
        }

        //властивість типу string з назвою Організації
        public string ReseachTeamOrganization
        {
            get
            {
                return researchTeamOrganization;
            }
            set
            {
                researchTeamOrganization = value;
            }
        }

        //властивість типу int з реїстраційним номером
        public int ReseachTeamNumber
        {
            get
            {
                return researchTeamNumber;
            }
            set
            {
                researchTeamNumber = value;
            }
        }

        //властивість типу TimeFrame з інформацією про тривалість дослідження
        public TimeFrame ResearchTeamTimeframe
        {
            get
            {
                return researchTeamTimeFrame;
            }
            set
            {
                researchTeamTimeFrame = value;
            }
        }

        //властивість для доступу до поля зі списком публікацій
        public List<Paper> ResearchTeamPaperList
        {
            get
            {
                return researchTeamPaperList;
            }

            set
            {
                researchTeamPaperList = value;
            }
        }

        //властивість для доступу до поля зі списком учасників проекту
        public List<Person> ResearchTeamPersonList
        {
            get

            {
                return researchTeamPersonList;
            }

            set

            {
                researchTeamPersonList = value;
            }
        }

        //властивість типу Paper (тільки для читання), що повертає посилання на останню публікацію, якщо сисок порожній, то повертає null
        public Paper LastPaper
        {
            get
            {
                if (!researchTeamPaperList.Any())
                    return null;


                int i = 0;
                int newestPaperIndex = 0;

                foreach (Paper paper in researchTeamPaperList)
                {
                    if (paper.PaperDate > researchTeamPaperList[newestPaperIndex].PaperDate)
                        newestPaperIndex = i;

                    i++;

                }

                return researchTeamPaperList[newestPaperIndex];

            }
        }

        //індексатор булевого типу (тiльки з методом get) з одним параметром типу TimeFrame
        //значення індексатора рівне true, якщо значення поля з інформацією про тривалість дослідження співпадає із значенням індекса
        //і false якщо ні
        public bool this[TimeFrame time]
        {
            get
            {
                if (this.researchTeamTimeFrame == time)
                    return true;

                return false;
            }
        }

        //метод void AddPapers(params Paper[]) для додавання елементів у список публікацій
        public void AddPapers(params Paper[] array)
        {
            researchTeamPaperList.AddRange(array);

        }

        //метод void AddMembers ( params Person[] ) для добавлення учасників у список учасників дослідження 
        public void AddMembers(params Person[] list)
        {
            researchTeamPersonList.AddRange(list);
        }

        //перезавантажений метод ToString(); для формування рядка з значеннями всіх полів
        public override string ToString()
        {
            string researchTeamDataStr = " ";


            researchTeamDataStr = researchTeamTopic + " "
                                 + base.ToString()
                                 + researchTeamTimeFrame + " "
                                 + researchTeamDataStr;

            if (researchTeamPaperList.Any() && researchTeamPersonList.Any())
            {

                foreach (Person person in researchTeamPersonList)
                    researchTeamDataStr = researchTeamDataStr + " " + person.PersonName;

                foreach (Paper paper in researchTeamPaperList)
                    researchTeamDataStr = researchTeamDataStr + " " + paper.PaperName;
            }
            return researchTeamDataStr;
        }

        // віртуальний метод для формування рядка із значень всіх полів окрім поля зі списком публікацій
        public virtual string ToShortString()
        {
            return "Topic: " + researchTeamTopic + " " + base.ToString() + " " + "Time frame: " + researchTeamTimeFrame + "\n";
        }

        //визначити перезавантажену версію виртуального методу object DeepCopy().
        public new object DeepCopy()
        {
            ResearchTeam reserchTeamCopy = new ResearchTeam(this.researchTeamTopic, this.name, this.teamNum, this.researchTeamTimeFrame);
            reserchTeamCopy.researchTeamPaperList = this.researchTeamPaperList;
            reserchTeamCopy.researchTeamPersonList = this.researchTeamPersonList;
            return reserchTeamCopy as object;
        }

        //властивість типу Team; мктод get повертає об'єкт типу Team, дані якого співпадають з даними підоб'єкту базового класу,
        //метод set присвоює значення полям з базового класу
        public Team Team
        {
            get
            {
                return new Team("name", 444);
            }

            set 
            {
                this.name = value.Name;
                this.teamNum = value.TeamNum;
            }
        }

        //ітератор для послідовного перебору учасників проекту(об'єктів типу Person), що не мають публікації
        public IEnumerable<Person> GetPersonEnumerator()
        {
            //.ElementAt(0)
            bool FoundMatch;
            //int matchIndex;

            for (int WorkerIndex = 0; WorkerIndex < researchTeamPersonList.Count; WorkerIndex++)
            {

                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < researchTeamPaperList.Count; PaperIndex++)
                {

                    if (researchTeamPaperList.ElementAt(PaperIndex).PaperAuthor == researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (!FoundMatch)
                    yield return researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }


        //ітератор з параметром типу int для перебору публікацій, що вийшли за останні n років, де n параметр ітератора
        public IEnumerable<Paper> GetPublicationsEnumerator(int inputTimeRange)
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - inputTimeRange), 1, 1, 1, 1, 1);
            for (int index = 0; index < researchTeamPaperList.Count; index++)
            {
                if (researchTeamPaperList[index].PaperDate.Ticks > inputTimeFrame.Ticks)
                    yield return researchTeamPaperList[index]; // Yield each paper of the team.
            }
        }

        //реалізувати інтерфейс System.Collections.IEnumerable для перебору учасникв проекту(об'єкти типу Person), у яких є публікації;
        //для цього визначити допоміжний клас ResearchTeamEnumerator, що реалізує інтерфейс System.Collections.IEnumerator
        public IEnumerable<Person> GetWorkersEnumerator()
        {
            //.ElementAt(0)
            bool FoundMatch;
            //int matchIndex;

            for (int WorkerIndex = 0; WorkerIndex < researchTeamPersonList.Count; WorkerIndex++)
            {

                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < researchTeamPaperList.Count; PaperIndex++)
                {

                    if (researchTeamPaperList.ElementAt(PaperIndex).PaperAuthor == researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (FoundMatch)
                    yield return researchTeamPersonList.ElementAt(WorkerIndex);
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

            for (int WorkerIndex = 0; WorkerIndex < researchTeamPersonList.Count; WorkerIndex++)
            {
                hasWorks = 0;
                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < researchTeamPaperList.Count; PaperIndex++)
                {

                    if (researchTeamPaperList.ElementAt(PaperIndex).PaperAuthor == researchTeamPersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        hasWorks++;
                        break;
                    }

                }
                if (FoundMatch && hasWorks > 1)
                    yield return researchTeamPersonList.ElementAt(WorkerIndex);
            }
        }


        //визначити ітератор для перебору публікацій(об'єктів типу Paper), що вийшли за останній рік; для цього визначити метод, що містить
        //блок іторатора та використовує оператор yield;
        public IEnumerable<Paper> GetYearPublicationsEnumerator()
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - 1), 1, 1, 1, 1, 1);
            for (int index = 0; index < researchTeamPaperList.Count; index++)
            {
                if (researchTeamPaperList[index].PaperDate.Ticks > inputTimeFrame.Ticks)
                    yield return researchTeamPaperList[index]; // Yield each paper of the team.
            }

            

        }


    }
}