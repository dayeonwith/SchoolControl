using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class Teacher : Person
    {
       // Section[] sections;
        int numberOfSections;
        List<Section> sections = new List<Section>();

        public List<Section> Sections{ get; set; }

        public Teacher() {  }

        public Teacher(string name, DateTime DOB):base(name,DOB)
        {        }

        public int NumberOfSections
        { get; set; }

        public string SectionsInfo()
        {
            string result = "";
            if (numberOfSections > 0)
            {
                for(int i = 0; i < numberOfSections; i++)
                { 
                    result += "\t"+sections[i].Name+ "\n";
                }
            }
            return result;

        }

        public override void AssignSection(Section aSection)
        {
            //sections[numberOfSections] = aSection;
            sections.Add(aSection);
            numberOfSections++;
        }


    }
}
