using System;
using System.Collections.Generic;

public class Human : Species {
    public static readonly int HP = 100;
    public static readonly int MP = 100;
    public static readonly int DEFAULT_STATS_NUMBER = 10;
    public static List<LogicSkill> defaultSkills = new List<LogicSkill>(); 

    public Human() : base(Human.HP, Human.MP, Human.DEFAULT_STATS_NUMBER) {
        // Sets the skills of Human if they're null.
        if (Human.defaultSkills == null) {
            this.SetDefaultSkills();
        }
    }

    private void SetDefaultSkills() {
        
    }

    public override List<LogicSkill> GetDefaultAbilities() {
        Random rand = new Random();
        int numberOfSkills = rand.Next(0, Human.defaultSkills.Count);
        List<LogicSkill> response = new List<LogicSkill>(numberOfSkills);

        // Adds the first 'numberOfSkills' skills of Human.defaultSkills.
        for (int i = 0; i < numberOfSkills; i++) response.Add(Human.defaultSkills[i]);

        return new List<LogicSkill>(response);
    }
}