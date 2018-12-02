using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolLibrary;

namespace School.Test
{
    [TestClass]
    public class SchoolLibraryTest
    {
        [TestMethod]
        public void AddSection_InValidSection1()
        {

            Course aCourse = new Course("comp123","programming 2");
            Section aSection = new Section();

            try { aCourse.AddSection(aSection); }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Section is not valid");
                return;
            }
            Assert.Fail();

            //aCourse.AddSection(aSection);

            //Assert.AreSame(aCourse.Sections[0], aSection);


        }

        [TestMethod]
        public void AddSection_InvalidSection2()
        {
            Course aCourse = new Course("comp123", "programming 2");
            Section aSection = new Section()
            {
                SectionId = "F01",
                Name = "Section 1"
            };
            Course bCourse = new Course("comp225", "software methodologies");

            aCourse.AddSection(aSection);
            try
            {
                bCourse.AddSection(aSection);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Section is already assigned");
                return;
            }
           Assert.Fail();
        }

        [TestMethod]
        public void AddSection_ValidSection()
        {
            Course aCourse = new Course();
            Section aSection = new Section()
            {
                SectionId = "F01",
                Name = "Section 1"
            };

            try
            {
                aCourse.AddSection(aSection);
            }

            catch(Exception ex)
            {
                StringAssert.Contains(ex.Message,"Failed to add section");
                return;
            }
        }

        [TestMethod]
        public void AddStudent_InValid1()
        {
            Section aSection = new Section();
            Person aStudent = new Person();

            try
            {
                aSection.AddStudent(aStudent);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Student can only be assigned to the section that is assigned to the course");
                return;
            }
            Assert.Fail();
        }


        [TestMethod]
        public void AddStudent_Invalid2()
        {
            Course aCourse = new Course();
            Section aSection = new Section()
            {
                SectionId="F01",
                Name="section1",
                MaxNumberOfStudents = 0
            
            };
            Person bStudent = new Person();

            aCourse.AddSection(aSection);
   
            try
            {
                aSection.AddStudent(bStudent);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Student cannot be added. The section is full");
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void AddStudent_Valid()
        {
            Course aCourse = new Course();
            Section aSection = new Section()
            {
                SectionId = "F01",
                Name = "section1",
                MaxNumberOfStudents = 10
            };
            aCourse.AddSection(aSection);
            Person aStudent = new Person();
            try
            {
                aSection.AddStudent(aStudent);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Failed to add student");
            }
        }

        [TestMethod]
        public void DefineEvaluation_Valid()
        {
            Section aSection = new Section();
            try
            {
                aSection.DefineEvaluation(2, EvaluationType.ASSIGNMENT, 38, 40);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Failed to define evaluation");
            }
        }

        [TestMethod]
        public void AddStudentMark_InvalidPoints()
        {
            Course aCourse = new Course()
            {
                NoOfEvaluations = 4
            };
            Section aSection = new Section()
            {
                SectionId="comp123",
                Name="programming 2"
            };
            Person aStudent = new Person();

            aCourse.AddSection(aSection);
            aSection.AddStudent(aStudent);
            aSection.DefineEvaluation(1, EvaluationType.ASSIGNMENT, 38, 40);

            try
            {
                aSection.AddStudentMark(1, aStudent, 100);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Points are more than the max number of points for the evaluation");
                return;
            }
            Assert.Fail();
            
        }

        [TestMethod]
        public void AddStudentMark_InvalidStudent()
        {
            Course aCourse = new Course()
            {
                NoOfEvaluations = 4
            };
            Section aSection = new Section()
            {
                SectionId = "comp123",
                Name = "programming 2"
            };
            Person aStudent = new Person()
            {
                Name="John"
            };
            Person bStudent = new Person()
            {
                Name="Ann"
            };

            Section bSection = new Section()
            {
                SectionId="comp225",
                Name="Software Engineering Methodologies"
            };

            aCourse.AddSection(aSection);
            aCourse.AddSection(bSection);

            bSection.AddStudent(aStudent);
            aSection.AddStudent(bStudent);

            aSection.DefineEvaluation(1, EvaluationType.ASSIGNMENT, 38, 40);
            bSection.DefineEvaluation(1, EvaluationType.ASSIGNMENT, 38, 40);

            try
            {
                aSection.AddStudentMark(1, aStudent, 10);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Student " + aStudent.Name + " is not in the section");
                return;
            }
            Assert.Fail();
        }

        [TestMethod]
        public void AddStudentMark_Valid()
        {
            Course aCourse = new Course()
            {
                NoOfEvaluations = 4
            };
            Section aSection = new Section()
            {
                SectionId = "comp123",
                Name = "programming 2"
            };
            Person aStudent = new Person();

            aCourse.AddSection(aSection);
            aSection.AddStudent(aStudent);
            aSection.DefineEvaluation(1, EvaluationType.ASSIGNMENT, 38, 40);

            try
            {
                aSection.AddStudentMark(1, aStudent, 10);
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "Failed to add student mark");
                return;
            }
            

        }

        [TestMethod]
        public void CalculateFinalGrade()
        {
            Course aCourse = new Course()
            {
                NoOfEvaluations = 4
            };
            Section aSection = new Section()
            {
                SectionId = "comp123",
                Name = "programming 2"
            };
            Person aStudent = new Person()
            {
                Name="Dana"
            };

            aCourse.AddSection(aSection);
            aSection.AddStudent(aStudent);
            aSection.DefineEvaluation(1, EvaluationType.ASSIGNMENT, 38, 40);
            aSection.DefineEvaluation(2, EvaluationType.TEST, 100, 60);
            aSection.AddStudentMark(1, aStudent, 38);
            aSection.AddStudentMark(2, aStudent, 100);

            try
            {
                for (int i = 0; i < aSection.NumberOfEnrolments; i++)
                {
                    aSection.Enrolments[i].CalculateFinalGrade();
                }
            }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "failed to calculate final grade");
            }
        }

        [TestMethod]
        public void AddCourse_Valid()
        {
            Course aCourse = new Course();
            CourseManager aCourseManger = new CourseManager();

            try { aCourseManger.AddCourse(aCourse); }
            catch (Exception ex)
            {
                StringAssert.Contains(ex.Message, "failed to add course");
            }
        }




    }
}
