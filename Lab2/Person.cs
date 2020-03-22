using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Person
    {
        private string personName;
        private string personSurname;
        private DateTime personBirthday;

        //конструктор без параметрів для ініціфлізації полів деякими  значеннями
        public Person()
        {
            this.personName = "Nan";
            this.personSurname = "Nan";
            this.personBirthday = DateTime.Now;
        }

        //конструктор з параметрами
        public Person(string name, string surname, DateTime birthday)
        {
            this.personName = name;
            this.personSurname = surname;
            this.personBirthday = birthday;
        }

        //властивість типу string в якій зберігається ім'я людини
        public string PersonName
        {
            get
            {
                return personName;
            }

            set
            {
                personName = value;
            }
        }

        //властивість типу string  в якій зберігається прізвище людини
        public string PersonSurname
        {
            get
            {
                return personSurname;
            }

            set
            {
                personSurname= value;
            }
        }

        //властивість типу DateTime в якій зберігається дата народження людини
        public DateTime PersonBirthday 
        {
            get
            {
                return personBirthday;
            }

            set
            {
                personBirthday = value;
            }
        }

        //властивість типу int з методати get та set для отримання та зміни розу народження в полі де зберігається дата народження
        public int PersonBearthYear
        {
            get
            {
                return PersonBearthYear;
            }

            set
            {
                PersonBearthYear = value;
            }
        }
        //який метод потрібен ???????
        /*
         public int PersonBearthYear1
        {
            get
            {
                return personBirthday.Year;
            }

            set
            {
                 var date1 = personBirthday;
                personBirthday = new DateTime(value, date1.Month, date1.Day);
            }
        }
         */

        //перезавантжений метод ToString(); для вормування рядка із значень полів
        public override string ToString()
        {
            return "Name: " +  personName + " " + "Surname: "+ personSurname + "\n"+ "Birthday: " +personBirthday + "\n";
        }

        //віртуальний метод для вормування рядка із імені та прізвища людини
        public virtual string ToShortString()
        {
            return "Name: " + personName + " " + "Surname: " + personSurname + "\n";
        }

        //перевизначений(override) метод bool Equals(object obj)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person person = obj as Person;
            return person.personName == this.personName
                && person.personSurname == this.personSurname
                && person.personBirthday == this.personBirthday;
        }

        //перевизначити операцію ==
        public static bool operator == (Person p1, Person p2)
        {
            return p1.personName == p2.personName
                && p1.personSurname == p2.personSurname
                && p1.personBirthday == p2.personBirthday;
        }

        //перевизначити операцію !=
        public static bool operator != (Person p1, Person p2)
        {
            return p1.personName != p2.personName
                && p1.personSurname != p2.personSurname
                && p1.personBirthday != p2.personBirthday; ;
        }

        //перевизначити віртуальний метод int GetHashCode();
        public override int GetHashCode()
        {
            int hashCode = 0;
            // converting to char array
            char[] arr;
            arr = personName.ToCharArray();
            char[] arr2;
            arr2 = personSurname.ToCharArray();

            // making hash from strings whith ASCII
            for (int index = 0; index < personName.Length; index++)
                hashCode += (int)(arr[index]);

            for (int index = 0; index < personSurname.Length; index++)
                hashCode += (int)(arr2[index]);

            return hashCode += (int)personBirthday.Ticks;
        }

        //визначити віртуальний метод object DeepCopy()
        public object DeepCopy()
        {
            Person personCopy = new Person(this.personName, this.personSurname, this.personBirthday);
            return personCopy as object;
        }
    }
    
}
