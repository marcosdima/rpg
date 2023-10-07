using System.Text.Json;

public class Translator {
    private Language lang;
    private const string basePath = "./rpg/files";
    private const string infoPath = basePath +"/info";
    private const string itemPath = basePath + "/items.json";
    private const string skillPath = basePath + "/skills.json";
    private const string speciesPath = basePath + "/species.json";

    // Properties.
    public string InfoPath { get => infoPath + "/" + lang + ".json"; }

    public Translator(Language lang) {
        this.lang = lang;
    }

    private JsonElement GetJsonElement(string path, string target) {
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

    // MODIFIERS //
    public List<Modifier> GetModifiers(List<ModifierStat> modifierTypes) {
        List<Modifier> modifiers = new List<Modifier>();
        
        foreach (var modifierType in modifierTypes) {
            switch (modifierType.Type) {
                case ModifierType.MODIFIER:
                    modifiers.Add(new Modifier(modifierType.Att, 0, modifierType.Action));
                    break;
                default:
                    Console.WriteLine($"Error: ModfierType: {modifierType} doesn't exists...");
                    break;
            }

        }

        Console.WriteLine(modifiers[0]);

        return modifiers;
    }

    // ITEMS //
    public ItemDescription GetItemDescription(ItemReference target) {
        string root = "Items.";
        JsonElement element = this.GetJsonElement(InfoPath, root + target.ToString());
        ItemDescription result = JsonSerializer.Deserialize<ItemDescription>(element.GetRawText()) ?? new ItemDescription();
        return result;
    }

    public Item GetItem(ItemReference target) {
        JsonElement element = this.GetJsonElement(itemPath, target.ToString());

        ItemStats? stats = JsonSerializer.Deserialize<ItemStats>(element.GetRawText());

        if (target.Category == ItemCategory.RECOVERY) return new Recovery(stats?.Attribute ?? Attribute.HP, stats?.Power ?? 0);
        
        // If doesn't find a proper category, returns a default item...
        Console.WriteLine("No category found...");
        return new Recovery(Attribute.HP, 0);
    }

    // SKILLS //
    public LogicSkill GetLogicSkill(SkillReference target) {
        LogicSkill result;

        JsonElement element = this.GetJsonElement(skillPath, target.ToString());
        SkillStats? stats = JsonSerializer.Deserialize<SkillStats>(element.GetRawText());

        // Sets a dictionary to instantiate the skill...
        Dictionary<Modifier, int> modifiers = this.GetSkillModifiers(stats?.Modifiers ?? new List<ModifierStat>());

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

    public Dictionary<Modifier, int> GetSkillModifiers(List<ModifierStat> modifierTypes) {
        Dictionary<Modifier, int> modifiers = new Dictionary<Modifier, int>();
        
        foreach (var modifierType in modifierTypes) {
            switch (modifierType.Type) {
                case ModifierType.MODIFIER:
                    modifiers.Add(new Modifier(modifierType.Att, 0, modifierType.Action), modifierType.Percentage);
                    break;
                default:
                    Console.WriteLine($"Error: ModfierType: {modifierType} doesn't exists...");
                    break;
            }

        }

        return modifiers;
    }

    // SPECIES //
    public Species GetSpecies(Race race, SpeciesName species) {
        Species result;
        int nullValue = 1;

        // Gets the info from the json...
        string path = race + "." + species;
        JsonElement jsonElement = this.GetJsonElement(speciesPath, path);
        SpeciesStats? stats = JsonSerializer.Deserialize<SpeciesStats>(jsonElement.GetRawText());

        // Sets the skill list...
        List<LogicSkill> skills = new List<LogicSkill>();
        foreach (SkillReferenceJSON reference in stats?.DefaultSkills ?? new List<SkillReferenceJSON>()) skills.Add(this.GetLogicSkill(reference.ToReference()));

        // Instantiate the especies.
        result = new Species(race, species, stats?.HP ?? nullValue, stats?.MP ?? nullValue, stats?.STATS_NUMBER ?? nullValue, skills);

        return result;
    }
}