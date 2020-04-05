using System.Runtime.Serialization.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab5
{
    [DataContract]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
        [DataMember]
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
            set { }
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

            if (_researchTeamPaperList != null && _researchTeamPersonList != null)
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


       //T DeepCopy() для створення повної копії об'єкту з використанням серіалізації
        public static T DeepCopy<T>(object obj) where T : class
        {
            if (obj is T serialisedObject)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    try
                    {
                        serializer.WriteObject(ms, serialisedObject);
                        ms.Position = 0;
                        return serializer.ReadObject(ms) as T;
                    }
                    catch (InvalidDataContractException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        ms.Close();
                    }
                }
            }
            throw new ArgumentException($"I cannot convert { nameof(serialisedObject) } to ResearchTeam");
        }

        public static bool Load(string fileName, ResearchTeam researchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    researchTeam.ReseachTeamTopic = deserializedTeam.ReseachTeamTopic;
                    researchTeam.ReseachTeamOrganization = deserializedTeam.ReseachTeamOrganization;
                    researchTeam.ResearchTeamTimeframe = deserializedTeam.ResearchTeamTimeframe;
                    researchTeam.ReseachTeamNumber = deserializedTeam.ReseachTeamNumber;
                    researchTeam.ResearchTeamPaperList = deserializedTeam.ResearchTeamPaperList;
                    researchTeam.ResearchTeamPersonList = deserializedTeam.ResearchTeamPersonList;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        public static bool Save(string fileName, ResearchTeam saveResearchTeam)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(saveResearchTeam.ReseachTeamTopic, saveResearchTeam.ReseachTeamOrganization, saveResearchTeam.ReseachTeamNumber, saveResearchTeam.ResearchTeamTimeframe);
            researchTeam.ResearchTeamPaperList = saveResearchTeam.ResearchTeamPaperList;
            researchTeam.ResearchTeamPersonList = saveResearchTeam.ResearchTeamPersonList;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        //для збереження даних об'єкту в файлі за допомогою серіалізації
        public bool Save(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            ResearchTeam researchTeam = new ResearchTeam(ReseachTeamTopic, ReseachTeamOrganization, ReseachTeamNumber, ResearchTeamTimeframe);
            researchTeam.ResearchTeamPaperList = ResearchTeamPaperList;
            researchTeam.ResearchTeamPersonList = ResearchTeamPersonList;

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ResearchTeam));
                ser.WriteObject(ms, researchTeam);
                byte[] json = ms.ToArray();

                var objectToJson = Encoding.UTF8.GetString(json, 0, json.Length);
                FileStream fstream = new FileStream(fileLocation + fileName + fileFormat, FileMode.OpenOrCreate);
                fstream.SetLength(0);
                byte[] array = Encoding.Default.GetBytes(objectToJson);
                fstream.Write(array, 0, array.Length);
                fstream.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                ms.Close();
            }
            return false;
        }

        //для ініціалізації об'єкту даними з файлу за допомогою десеріалізації
        public bool Load(string fileName)
        {
            string fileLocation = @"D:\";
            string fileFormat = ".txt";

            try
            {
                using (FileStream fstream = File.OpenRead(fileLocation + fileName + fileFormat))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);
                    string json = Encoding.Default.GetString(array);

                    MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
                    ResearchTeam deserializedTeam = new ResearchTeam();
                    DataContractJsonSerializer ser = new DataContractJsonSerializer(deserializedTeam.GetType());
                    deserializedTeam = ser.ReadObject(ms) as ResearchTeam;

                    ReseachTeamTopic = deserializedTeam.ReseachTeamTopic;
                    ReseachTeamOrganization = deserializedTeam.ReseachTeamOrganization;
                    ResearchTeamTimeframe = deserializedTeam.ResearchTeamTimeframe;
                    ReseachTeamNumber = deserializedTeam.ReseachTeamNumber;
                    ResearchTeamPaperList = deserializedTeam.ResearchTeamPaperList;
                    ResearchTeamPersonList = deserializedTeam.ResearchTeamPersonList;

                    ms.Close();
                    fstream.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

        //метод для додавання нового елементу в List<Paper>
        public bool AddPaperFromConsole()
        {
            Console.WriteLine("Введiть данi для об'єкту Paper наступного формату: " +
                              "назва публiкацiї;дата публiкацiї;Автор: iм'я;прiзвище;дата народження(формат: YYYY:MM:DD)\n" +
                              "Приклад: C# tutorial;2020-03-30;James;Bay;1990-04-23");

            Person person = new Person();
            Paper paper = new Paper();
            var input = Console.ReadLine();
            string[] splitedString = new string[] { "" };

            if (input != null)
            {
                splitedString = input.Split(';');
            }

            try
            {
                paper.PaperName = splitedString[0];
                var yearOfPublishing = int.Parse(splitedString[1].Split('-')[0]);
                var monthOfPublishing = int.Parse(splitedString[1].Split('-')[1]);
                var dayOfPublishing = int.Parse(splitedString[1].Split('-')[2]);
                paper.PaperDate = new DateTime(yearOfPublishing, monthOfPublishing, dayOfPublishing);

                person.PersonName = splitedString[2];
                person.PersonSurname = splitedString[3];
                var yearOfBirth = int.Parse(splitedString[4].Split('-')[0]);
                var monthOfBirth = int.Parse(splitedString[4].Split('-')[1]);
                var dayOfBirth = int.Parse(splitedString[4].Split('-')[2]);
                person.PersonBirthday = new DateTime(yearOfBirth, monthOfBirth, dayOfBirth);
                paper.PaperAuthor = person;
                ResearchTeamPaperList.Add(paper);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
        }

    }
}
