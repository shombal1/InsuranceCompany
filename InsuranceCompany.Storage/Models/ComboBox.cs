namespace InsuranceCompany.Storage.Models;

public class ComboBox
{
    public int Index { get; set; }
    public string Key { get; set; }
    public string Description { get; set; }
    public ICollection<ComboBoxValue> Values { get; set; }
}