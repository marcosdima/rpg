using System.Collections.Generic;

public class SimpleSkill : LogicSkill {
    private int applies;
    private Dictionary<Modifier, int> modifiers;
    private Attribute attribute;

    public SimpleSkill(Attribute attribute, int applies, Dictionary<Modifier, int> modifiers) : base(RarityGrade.LOW) {
        this.applies = applies;
        this.attribute = attribute;
        this.modifiers = modifiers;
        this.SetModifiers(modifiers);
    }

    private void SetModifiers(Dictionary<Modifier, int> modifiers) {
        this.modifiers = new Dictionary<Modifier, int>();
        foreach (KeyValuePair<Modifier, int> kpv in modifiers) {
            kpv.Key.SetPower(this.PorcetualPower(kpv.Value));
            this.modifiers.Add(kpv.Key, kpv.Value);
        }
    }

    private int PorcetualPower(int p) => (this.GetPower() * p) / 100;

    private void UpdateModfiers() {
        foreach (KeyValuePair<Modifier, int> mod in this.modifiers) mod.Key.SetPower(this.PorcetualPower(mod.Value));
    }

    override protected void UseOn(Character ch) {
        this.UpdateModfiers();
        for (int i = 0; i < applies; i++) 
            foreach (KeyValuePair<Modifier, int> mod in this.modifiers) ch.RecieveModifier(mod.Key);
    }

    override public int GetPower() {
        int casterStat = (this.GetCaster()?.GetAttribute(this.attribute)) ?? 0;
        int power = casterStat + this.GetLevel() + this.Rarity.Interger;
        return power;
    }
}