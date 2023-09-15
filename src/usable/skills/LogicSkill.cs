public abstract class LogicSkill : Rarity, IExp {
    public readonly SkillName name;
    private Character? caster;
    private int uses = 0;

    // IExp //
    private int exp = 0;
    private int level = 0;

    // IRarity //
    //private Rarity rarity;

    public LogicSkill(SkillName name, RarityGrade rarity) : base(rarity) {
        this.name = name;
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