using System.Text.Json.Serialization;
// This class only exists to link the json file to the actual SkillReference class.
public class SkillReferenceJSON {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SkillName Name { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public SkillCategory Type { get; set; }

    public SkillReference ToReference() => new SkillReference(Name, Type);
}