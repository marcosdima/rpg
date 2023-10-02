public class RemovableModifier : Modifier {
    private int resetPower = 0;

    public RemovableModifier(Attribute attribute, int power, ModifierAction buff) : base(attribute, power, buff) {
        this.resetPower = power * -1;
    }

    public Modifier Reset() {
        ModifierAction actionReset = ModifierAction.DEBUFF;
        if (this.IsBuff == ModifierAction.DEBUFF) actionReset = ModifierAction.BUFF; 
        
        return new RemovableModifier(this.Att, this.Power, actionReset);
    }
}