using InsuranceCompany.Domain.Enum;

namespace InsuranceCompany.Domain.Models
{
    public class Face
    {
        public int Id { get; set; }
        public FaceType Type { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Lastname { get; set; }
        public DateTime DateBirth { get; set; }
        public string Name { get; set; }
        public int INN { get; set; }
    }
}
