using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class Evaluation
    {
        EvaluationType evaluationType;
        double evaluationWeight;
        double maxPoints;
        double points;

        public Evaluation() { }
        public Evaluation(EvaluationType evaluationType, double maxPoints, double evaluationWeight)
        {
            EvaluationType = evaluationType;
            MaxPoints = maxPoints;
            EvaluationWeight = evaluationWeight;
        }
        public EvaluationType EvaluationType
        {
            get { return evaluationType; }
            set { evaluationType = value; }
        }

        public double EvaluationWeight
        {
            get { return evaluationWeight; }
            set { evaluationWeight = value; }
        }

        public double MaxPoints
        {
            get { return maxPoints; }
            set { maxPoints = value; }
        }

        public double Points
        {
            get { return points; }
            set { points = value; }
        }
    }
}
