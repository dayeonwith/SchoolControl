using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
    [Serializable]
    public class Person
    {
        static public int regNum;
        string name;
        DateTime dob;
        Address address;
        long telephoneNumber;
        Enrolment enrolment;
        

        public Person()
        {
            regNum++;
            //enrolment = new Enrolment();
        }
        public Person(string name, DateTime dob)
        {
           
            regNum++;
            Name = name;
            DOB = dob;
        }

    

        public int RegNum
        {
            get { return regNum; }
            
        }

        public Enrolment Enrolment
        {
            get { return enrolment; }
            set { enrolment = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }

        public long TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }

    
   
        public override string ToString()
        {
            return String.Format("Reg no: {0}, Name: {1}, DOB: {2},\n Address: Street: {3}, City: {4}, State: {5}, Tel: {6}",
                RegNum, Name, DOB, Address.streetName, Address.city, Address.province, TelephoneNumber);
        }

        public virtual void AssignSection(Section aSection) { }

    }
}
