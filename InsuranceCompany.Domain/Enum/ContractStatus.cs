using System.ComponentModel;

namespace InsuranceCompany.Domain.Enum
{
    public enum ContractStatus
    {
        [Description("Проект")]
        DRAFT,

        [Description("Подписан")]
        SIGNED,

        [Description("Расторгнут")]
        TERMINATED
    }
}