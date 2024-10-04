using InsuranceCompany.Domain.Enum;

namespace InsuranceCompany.Web.Models.Face;

public record CreateFaceDto(
    FaceType Type,
    string FirstName,
    string SecondName,
    string Lastname,
    DateTime DateBirth,
    string Name,
    int INN
);