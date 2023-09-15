using System.Collections;
using System.Collections.Generic;
public class Hit : LogicSkill {
 
    public Hit() : base(SkillName.HIT, RarityGrade.LOW) {}

    override protected void UseOn(Character ch) {
        ch.RecieveModifier(new Damage(this.GetPower()));
    }

    override public int GetPower() {
        // It's negative beacuse it want to deacrese the HP of the target.
        int casterATT = (this.GetCaster()?.GetAttribute(Attribute.ATK) * -1) ?? 0;
        return casterATT;
    }

}