public class SimpleSkill : LogicSkill {
    private int applies;
    private List<Modifier> modifiers = new List<Modifier>();
    private Attribute attribute;

    public SimpleSkill(Attribute attribute, int applies, List<Modifier> modifiers) : base(RarityGrade.LOW) {
        this.applies = applies;
        this.SetModifiers(modifiers);
    }

    private void SetModifiers(List<Modifier> modifiers) {
        foreach (Modifier mod in modifiers) {
            mod.SetPower(this.GetPower());
            this.modifiers.Add(mod);
        }
    }

    private void UpdateModfiers() {
        foreach (Modifier mod in this.modifiers) {
            mod.SetPower(this.GetPower());
            Console.WriteLine(mod + " => " + this.GetPower());
        }
    }

    override protected void UseOn(Character ch) {
        this.UpdateModfiers();
        for (int i = 0; i < applies; i++) 
            foreach (Modifier mod in modifiers) {
                Console.WriteLine("Modifier: " + mod);
                ch.RecieveModifier(mod);
            }
    }

    override public int GetPower() {
        int casterStat = (this.GetCaster()?.GetAttribute(this.attribute)) ?? 0;
        int power = casterStat + this.GetLevel();
        return power;
    }

}