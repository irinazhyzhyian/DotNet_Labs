using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Team: System.IComparable
    {
        protected string name; //назва організації
        protected int teamNum; //реєстраційний номер

        //конструктор з параметрами типу string та int для ініціалізації полів класу
        public Team(string name, int teamNum)
        {
            this.name = name;
            this.teamNum = teamNum;
        }

        //конструктор без параметрів для ініціалізації по замовчуванню
        public Team()
        {
            this.name = "Name";
            this.teamNum = 404;
        }

        //властивість типу string для доступу до поля з назвою організації
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        //властивість типу int для доступу до поля з номером реєстрації; в методі set генерувати виключну ситуацію,
        //якщо намагаються присвоїти значення <= 0; при створенні виключної ситуації використ один із визначених в бібліотеці CLR 
        //типів-виключень, ініціалізувати цей об'єкт за допомогою конструктора з параметром типу string
        public int TeamNum
        {
            get
            {
                return teamNum;
            }
            set
            {
                try
                {
                    teamNum = value;
                    if (value <= 0)
                        throw new ArgumentOutOfRangeException();
                }
                catch
                {
                    Console.WriteLine("Виникла виключна ситуація!");
                }
            }
        }

        //визначити віртуальний метод object DeepCope()
        public Team DeepCopy()
        {
            Team teamCopy = new Team(this.name, this.teamNum);
            return teamCopy;
        }

        //реалізувати інтерфейс INameAndCopy

        //віртуальний метод virtual bool Equals(object obj)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Team team = obj as Team;
            return this.name == team.name
                && this.teamNum == team.teamNum;
        }

        //визначити операцію ==
        public static bool operator ==(Team t1, Team t2)
        {
            return t1.name == t2.name && t1.teamNum == t2.teamNum;
        }

        //визначити операцію !=
        public static bool operator !=(Team t1, Team t2)
        {
            return t1.name != t2.name && t1.teamNum != t2.teamNum;
        }

        //перевизначити віртуальний метод int GetHashCode()
        public override int GetHashCode()
        {
            int hashCode = 0;

            // converting to char array
            char[] arr;
            arr = name.ToCharArray();

            // making hash from name whith ASCII
            for (int index = 0; index < name.Length; index++)
                hashCode += (int)(arr[index]);
            hashCode += teamNum;
            return hashCode;

        }

        //віртуальний метод string ToString() для формування рядка зі значеннями всіх полів класу
        public override string ToString()
        {
            return name + " " + teamNum;
        }

        //реалізація інтерфейса System.IComparable для порівняння об'єктів Team по полю з номером реєстрації
        public int CompareTo(object obj)
        {
            if (obj == null)
                return 0;
            Team team = obj as Team;
            return teamNum.CompareTo(team.TeamNum);
        }
    }
}
