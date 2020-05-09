using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class TeamsJournalEntry
    {
        //публічна автовластивість типу string з назвою колекції, в якій відбулась подія
        public string CollectionName
        {
            get; set;
        }

        //публічна автовластивість типу string з інформацією про тип зміни в колекції
        public string TypeOfChange
        {
            get; set;
        }

        //номер нового елементу
        public int NewElementNumber
        {
            get; set;
        }

        //конструктор для ініціалізації полів класу
        public TeamsJournalEntry(string colname, string typefochange, int elnumber)
        {
            CollectionName = colname;
            TypeOfChange = typefochange;
            NewElementNumber = elnumber;
        }

        //перезавантажений метод ToString() для формування рядка з інформацією про всі поля класу
        public override string ToString()
        {
            return "Colname : " + CollectionName + "; " + "TypeOfChange : " + TypeOfChange + "; " + "NewElementNumber " + NewElementNumber + ";\n";
        }
    }
}
