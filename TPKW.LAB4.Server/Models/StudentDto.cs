namespace TPKW.LAB4.Server.Models
{
    public class StudentDto
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StudentDto()
        {
        }
        public StudentDto(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
