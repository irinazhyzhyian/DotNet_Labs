using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
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

    }
    
}
