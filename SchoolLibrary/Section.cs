using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class Section
    {
        string sectionId;
        string name;
        int maxOfEnrolments;
        SemesterPeriod semester;
        Course course;
        //Enrolment[] enrolments;
        //ArrayList enrolments = new ArrayList();
        List<Enrolment> enrolments = new List<Enrolment>();
        int numberOfEnrolments;
 
        
        Person faculty;

        public Section():this(40)
        {

        }
        public Section(Course course, int maxNoOfStudents, SemesterPeriod semeseter):this(40)
        {
            MaxNumberOfStudents = maxNoOfStudents;
            Semester = semester;
        }

        public Section(int maxNoOfEnrolments)
        {
            this.maxOfEnrolments = maxNoOfEnrolments;
            MaxNumberOfStudents = maxOfEnrolments;
        }
        public List<Enrolment> Enrolments
        {
            get { return enrolments; }
            set { enrolments = value; }
        }




        public int NumberOfEnrolments
        {
            get { return numberOfEnrolments; }
        }

        public string SectionId
        {
            get { return sectionId; }
            set { sectionId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Course Course
        {
            get { return course; }
            set { course = value; }
        }

        public int MaxNumberOfStudents
        {
            get { return maxOfEnrolments; }
            set { maxOfEnrolments = value; }
        }

        public SemesterPeriod Semester
        {
            get { return semester; }
            set { semester = value; }
        }

 

        public Person Faculty
        {
            get { return faculty; }
            set { faculty = value;
                //여기에 왠지 AddSection을 해야할것같은데
                faculty.AssignSection(this);
            }
        }

        public void AddStudent(Person student)
        {
            if (Course == null)
            {
                throw new Exception("Student can only be assigned to the section that is assigned to the course");
            }

            else if (NumberOfEnrolments == MaxNumberOfStudents)
            {
                throw new Exception("Student cannot be added. The section is full");
            }

            else
            {
                //enrolments[numberOfEnrolments] = new Enrolment(this, student, Course.NoOfEvaluations);
                enrolments.Add(new Enrolment(this, student, Course.NoOfEvaluations));
                numberOfEnrolments++;
                student.AssignSection(this);
            }
        }

        public void DefineEvaluation(int orderNumber, EvaluationType type, double maxPoints, double weight)
        {
            //evaluationOrderNumber = orderNumber;
            for (int i = 0; i < numberOfEnrolments; i++)
            {
                enrolments[i].Evaluations[orderNumber-1].EvaluationType = type;
                enrolments[i].Evaluations[orderNumber-1].MaxPoints = maxPoints;
                enrolments[i].Evaluations[orderNumber-1].EvaluationWeight = weight;
            }
            //foreach (Enrolment enrol in enrolments)
            //{
            //    enrol.Evaluations[orderNumber - 1].EvaluationType = type;
            //}
        }

        public void AddStudentMark(int orderNumber, Person student, double points)
        {
 
            int i = 0;
            if (points > enrolments[i].Evaluations[orderNumber - 1].MaxPoints)
            {
                throw new Exception("Points are more than the max number of points for the evaluation");
            }
            else
            {
                do
                {

                    if (enrolments[i].Student.Name == student.Name)
                    {
                        break;
                    }

                    i++;
                } while (i < numberOfEnrolments);

                if(i==numberOfEnrolments)
                { 
                  throw new Exception("Student " + student.Name + " is not in the section");
                }


                
            }

            enrolments[i].Evaluations[orderNumber - 1].Points = points;
        }
        

        public override string ToString()
        {
            string info;
            info = String.Format("Section id: {0}, Name: {1}, Max no of students: {2}, Semester: {3}" + "\n\tFaculty:  " +
                "\nNumber of students: {4}", SectionId, Name, MaxNumberOfStudents, Semester, NumberOfEnrolments);
            if (Faculty != null)
            {
                info = String.Format("Section id: {0}, Name: {1}, Max no of students: {2}, Semester: {3}" + "\n\tFaculty: {4} " +
                "\nNumber of students: {5}", SectionId, Name, MaxNumberOfStudents, Semester, Faculty.Name, NumberOfEnrolments);
            }

            for (int i = 0; i < numberOfEnrolments; i++)
            {
                if (numberOfEnrolments > 0)
                {
                    string studentName = enrolments[i].Student.Name;
                    info += String.Format("\n\t {0}", studentName);
                }
            }

            return info;
        }

        public string GetEvaluationsInfo()
        {
            string info = "";
            {
                for (int i = 0; i < Course.NoOfEvaluations; i++)
                {
                    if (i < numberOfEnrolments)
                    {
                        info += string.Format("\t{0}.{1}[{2}]", i, enrolments[i].Evaluations[i].EvaluationType, enrolments[i].Evaluations[i].MaxPoints);
                       
                    }
                    else break;
                }
            }


            for (int i = 0; i < numberOfEnrolments; i++)
            {
                info += string.Format("\n{0}", enrolments[i].Student.Name);
                for (int x = 0; x < Course.NoOfEvaluations; x++)
                {
                    info += string.Format("\t{0}/{1}\t", enrolments[i].Evaluations[x].Points, enrolments[i].Evaluations[x].Points * enrolments[i].Evaluations[x].EvaluationWeight / enrolments[i].Evaluations[x].MaxPoints * 100);
                }
            }


            return info;
        }

        public string FinalMarksInfo()
        {
            string info = "";
            for (int i = 0; i < numberOfEnrolments; i++)
            {
                enrolments[i].CalculateFinalGrade();
                info += string.Format("{0}" + "\t" + "{1}" + "\n", enrolments[i].Student.Name, enrolments[i].FinalGrade);

            }
            return info;
        }

        

    }
}
