public abstract class LogicSkill : IExp {
    public readonly SkillName name;
    private Character? caster;
    private int uses = 0;

    // IExp //
    private int exp = 0;
    private int level = 0;

    // Rarity //
    private Rarity rarity;
    private Rarity Rarity { get => rarity; }

    public LogicSkill(SkillName name, RarityGrade rarity) {
        this.name = name;
        this.rarity = new Rarity(rarity);
    } 
    
    public void CastOn(Character ch) {
        this.UseOn(ch);
        this.uses++;
    }

    protected abstract void UseOn(Character ch);

    public abstract int GetPower();

    public void SetCaster(Character caster) {
        this.caster = caster;
    }

    public Character? GetCaster() {
        return this.caster;
    }
    
    // IExp //
    public int GetExp() {
        return this.exp;
    }
    
    public int GetLevel() {
        return this.level;
    }
    
    public void IncreaseLevel() {
        // TO DO //
    }
}