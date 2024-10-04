using System.ComponentModel;

namespace InsuranceCompany.Domain.Enum
{
    public enum FaceType
    {
        [Description("Физическое лицо")]
        Natural,

        [Description("Юридическое лицо")]
        Legal
    }
}