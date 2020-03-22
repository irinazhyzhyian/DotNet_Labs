using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class TestColections
    {
       List<Team> keys;
       List<string> strings;
       Dictionary<Team, ResearchTeam> keysDictionary;
       Dictionary<string, ResearchTeam> stringDictionary;

        //конструктор з параметром типу int(число елементрів в колекціях) для автоматичного тсворення колекцій з заданим числом елементів
        public TestColections(int count)
        {
            if (count < 0)
            {
                throw new System.ArgumentException("Number of elements can't be negative!");
            }
            keys = new List<Team>();
            strings = new List<string>();
            keysDictionary = new Dictionary<Team, ResearchTeam>();
            stringDictionary = new Dictionary<string, ResearchTeam>();

            for (int index = 1; index < count; index++)
            {
    
                keys.Add(createTeam(index));
                strings.Add(createTeam(index).ToString());
                keysDictionary.Add(createTeam(index), createResearchTeam(index));
                stringDictionary.Add(createTeam(index).ToString(), createResearchTeam(index));
            }

        }

        public static Team createTeam(int id)
        {
            Random random = new Random();
            string name = "Name" + random.Next().ToString();
            return new Team(name, id);
        }

        //статичний метод з цілочисловим параметром типу int, який повертає посилання на об'єкт типу ResearchTeam та використовується для автоматичної 
        //генерації елементів колекції
        public static ResearchTeam createResearchTeam(int id)
        {
            Random random = new Random();
            string topic = "Topic" + random.Next().ToString();
            string name = "Name" + random.Next().ToString();
            TimeFrame frame;
            switch (random.Next(3))
            {
                case 0:
                    frame = TimeFrame.Year;
                    break;
                case 1:
                    frame = TimeFrame.TwoYears;
                    break;
                default:
                    frame = TimeFrame.Long;
                    break;
            }
            ResearchTeam rt = new ResearchTeam(topic, name, id, frame);
            return rt;
        }

        //метод, який обраховує час пошуку елементра в списках List<Team> та List<string>, час пошуку елемента по ключу та час пошуку значення елемента
        //в колекціях-словниках Dictionart<Team, ResearchTeam> та Dictionart<string, ResearchTeam>
        public void searchInListKey()
        {
            Console.WriteLine("\n\n\n");

            var first = keys[0];
            var center = keys[keys.Count / 2];
            var last = keys[keys.Count - 1];
            var another = new Team("unuse", 001);

            var time = Stopwatch.StartNew();
            keys.Contains(first);
            time.Stop();
            Console.WriteLine("In List<Team>\nFor the first element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keys.Contains(center);
            time.Stop();
            Console.WriteLine("For the central element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keys.Contains(last);
            time.Stop();
            Console.WriteLine("For the last element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keys.Contains(another);
            time.Stop();
            Console.WriteLine("For a non-existent element:  " + time.Elapsed + "\n");
        }
        public void searchInListString()
        {
            Console.WriteLine("\n\n\n");

            var first = strings[0];
            var center = strings[strings.Count / 2];
            var last = strings[strings.Count - 1];
            var another = "some_string";

            var time = Stopwatch.StartNew();
            strings.Contains(first);
            time.Stop();
            Console.WriteLine("In List<string>\nFor the first element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            strings.Contains(center);
            time.Stop();
            Console.WriteLine("For the central element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            strings.Contains(last);
            time.Stop();
            Console.WriteLine("For the last element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            strings.Contains(another);
            time.Stop();
            Console.WriteLine("For a non-existent element:  " + time.Elapsed + "\n");
        }

        public void searchInDictKey()
        {
            Console.WriteLine("\n\n\n");

            var first = keysDictionary.ElementAt(0).Key;
            var center = keysDictionary.ElementAt(keysDictionary.Count / 2).Key;
            var last = keysDictionary.ElementAt(keysDictionary.Count - 1).Key;
            var another = new Team("unused_before", 01);

            var time = Stopwatch.StartNew();
            keysDictionary.ContainsKey(first);
            time.Stop();
            Console.WriteLine("In Dict_Key by key\nFor the first element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keysDictionary.ContainsKey(center);
            time.Stop();
            Console.WriteLine("For the central element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keysDictionary.ContainsKey(last);
            time.Stop();
            Console.WriteLine("For the last element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keysDictionary.ContainsKey(another);
            time.Stop();
            Console.WriteLine("For a non-existent element:  " + time.Elapsed + "\n");
        }

        public void searchInDictString()
        {
            Console.WriteLine("\n\n\n");

            var first = stringDictionary.ElementAt(0).Key;
            var center = stringDictionary.ElementAt(stringDictionary.Count / 2).Key;
            var last = stringDictionary.ElementAt(stringDictionary.Count - 1).Key;
            var another = "some_string";

            var time = Stopwatch.StartNew();
            stringDictionary.ContainsKey(first);
            time.Stop();
            Console.WriteLine("In Dict_String by key\nFor the first element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            stringDictionary.ContainsKey(center);
            time.Stop();
            Console.WriteLine("For the central element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            stringDictionary.ContainsKey(last);
            time.Stop();
            Console.WriteLine("For the last element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            stringDictionary.ContainsKey(another);
            time.Stop();
            Console.WriteLine("For a non-existent element:  " + time.Elapsed + "\n");
        }

        public void searchInDictKeyByValue()
        {
            Console.WriteLine("\n\n\n");

            var first = keysDictionary.ElementAt(0).Value;
            var center = keysDictionary.ElementAt(keysDictionary.Count / 2).Value;
            var last = keysDictionary.ElementAt(keysDictionary.Count - 1).Value;
            var another = new ResearchTeam("unused", "unused", 001, TimeFrame.Long);

            var time = Stopwatch.StartNew();
            keysDictionary.ContainsValue(first);
            time.Stop();
            Console.WriteLine("In Dict_Key by value\nFor the first element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keysDictionary.ContainsValue(center);
            time.Stop();
            Console.WriteLine("For the central element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keysDictionary.ContainsValue(last);
            time.Stop();
            Console.WriteLine("For the last element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            keysDictionary.ContainsValue(another);
            time.Stop();
            Console.WriteLine("For a non-existent element:  " + time.Elapsed + "\n");
        }

        public void searchInDictStringByValue()
        {
            Console.WriteLine("\n\n\n");

            var first = stringDictionary.ElementAt(0).Value;
            var center = stringDictionary.ElementAt(stringDictionary.Count / 2).Value;
            var last = stringDictionary.ElementAt(stringDictionary.Count - 1).Value;
            var another = new ResearchTeam("unused", "unused", 001, TimeFrame.Long);

            var time = Stopwatch.StartNew();
            stringDictionary.ContainsValue(first);
            time.Stop();
            Console.WriteLine("In Dict_String by value\nFor the first element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            stringDictionary.ContainsValue(center);
            time.Stop();
            Console.WriteLine("For the central element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            stringDictionary.ContainsValue(last);
            time.Stop();
            Console.WriteLine("For the last element:  " + time.Elapsed);

            time = Stopwatch.StartNew();
            stringDictionary.ContainsValue(another);
            time.Stop();
            Console.WriteLine("For a non-existent element:  " + time.Elapsed + "\n");
        }



    }


}

