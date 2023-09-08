using System.Collections.Generic;

public interface IEntity {
    public void LearnSkill(LogicSkill skill);
    public List<LogicSkill> GetSkills();
    public Species GetSpecies();
    public string GetName();
    public Dictionary<Attribute, IStatusField> GetStatus();
    public void RecieveModifier(Modifier mod);
    public int GetID();
}