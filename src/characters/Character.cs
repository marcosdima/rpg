using System;
using System.Collections.Generic;
using RandomSystem = System.Random;

public class Character : LogicEntity, IExp, IEntity {

    private Species species;
    private BaseAttributes baseAttributes;
    private Status status;
    private List<LogicSkill> skills;
    private ModifierHandler modifierHandler;
    private AttributeHandler attributeHandler;

    // Interfaces //
    private string name;
    private int exp = 0;
    private int level = 0;

    public Character(string name, Species species) : base() {
        this.skills = new List<LogicSkill>();
        this.species = species;
        this.name = name;

        this.SetBaseAttributes();
        this.SetStatus();
        this.SetBaseSkills();
    }
    
    private void SetBaseAttributes() {
        // Instantitiates BaseAttribute.
        this.baseAttributes = new BaseAttributes();

        // Instantitiates the handler.
        this.attributeHandler = new AttributeHandler(this.baseAttributes);

        // Adds the default number of upgrades.
        this.attributeHandler.AddUpgrades(this.species.GetDefaultStatsNumber());

        // Upgrades the stats randomly.
        Attribute[] attributes = (Attribute[]) Enum.GetValues(typeof(Attribute));
        RandomSystem rand = new RandomSystem();
        int index = rand.Next(0, attributes.Length);
        while (this.attributeHandler.HasUpgrades()) {
            // Si, medio tosco.
            if ((attributes[index] != Attribute.HP) && (attributes[index] != Attribute.MP))
                this.attributeHandler.UpgradeAttribute(attributes[index], 1);
            index = rand.Next(0, attributes.Length);
        }

        // Sets brutally HP and MP.
        this.attributeHandler.AddUpgrades(this.species.GetHP());
        this.attributeHandler.UpgradeAttribute(Attribute.HP, this.species.GetHP());
        this.attributeHandler.UpgradeAttribute(Attribute.HP, this.species.GetMP());
    }
    private void SetStatus() {
        this.status = new Status(this.baseAttributes);
        this.modifierHandler = new ModifierHandler(this.status);
    }
    private void SetBaseSkills() {
        this.skills = this.species.GetDefaultAbilities();
        foreach (LogicSkill skill in this.skills) skill.SetCaster(this);
    }
    public int GetAttribute(Attribute att) {
        return this.status.GetAttribute(att);
    }

    // IEntity //
    public void LearnSkill(LogicSkill skill) {
        // No chequea si esta habilidad ya existe.
        this.skills.Add(skill);
    }
    public List<LogicSkill> GetSkills() {
        // Debería crear ISkill?
        return this.skills;
    }
    public Species GetSpecies() {
        return this.species;
    }
    public string GetName() {
        return this.name;
    }
    public Dictionary<Attribute, IStatusField> GetStatus() {
        return this.status.GetStatusValues();
    }
    public void RecieveModifier(Modifier mod) {
        this.modifierHandler.AddModifier(mod);
        // NODEBERÏASERASI//
        this.modifierHandler.ApplyModifiers();
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