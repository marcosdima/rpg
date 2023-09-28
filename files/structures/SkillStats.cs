using System.Text.Json.Serialization;

public class SkillStats {
    public int Uses { get; set; } = 1;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Attribute Attribute { get; set; } = Attribute.ATK;

    public List<string>? Modifiers { get; set; }
}