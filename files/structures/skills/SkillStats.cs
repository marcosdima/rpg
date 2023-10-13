using System.Text.Json.Serialization;
using System.Collections.Generic;

public class SkillStats {
    public int Uses { get; set; } = 1;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Attribute? Attribute { get; set; }

    public List<ModifierStat>? Modifiers { get; set; }
}