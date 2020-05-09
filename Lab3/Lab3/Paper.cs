using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Paper
    {
        public string paperName;
        public Person paperAuthor;
        public DateTime paperDate;

        //констуктор з параметрами, який ініціалізує всі поля об'єкта
        public Paper(string name, Person person, DateTime date)
        {
            paperName = name;
            paperAuthor = person;
            paperDate = date;
        }

        //конструктор без параметрів, який ініціалізує поля деякими значеннями
        public Paper()
        {
            paperName = "unknown";
            paperAuthor = new Person();
            paperDate = DateTime.Now;
        }

        // властивість типу string, в якій зберігається назва публікації
        public string PaperName
        {
            get
            {
                return paperName;
            }

            set
            {
                paperName = value;
            }
        }

        //влвстивість типу Person для автора публикації
        public Person PaperAuthor
        {
            get
            {
                return paperAuthor;
            }

            set
            {
                paperAuthor = value;
            }
        }

        //властивість типу DateTime з датой публикації
        public DateTime PaperDate
        {
            get
            {
                return paperDate.Date;
            }

            set
            {
                paperDate = value;
            }

        }

        //перезавантажений метод ToString(); для вормування рядка зі значеннями всіх полів
        public override string ToString()
        {
            return "Name: " + paperName + "\n" + "Author: " + paperAuthor.ToString() + "Publication day: " + paperDate + "\n";
            //return base.ToString();
        }

        public void CreatePaper()
        {
            Console.WriteLine("Paper paperName: ");
            paperName = Console.ReadLine();
            Console.WriteLine("Author: ");
        }

    }
}
