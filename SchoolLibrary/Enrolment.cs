using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class Enrolment
    {
        Person student;
        Section section;
        FinalGrade finalGrade;
        readonly int numberOfEvaluations;
        List<Evaluation> evaluations;
        public Enrolment(Section section, Person student, int numberOfEvaluations)
        {
           // int i = 0;
            Section = section;
            Student = student;
            this.numberOfEvaluations = numberOfEvaluations;

            evaluations = new List<Evaluation>(numberOfEvaluations);

            for (int i = 0; i < numberOfEvaluations; i++)
            {
                evaluations.Add(new Evaluation());
            }
        }
        public Person Student
        {
            get { return student; }
            set { student = value; }
        }

        public Section Section
        {
            get { return section; }
            set { section = value; }
        }

        public FinalGrade FinalGrade
        {
            get { return finalGrade; }
            set {  finalGrade = value; }
        }

        public List<Evaluation> Evaluations
        {
            get { return evaluations; }
            set { CalculateFinalGrade(); }
        }

        public FinalGrade CalculateFinalGrade()
        {
            //double[] grade = new double[numberOfEvaluations];
            List<double> grade = new List<double>(numberOfEvaluations);
            for (int i = 0; i < numberOfEvaluations; i++)
            {
                grade.Add(new double());
            }
            // double totalScore = 0;
            double totalScore = 1;
            for (int i = 0; i < numberOfEvaluations; i++)
            {
                grade[i] = evaluations[i].Points / evaluations[i].MaxPoints * evaluations[i].EvaluationWeight * 100;

                totalScore += grade[i];

            }




            if (90 <= totalScore)
            {
                finalGrade = FinalGrade.APLUS;
            }

            else if (80 <= totalScore && totalScore <90)
            {
                finalGrade = FinalGrade.A;
            }

            else if (75 <= totalScore && totalScore <80)
            {
                finalGrade = FinalGrade.BPLUS;
            }

            else if (70 <= totalScore && totalScore <75)
            {
                finalGrade = FinalGrade.B;
            }
            else if (65 <= totalScore && totalScore <70)
            {
                finalGrade = FinalGrade.CPLUS;
            }
            else if (60 <= totalScore && totalScore <65)
            {
                finalGrade = FinalGrade.C;
            }
            else if (55 <= totalScore && totalScore <60)
            {
                finalGrade = FinalGrade.DPLUS;
            }
            else if (50 <= totalScore && totalScore <55)
            {
                finalGrade = FinalGrade.D;
            }
            else
            {
                finalGrade = FinalGrade.F;
            }

            return finalGrade;  

        }

    }
}
