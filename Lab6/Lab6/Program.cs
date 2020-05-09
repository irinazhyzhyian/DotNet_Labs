using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey readKey;
            DateTime dateTime = DateTime.Now;
            if (dateTime.DayOfWeek != DayOfWeek.Sunday)
            {
                Human human = new Human();
                Human[] humans = { new Student(), new Botan(), new Girl(), new PrettyGirl(), new SmartGirl() };
                do
                {
                    Console.WriteLine();
                    Random random = new Random();
                    var firstIndex = random.Next(humans.Length);
                    var secondIndex = random.Next(humans.Length);

                    Console.WriteLine("First instance: " + humans[firstIndex].GetType().Name);
                    Console.WriteLine("Second instance: " + humans[secondIndex].GetType().Name + "\n");
                    try
                    {
                        Human.ValidateCouple(humans[firstIndex], humans[secondIndex]);
                    }
                    catch (InvalidCoupleArguments e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    var child = human.Couple(humans[firstIndex], humans[secondIndex]);

                    Console.WriteLine("\nName: " + child.GetType().GetProperty("Name")?.GetValue(child));
                    Console.WriteLine("Surname: " + child.GetType().GetProperty("Surname")?.GetValue(child));
                    Console.WriteLine("ChildType: " + child);
                    readKey = Console.ReadKey(false).Key;
                } while (readKey != ConsoleKey.F10 && readKey != ConsoleKey.Q && readKey.ToString() != "q");
            }
            else
            {
                Console.WriteLine("Сьогоднi ми не працюємо! Вихiдний!!!");
				Console.ReadKey();
            }

        }
    }
}

