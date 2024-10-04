namespace InsuranceCompany.Web.Models.Agent;

public record CreateAgentDto(
    DateTimeOffset DateCreate,
    DateTimeOffset DateBegin,
    DateTimeOffset DateEnd,
    int FaceId,
    int IKPId,
    int StatusId
);