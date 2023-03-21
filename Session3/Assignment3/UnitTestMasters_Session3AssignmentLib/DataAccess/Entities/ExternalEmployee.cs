namespace UnitTestMasters_Session3AssignmentLib.DataAccess.Entities
{
    public class ExternalEmployee : Employee
    {
        public string Company { get; set; }

        public ExternalEmployee(
            string firstName,
            string lastName,
            string company) 
            : base(firstName, lastName)
        {
            Company = company;
        }
    }
}
