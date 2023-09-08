using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Hit : LogicSkill {
 
    public Hit() : base(SkillName.HIT) {}

    override protected void UseOn(Character ch) {
        ch.RecieveModifier(new Damage(this.GetPower()));
    }

    override public int GetPower() {
        // It's negative beacuse it want to deacrese the HP of the target.
        int casterATT = this.GetCaster().GetAttribute(Attribute.ATK) * -1;
        return casterATT;
    }

}