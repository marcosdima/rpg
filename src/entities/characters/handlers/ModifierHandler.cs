using System.Collections.Generic;

public class ModifierHandler {
    // This list is only to keep tracked the modifiers which were applied.
    private List<Modifier> simpleModifiers;
    // This list has the modifier which has to be reseted at the end of its life.
    private List<FiniteModifier> modifierList;
    private Status status;

    public ModifierHandler(Status status) {
        this.status = status;
        this.simpleModifiers = new List<Modifier>();
        this.modifierList = new List<FiniteModifier>();
    }
    
    public void ApplyModifiers() {
        foreach (FiniteModifier mod in this.modifierList) {
            this.ApplyModifier(mod);
        }
    }
    
    public void ResetModifier(Modifier mod) {
        this.status.ModifyStatusField(mod.Att, mod.Power * -1);
    } 

    /// <summary>
    /// Adds a new modifier (Only FiniteModifier).
    /// </summary>
    /// <param name="mod">The modifier to be added.</param>
    public void AddModifier(FiniteModifier mod) {
        this.modifierList.Add(mod);
    }

    /// <summary>
    /// Adds a new modifier.
    /// </summary>
    /// <param name="mod">The modifier to be added.</param>
    public void AddModifier(Modifier mod) {
        // Checks if its an specific kind of modifier.
        if (mod is FiniteModifier) this.AddModifier((FiniteModifier) mod);
        else {
            this.simpleModifiers.Add(mod);
            this.ApplyModifier(mod);
        }
    }

    // Applies modifiers by polymorphism // ( No recuerdo porque lo quería hacer así :( )
    private void ApplyModifier(Modifier mod) {
        this.status.ModifyStatusField(mod.Att, mod.Power);
    }
    //private void ApplyModifier(Debuff mod) {}
}