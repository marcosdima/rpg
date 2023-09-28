using System.Text.Json;

public class Translator {
    private Language lang;
    private const string basePath = "./rpg/files";
    private const string infoPath = basePath +"/info";
    private const string itemPath = basePath + "/items.json";
    private const string skillPath = basePath + "/skills.json";

    // Properties.
    public string InfoPath { get => infoPath + "/" + lang + ".json"; }

    public Translator(Language lang) {
        this.lang = lang;
    }

    private JsonElement GetJsonObject(string path, string target) {
        string jsonString = File.ReadAllText(path);
        JsonDocument doc = JsonDocument.Parse(jsonString);
        JsonElement root = doc.RootElement;

        string[] propiedades = target.Split('.');
        JsonElement actualObject = root;

        foreach (string propiedad in propiedades) {
            if (actualObject.TryGetProperty(propiedad, out var nextObject)) actualObject = nextObject;
            else return default;
        }

        return actualObject;
    }

    private List<Modifier> GetModifiers(List<string> modifierTypes) {
        List<Modifier> modifiers = new List<Modifier>();
        
        foreach (var modifierTypeString in modifierTypes) {
            if (Enum.TryParse(modifierTypeString, true, out ModifierType modifierType)) {
                switch (modifierType) {
                    case ModifierType.DAMAGE:
                        modifiers.Add(new Damage(0));
                        break;
                    default:
                        Console.WriteLine($"Error: ModfierType: {modifierType} doesn't exists...");
                        break;
                }
            }

        }

        Console.WriteLine(modifiers[0]);

        return modifiers;
    }

    public ItemDescription GetItemDescription(ItemReference target) {
        string root = "Items.";
        JsonElement element = this.GetJsonObject(InfoPath, root + target.ToString());
        ItemDescription result = JsonSerializer.Deserialize<ItemDescription>(element.GetRawText()) ?? new ItemDescription();
        return result;
    }

    public Item GetItem(ItemReference target) {
        JsonElement element = this.GetJsonObject(itemPath, target.ToString());

        ItemStats? stats = JsonSerializer.Deserialize<ItemStats>(element.GetRawText());

        if (target.Category == ItemCategory.RECOVERY) return new Recovery(stats?.Attribute ?? Attribute.HP, stats?.Power ?? 0);
        
        // If doesn't find a proper category, returns a default item...
        Console.WriteLine("No category found...");
        return new Recovery(Attribute.HP, 0);
    }

    public LogicSkill GetLogicSkill(SkillReference target) {
        LogicSkill result;

        JsonElement element = this.GetJsonObject(skillPath, target.ToString());
        SkillStats? stats = JsonSerializer.Deserialize<SkillStats>(element.GetRawText());

        List<Modifier> modifiers = this.GetModifiers(stats?.Modifiers ?? new List<string>());

        switch (target.Type) {
            case SkillCategory.SIMPLE_SKILL:
                result = new SimpleSkill(stats?.Attribute ?? Attribute.HP, stats?.Uses ?? 0, modifiers);
                break;
            default:
                Console.WriteLine("Error: Skill doesn't match any 'SkillCategory'");
                Console.WriteLine(target);
                // Null result.
                result = new SimpleSkill(Attribute.HP, 0, modifiers);
                break;
        }

        return result;
    }
}