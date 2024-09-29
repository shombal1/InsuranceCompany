using System.ComponentModel;
using AutoMapper.Internal.Mappers;

namespace InsuranceCompany.Storage.Enums;

public enum ContractStatusType
{
    Draft = 0,
    Signed = 1,
    Terminated = 2
}

public static class ExtensionContractStatusType
{
    public static string ToString(this ContractStatusType contractStatusType)
    {
        return contractStatusType switch
        {
            ContractStatusType.Draft => "DRAFT",
            ContractStatusType.Signed => "SIGNED",
            ContractStatusType.Terminated => "TERMINATED",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static ContractStatusType ParseString(string plain)
    {
        return plain switch
        {
            "DRAFT" => ContractStatusType.Draft,
            "SIGNED" => ContractStatusType.Signed,
            "TERMINATED" => ContractStatusType.Terminated,
            _ => throw new InvalidEnumArgumentException()
        };
    }
}