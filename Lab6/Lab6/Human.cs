using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Human : IHasName, IEnumerable
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Human() { }

        public Human(string name)
        {
            Name = name;
        }

        private static bool IsFemale(Human human)
        {
            return human is Student || human is Botan;
        }

        private static bool IsMale(Human human)
        {
            return human is Girl || human is SmartGirl || human is PrettyGirl;
        }

        public static void ValidateCouple(Human human1, Human human2)
        {
            if (IsMale(human1) && IsMale(human2) || IsFemale(human1) && IsFemale(human2))
                throw new InvalidCoupleArguments("Instances must have different sexes");
        }

        public int GetRandomProbability()
        {
            Random random = new Random();
            return random.Next(0, 100);
        }

        public IHasName Couple(Human human1, Human human2)
        {
            bool secondHumanLike = false;
            bool firstHumanLike = false;
            Couple firstCase = new Couple();
            foreach (Couple attribute in human1)
            {
                firstCase = attribute;
                if (attribute.Pair == human2.GetType().Name)
                {
                    var randValue = GetRandomProbability();
                    if (randValue <= attribute.Probability)
                    {
                        secondHumanLike = true;
                        Console.WriteLine(human1.GetType().Name + " LIKE " + human2.GetType().Name);
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human1.GetType().Name + " UNLIKE " + human2.GetType().Name);
                    }
                }
            }
            foreach (Couple attribute in human2)
            {
                if (attribute.Pair == human1.GetType().Name)
                {
                    var randValue = GetRandomProbability();
                    if (randValue <= attribute.Probability)
                    {
                        firstHumanLike = true;
                        Console.WriteLine(human2.GetType().Name + " LIKE " + human1.GetType().Name + "\n");
                        break;
                    }
                    else
                    {
                        Console.WriteLine(human2.GetType().Name + " UNLIKE " + human1.GetType().Name + "\n");
                    }
                }
            }

            object result = new object();
            object child = new object();
            if (firstHumanLike && secondHumanLike)
            {
                foreach (MethodInfo method in human2.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (method.ReturnType == typeof(System.String))
                    {
                        try
                        {
                            result = method.Invoke(human2, null);
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                }

                Type type = Type.GetType(GetType().Namespace + '.' + firstCase.ChildType);
                if (type != null)
                {
                    child = Activator.CreateInstance(type);
                    PropertyInfo nameProperty = child.GetType().GetProperty("Name");
                    PropertyInfo surnameProperty = child.GetType().GetProperty("Surname");

                    if (nameProperty != null && surnameProperty != null)
                    {
                        nameProperty.SetValue(child, result);

                        if (nameProperty.GetValue(child, null).ToString() == "Student" ||
                            nameProperty.GetValue(child, null).ToString() == "Botan")
                        {
                            surnameProperty.SetValue(child, surnameProperty.GetValue(child, null) + "ович");
                        }
                        else
                        {
                            surnameProperty.SetValue(child, surnameProperty.GetValue(child, null) + "овна");
                        }
                    }
                }
            }
            else
            {
                return this;
            }

            return (IHasName)child;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<Couple> GetEnumerator()
        {
            Attribute[] attrs = Attribute.GetCustomAttributes(GetType());
            foreach (var attr in attrs)
            {
                if (attr is Couple c)
                {
                    yield return c;
                }
            }
        }
    }
}
