using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class TeamsJournal
    {
        private List<TeamsJournalEntry> ListWithChanges = new List<TeamsJournalEntry>();

        //обробник подій, створює елемент TeamsJournalEntry та ддає його в список List<TeamsJournalEntry>
        public void EventHandler(object source, TeamListHandlerEventArgs args)
        {
            TeamsJournalEntry teamsJournalEntry = new TeamsJournalEntry(args.CollectionName, args.TypesOfChange, args.ElementNumber);
            ListWithChanges.Add(teamsJournalEntry);
        }

        //перезавантажена віерсія методу для формування рядка з інформ про всі елементи списку List<TeamsJournalEntry>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (TeamsJournalEntry el in ListWithChanges)
            {
                sb.AppendLine("CollectionName : " + el.CollectionName + "; TypeOfChanges : " + el.TypeOfChange + "; Element : " + el.NewElementNumber + ";");
            }
            return sb.ToString();
        }
    }
}
