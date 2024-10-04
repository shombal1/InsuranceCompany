using System.Text.Json;
using System.Text.Json.Serialization;
using JsonDocument = System.Text.Json.JsonDocument;
using JsonSerializerOptions = System.Text.Json.JsonSerializerOptions;
using Utf8JsonReader = System.Text.Json.Utf8JsonReader;
using Utf8JsonWriter = System.Text.Json.Utf8JsonWriter;

namespace InsuranceCompany.Web.Models.Item;

[JsonConverter(typeof(ItemBaseDtoConverter))]
public class ItemBaseDto
{
    public int Index { get; set; }
    public string Key { get; set; }
    public string Description { get; set; }
    public virtual ItemType Type { get; set; }
}
public class ItemBaseDtoConverter : JsonConverter<ItemBaseDto>
{
    public override ItemBaseDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var jsonDoc = JsonDocument.ParseValue(ref reader))
        {
            var rootElement = jsonDoc.RootElement;

            var type = rootElement.GetProperty("type").GetInt32();
            switch (type)
            {
                case 0:
                    return JsonSerializer.Deserialize<ItemComboBoxDto>(rootElement.GetRawText(), options);
                case 1:
                    return JsonSerializer.Deserialize<ItemInputBoxDto>(rootElement.GetRawText(), options);
                default:
                    throw new JsonException($"Unknown item type: {type}");
            }
        }
    }

    public override void Write(Utf8JsonWriter writer, ItemBaseDto value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }
}