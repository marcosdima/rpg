using System.Collections.Generic;
using System;

public class Species {

    public int HP { get; }
    public int MP { get; }
    public int STATS_NUMBER { get; }

    public SpeciesName Name { get; }
    public Race Race { get; }
    public List<LogicSkill> DefaultSkills { get; }

    public Species(Race race, SpeciesName name, int hp, int mp, int stats, List<LogicSkill> defaultSkills) {
        this.Name = name;
        this.Race = race;

        // The lowest stat possible value must be 1.
        this.HP = Math.Max(hp, 1);
        this.MP = Math.Max(mp, 1);
        this.STATS_NUMBER = Math.Max(stats, 1);

        this.DefaultSkills = defaultSkills;
    }

    public List<LogicSkill> GetDefaultAbilities() {
        Random rand = new Random();
        int numberOfSkills = rand.Next(0, this.DefaultSkills.Count);
        List<LogicSkill> response = new List<LogicSkill>(numberOfSkills);

        // Adds the first 'numberOfSkills' skills of Human.defaultSkills.
        for (int i = 0; i < numberOfSkills; i++) response.Add(this.DefaultSkills[i]);

        return new List<LogicSkill>(response);
    }
}
