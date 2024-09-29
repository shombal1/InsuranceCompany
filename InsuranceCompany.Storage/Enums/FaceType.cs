using System.ComponentModel;

namespace InsuranceCompany.Storage.Enums;

public enum FaceType
{
    Natural = 0,
    Legal = 1
}

public static class ExtensionFaceType
{
    public static string ToString(FaceType faceType)
    {
        return faceType switch
        {
            FaceType.Natural => "Физическое лицо",
            FaceType.Legal => "Юридическое лицо",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static FaceType ParseString(string plain)
    {
        return plain switch
        {
            "Физическое лицо" => FaceType.Natural,
            "Юридическое лицо" => FaceType.Legal,
            _ => throw new InvalidEnumArgumentException()
        };
    }
}