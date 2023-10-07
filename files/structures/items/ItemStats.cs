using System.Text.Json.Serialization;

public class ItemStats {
    public int Power { get; set; } = 0;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Attribute Attribute { get; set; } = Attribute.ATK;
}