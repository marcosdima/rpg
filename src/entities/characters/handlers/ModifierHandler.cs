// Tengo que ver que hacer con la aplicación de los modificadores, LOL.

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

    // Applies modifiers by polymorphism //
    private void ApplyModifier(RemovableModifier mod) {
        // Sets the reset power as the opposite of the actual magnitude applied on the field.
        mod.ResetPower = this.status.ModifyStatusField(mod.Att, mod.Power) * -1;
    }
    
    private void ApplyModifier(Modifier mod) {
        this.status.ModifyStatusField(mod.Att, mod.Power);
    }
    //private void ApplyModifier(Debuff mod) {} 

    private void Clean() {
        List<int> toEliminate = new List<int>();

        // Searchs for the index of every not applicable modifier...
        for (int i = 0; i < this.modifierList.Count; i++) if (!this.modifierList[i].Applicable()) toEliminate.Add(i);

        // and Resets and Eliminates them.
        foreach (int i in toEliminate) {
            this.ResetModifier(this.modifierList[i]);
            this.modifierList.RemoveAt(i);
        }
    }

    public void ApplyModifiers() {
        foreach (FiniteModifier mod in this.modifierList) if (mod.Applicable()) mod.ReduceUses();
        this.Clean();
    }
    
    public void ResetModifier(Modifier mod) {
        FiniteModifier? modAux = null;

        // Finds
        foreach (FiniteModifier target in this.modifierList) if (target == mod) modAux = target;

        if (modAux == null) return;
        
        this.status.ModifyStatusField(modAux.Att, modAux.ResetPower);
    } 

    /// <summary>
    /// Adds a new modifier (Only FiniteModifier).
    /// </summary>
    /// <param name="mod">The modifier to be added.</param>
    public void AddModifier(FiniteModifier mod) {
        this.modifierList.Add(mod);
        this.ApplyModifier(mod);
    }

    /// <summary>
    /// Adds a new modifier.
    /// </summary>
    /// <param name="mod">The modifier to be added.</param>
    public void AddModifier(Modifier mod) {
        // Checks if its an specific kind of modifier.
        if (mod is FiniteModifier modifier) this.AddModifier(modifier);
        else {
            this.simpleModifiers.Add(mod);
            this.ApplyModifier(mod);
        }
    }
}