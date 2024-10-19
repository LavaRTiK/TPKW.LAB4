namespace TPKW.LAB4.Server.Models
{
    public class StudentDto
    {
        public int? Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public StudentDto()
        {
        }
        public StudentDto(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
