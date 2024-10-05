namespace InsuranceCompany.Web.Models.Agent;

public record GetAgentDto(
    int Id,
    DateTimeOffset DateCreate,
    DateTimeOffset DateBegin,
    DateTimeOffset DateEnd,
    int FaceId,
    int IKPId,
    int StatusId
);