using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class CourseManager
    {
        //Course[] courses;
        //ArrayList courses = new ArrayList();
        List<Course> courses = new List<Course>();
        int numberOfCourses;

        public CourseManager()
        {
 
        }

        public List<Course> Courses
        {
            get { return courses; }
        }

        public int NumberOfCourses
        {
            get { return numberOfCourses; }
            set { numberOfCourses = value; }
        }

        public void AddCourse(Course aCourse)
        {
            courses.Add(aCourse);
            NumberOfCourses++;
        }

        public void ExportCourses(string fileName, char delimiter)
        {
            FileStream fileOut = null;
            StreamWriter writer;

            fileOut = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(fileOut);
            foreach(Course aCourse in courses)
            {
                writer.WriteLine(aCourse.CourseCode + delimiter + aCourse.Name + delimiter
                    + aCourse.Description + delimiter + aCourse.NoOfEvaluations.ToString());
            }

            writer.Close();
            fileOut.Close();
        }

        public void ImportCourses(string fileName, char delimiter)
        {
            FileStream fileIn = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileIn);
            string recordIn = reader.ReadLine();
            string[] fields;
            int line = File.ReadAllLines(fileName).Length;


            string content = File.ReadAllText(fileName);
            while (recordIn != null)
            {
                for (int i = 0; i < line; i++)
                {
                    fields = recordIn.Split(delimiter);
                    int noOfEvaluations;
                  
                    //bool isConvertable = false;
                    //isConvertable = int.TryParse(fields[3], out noOfEvaluations);
                    try
                    {


                            Course aCourse = new Course()
                            {
                                CourseCode = fields[0],
                                Name = fields[1],
                                Description = fields[2],
                                NoOfEvaluations = Convert.ToInt32(fields[3])
                            };

                            courses.Add(aCourse);
                            numberOfCourses++;
                            this.numberOfCourses = courses.Count;
                        
                        
                    }
                    catch(Exception)
                    {
                        
                        if (fields.Length != 4)
                        {
                            throw new Exception("Invalid number of fields in record " + line);
                        }
               

              

                    }

                    recordIn = reader.ReadLine();
                }
            }
            reader.Close();
            fileIn.Close();


        }
        public void SaveSchoolInfo()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileOut = new FileStream("user.dat", FileMode.Create, FileAccess.Write);
            binaryFormatter.Serialize(fileOut, courses);

            fileOut.Close();
        }

        public void LoadSchool(string filename)
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            FileStream fileIn = new FileStream("user.dat", FileMode.Open, FileAccess.Read);
            courses = (List<Course>)binFormat.Deserialize(fileIn);



            this.numberOfCourses = courses.Count;
            fileIn.Close();

        }


        
    }


}
