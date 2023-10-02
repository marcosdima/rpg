using System.Text.Json.Serialization;
// The default values could be a problem, we should be very cautious.
public class ModifierStat {
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ModifierType Type { get; set; } = ModifierType.MODIFIER;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ModifierAction Action { get; set; } = ModifierAction.BUFF;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Attribute Att { get; set; } = Attribute.ATK;

    public int Percentage { get; set; } = 0;
}