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

    public ItemDescription? GetItemDescription(ItemReference target) {
        string root = "Items.";
        JsonElement element = Translator.GetJsonObject(InfoPath, root + target.ToString());
        ItemDescription? result = JsonSerializer.Deserialize<ItemDescription>(element.GetRawText());
        return result;
    }

    public Item GetItem(ItemReference target) {
        JsonElement element = Translator.GetJsonObject(itemPath, target.ToString());

        ItemStats? stats = JsonSerializer.Deserialize<ItemStats>(element.GetRawText());

        if (target.Category == ItemCategory.RECOVERY) return new Recovery(stats?.Attribute ?? Attribute.HP, stats?.Power ?? 0);
        
        // If doesn't find a proper category, returns a default item...
        Console.WriteLine("No category found...");
        return new Recovery(Attribute.HP, 0);
    }

    public static JsonElement GetJsonObject(string path, string target) {
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
}