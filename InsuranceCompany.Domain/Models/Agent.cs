namespace InsuranceCompany.Domain.Models
{
    public class Agent
    {
        public int Id { get; set; }
        public DateTimeOffset DateCreate { get; set; }
        public DateTimeOffset? DateBegin { get; set; }
        public DateTimeOffset? DateEnd { get; set; }
        public int FaceId { get; set; }
        public int IKPId { get; set; }
        public int StatusId { get; set; }
    }
}
