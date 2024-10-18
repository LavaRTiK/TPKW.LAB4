namespace TPKW.LAB4.Server.Models
{
    public class Student
    {
        private static int id = 0;
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student()
        {
            Id = ++id;
        }
        public Student(string firstName, string lastName)
        {
            Id = ++id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
