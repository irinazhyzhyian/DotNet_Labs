using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class TeamListHandlerEventArgs : System.EventArgs
    {
        //публічна автовластивість типу string з назвою колекції, в якій відбулась подія
        public string CollectionName
        {
            get; set;
        }

        //публічна автовластивість типу string з інформацією про тип зміни в колекції
        public string TypesOfChange
        {
            get; set;
        }

        //публічна автовластивість типу int з номером елементу, який був добавлений чи змінений
        public int ElementNumber
        {
            get; set;
        }

        //конструктор для ініціалізайії класі
        public TeamListHandlerEventArgs(string colname, string type, int elementnumber)
        {
            CollectionName = colname;
            TypesOfChange = type;
            ElementNumber = elementnumber;
        }

        //перезавантажений метод ToString() для формування рядка з інформацією про всі поля класу
        public override string ToString()
        {
            return "Collection Name : " + CollectionName + "; TypesOfChange : " + TypesOfChange + "; Element Added/Deleted : " + ElementNumber + ";\n";
        }
    }
}
