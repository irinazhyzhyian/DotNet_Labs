using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Person
    {
        private string _personName;
        private string _personSurname;
        private DateTime _personBirthday;

        //конструктор без параметрів для ініціфлізації полів деякими  значеннями
        public Person()
        {
            _personName = "Nan";
            _personSurname = "Nan";
            _personBirthday = DateTime.Now;
        }

        //конструктор з параметрами
        public Person(string name, string surname, DateTime birthday)
        {
            _personName = name;
            _personSurname = surname;
            _personBirthday = birthday;
        }

        //властивість типу string в якій зберігається ім'я людини
        public string PersonName
        {
            get
            {
                return _personName;
            }

            set
            {
                _personName = value;
            }
        }

        //властивість типу string  в якій зберігається прізвище людини
        public string PersonSurname
        {
            get
            {
                return _personSurname;
            }

            set
            {
                _personSurname = value;
            }
        }

        //властивість типу DateTime в якій зберігається дата народження людини
        public DateTime PersonBirthday
        {
            get
            {
                return _personBirthday;
            }

            set
            {
                _personBirthday = value;
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

        //перезавантжений метод ToString(); для вормування рядка із значень полів
        public override string ToString()
        {
            return "Name: " + _personName + " " + "Surname: " + _personSurname + "\n" + "Birthday: " + _personBirthday + "\n";
        }

        //віртуальний метод для вормування рядка із імені та прізвища людини
        public virtual string ToShortString()
        {
            return "Name: " + _personName + " " + "Surname: " + _personSurname + "\n";
        }

        //перевизначений(override) метод bool Equals(object obj)
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Person person = obj as Person;
            return person._personName == _personName
                && person._personSurname == _personSurname
                && person._personBirthday == _personBirthday;
        }

        //перевизначити операцію ==
        public static bool operator ==(Person p1, Person p2)
        {
            return p1._personName == p2._personName
                && p1._personSurname == p2._personSurname
                && p1._personBirthday == p2._personBirthday;
        }

        //перевизначити операцію !=
        public static bool operator !=(Person p1, Person p2)
        {
            return p1._personName != p2._personName
                && p1._personSurname != p2._personSurname
                && p1._personBirthday != p2._personBirthday; ;
        }

        //перевизначити віртуальний метод int GetHashCode();
        public override int GetHashCode()
        {
            int hashCode = 0;
            // converting to char array
            char[] arr;
            arr = _personName.ToCharArray();
            char[] arr2;
            arr2 = _personSurname.ToCharArray();

            // making hash from strings whith ASCII
            for (int index = 0; index < _personName.Length; index++)
                hashCode += (int)(arr[index]);

            for (int index = 0; index < _personSurname.Length; index++)
                hashCode += (int)(arr2[index]);

            return hashCode += (int)_personBirthday.Ticks;
        }

        //визначити віртуальний метод object DeepCopy()
        public object DeepCopy()
        {
            Person personCopy = new Person(_personName, _personSurname, _personBirthday);
            return personCopy as object;
        }
    }
}
