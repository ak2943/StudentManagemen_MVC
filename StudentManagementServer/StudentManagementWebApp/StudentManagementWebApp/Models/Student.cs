namespace StudentManagementWebApp.Models
{
    public class Student
    {
        public string Name { get; set; } 
        public string Email { get; set; }
        public string Dept { get; set; }

        public string getDept {  get; set; }    

        public List<Subject> Subjectarray { get; set; }
    }
    public class Subject 
    {
        public string Sub_Name { get; set; }
        public int Code { get; set; }
        public int Duration { get; set; }
    }

}
