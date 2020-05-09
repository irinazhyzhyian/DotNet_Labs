using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class ResearchTeam
    {
        private string researchTeamTopic;
        private string researchTeamOrganization;
        private int researchTeamNumber;
        private TimeFrame researchTeamTimeFrame;
        private Paper[] researchTeamPapers;

        //конструктор з параметрами для ініціалізації всіх полів 
        public ResearchTeam(string topic, string organization, int number, TimeFrame timeframe)
        {
            researchTeamTopic = topic;
            researchTeamOrganization = organization;
            researchTeamNumber = number;
            researchTeamTimeFrame = timeframe;
        }

        //конструктор без параметрів для ініціалізації всіх полів деякими значення
        public ResearchTeam()
        {
            researchTeamTopic = "Topic";
            researchTeamOrganization = "Organization_name";
            researchTeamNumber = 404;
            researchTeamTimeFrame = TimeFrame.Year;
            researchTeamPapers = new Paper[1];
            researchTeamPapers[0] = new Paper();
        }
        
        //властивість типу string з темою дослідження
        public string ReseachTeamTopic
        {
            get
            {
                return researchTeamTopic;
            }
            set
            {
                researchTeamTopic = value;
            }
        }

        //властивість типу string з назвою Організації
        public string ReseachTeamOrganization
        {
            get
            {
                return researchTeamOrganization;
            }
            set
            {
                researchTeamOrganization = value;
            }
        }

        //властивість типу int з реїстраційним номером
        public int ReseachTeamNumber
        {
            get
            {
                return researchTeamNumber;
            }
            set
            {
                researchTeamNumber = value;
            }
        }

        //властивість типу TimeFrame з інформацією про тривалість дослідження
        public TimeFrame ResearchTeamTimeframe
        {
            get
            {
                return researchTeamTimeFrame;
            }
            set
            {
                researchTeamTimeFrame = value;
            }
        }

        //властивість типу Paper[] з списком публікацій
        public Paper[] ResearchTeamPapers
        {
            get
            {
                return researchTeamPapers;
            }
            set
            {
                researchTeamPapers = value;
            }
        }
        
        //перезавантажений метод ToString(); для формування рядка з значеннями всіх полів
        public override string ToString()
        {
            string p = "";
           if(researchTeamPapers!=null)
                foreach(Paper publication in researchTeamPapers)
                {
                    p += publication.ToString();
                }
            return "Topic: " + researchTeamTopic + "\n" + "Organization Name: " + researchTeamOrganization + "\n" +
                    "Number: " + researchTeamNumber + "\n" + "Time frame: " + researchTeamTimeFrame + "\n" +
                    "Publications: \n" + p+ "\n";
        }

        // віртуальний метод для формування рядка із значень всіх полів окрім поля зі списком публікацій
        public virtual string ToShortString()
        {
            return "Topic: " + researchTeamTopic + "\n" + "Organization Name: " + researchTeamOrganization + "\n" +
                   "Number: " + researchTeamNumber + "\n" + "Time frame: " + researchTeamTimeFrame + "\n";
        }

        //індексатор булевого типу (тiльки з методом get) з одним параметром типу TimeFrame
        //значення індексатора рівне true, якщо значення поля з інформацією про тривалість дослідження співпадає із значенням індекса
        //і false якщо ні
        public bool this[TimeFrame time]
        {
            get
            {
                if (this.researchTeamTimeFrame == time)
                    return true; 

                return false;  
            }
        }

        //властивість типу Paper (тільки для читання), яка повертає послилання на публікацію,
        //яка вийшла остання, якщо список публікацій порожній - повертає значення null
        public Paper LastPaper
        {
            get
            {
                if (researchTeamPapers==null)
                    return null;

                int i = 0;
                int newestPaperIndex = 0;

                foreach (Paper paper in researchTeamPapers)
                {
                    if (paper.PaperDate > researchTeamPapers[newestPaperIndex].PaperDate)
                        newestPaperIndex++;
                }

                return researchTeamPapers[newestPaperIndex];
            }
        }

        //метод для додавання елементів у список публікацій
        public void AddPapers(params Paper[] array)
        {
            if(researchTeamPapers == null)
            {
                researchTeamPapers = new Paper[0];
            }
            int n = researchTeamPapers.Length + array.Length;
            Paper[] newList = new Paper[n];
            for(int i = 0; i< researchTeamPapers.Length; ++i)
            {
                newList[i] = researchTeamPapers[i];
            }
            for(int i = researchTeamPapers.Length; i<n; ++i)
            {
                newList[i] = array[i - researchTeamPapers.Length];
            }
            researchTeamPapers = newList;
  
        }
    }
}
