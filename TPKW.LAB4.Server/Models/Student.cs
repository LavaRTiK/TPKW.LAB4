namespace TPKW.LAB4.Server.Models
{
    public class Student
    {
        private static int id = 0;
        public int Id { get; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public Student()
        {
            Id = ++id;
        }
        public Student(string firstName, string lastName)
        {
            Id = ++id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
