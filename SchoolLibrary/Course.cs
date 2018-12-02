using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class Course
    {
        string courseCode;
        string name;
        string description;
        int noOfEvaluations;
        //Section[] sections;
        int numberOfSections;
        List<Section> sections = new List<Section>();


        public Course() {  }
        public Course(string courseCode, string name)
        {
            CourseCode = courseCode;
            Name = name;

        }

        public int NumberOfSections
        {
            get { return numberOfSections; }
        }
        public List<Section> Sections
        {
            get { return sections; }
            set { sections = value; }
        }

        //public int MaxNumberOfSections
        //{
        //    get { return maxNumberOfSections; }
        //    set { maxNumberOfSections = value; }
        //}

        public string CourseCode
        {
            get { return courseCode; }
            set { courseCode = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int NoOfEvaluations
        {
            get { return noOfEvaluations; }
            set {
                if (numberOfSections!=0)
                {
                    throw new Exception("Section is already assigned. Number of evaluations cannot be changed anymore");
                }
                else noOfEvaluations = value; }
        }

        public void AddSection(SemesterPeriod semester, string sectionId, string name)
        {
            Section aSection = new Section
            {
                MaxNumberOfStudents = 30,
                SectionId = sectionId,
                Name=name
            };

            //sections[numberOfSections] = aSection;
            sections.Add(aSection);
            numberOfSections++;
            aSection.Course = this;
        }

        public void AddSection(Section aSection)
        {
            if (aSection.SectionId == null || aSection.Name == null)
            {
                throw new Exception("Section is not valid");
            }

            else if (aSection.Course != null)
            {
                throw new Exception("Section is already assigned to " + aSection.Course.Name + " course");
            }

            else
            {
                //sections[numberOfSections] = aSection;
                sections.Add(aSection);
                numberOfSections++;
                aSection.Course = this;
            }


        }
        public override string ToString()
        {
            string result;

            result = string.Format("CourseCode: {0} , Name: {1} , Description: {2} , No of Evaluations: {3} " + "\nNo of sections: {4}"
            , CourseCode, Name, Description, NoOfEvaluations, NumberOfSections);

                if (numberOfSections > 0)
                {

                for (int i = 0; i < numberOfSections; i++)
                    {

                        result += string.Format("\n\t {0} : {1}", Name, sections[i].Name);


                    }
                }
            return result;
        }


    }
}
