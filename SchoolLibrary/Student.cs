using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class Student:Person
    {
        //Section[] sections;
        List<Section> sections = new List<Section>();
        int numberOfSections;

        public Student()
        {
            //sections = new Section[100];
        }


        public List<Section> Sections { get; set; }

        public int NumberOfSections { get; set; }

        public string PrintTranscript()
        {
            string result = "";
            int j = 0;
            for (int i=0;i<numberOfSections;i++)
            {
                do
                {
                    if (sections[i].Enrolments[j].Student.Name == Name)
                    {
                        break;
                    }
                    j++;
                }
                while (j == sections[i].NumberOfEnrolments);

                sections[i].Enrolments[j].CalculateFinalGrade();
                j = 0;

                result += sections[i].Course.CourseCode + "\t"+sections[i].Enrolments[j].FinalGrade+"\n";

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
