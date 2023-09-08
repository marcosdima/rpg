using System.Collections.Generic;

public class ModifierHandler {
    private List<Modifier> modifierList;
    private Status status;

    public ModifierHandler(Status status) {
        this.status = status;
        this.modifierList = new List<Modifier>();
    }
    public void ApplyModifiers() {
        foreach (Modifier modifier in this.modifierList) {
            // If the modifier has to be applied
            if (modifier.Applicable()) {
                this.ApplyModifier(modifier);
                modifier.ReduceUses();
            } else {
                if (modifier.HasToReset()) {
                    this.ResetModifier(modifier);
                }
            }
        }
    }
    public void AddModifier(Modifier mod) {
        this.modifierList.Add(mod);
    }
    public void ResetModifier(Modifier mod) {
        this.status.ModifyStatusField(mod.GetAttribute(), mod.GetPower() * -1);
    } 

    // Applies modifiers by polymorphism // ( No recuerdo porque lo quería hacer así :( )
    private void ApplyModifier(Modifier mod) {
        this.status.ModifyStatusField(mod.GetAttribute(), mod.GetPower());
    }
    //private void ApplyModifier(Debuff mod) {}
}