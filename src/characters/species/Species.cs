using System.Collections.Generic;
using System;
public abstract class Species {

    private int HP;
    private int MP;
    private int STATS_NUMBER;

    public Species(int hp, int mp, int number) {
        // The lowest stat possible value must be 1.
        this.HP = Math.Max(hp, 1);
        this.MP = Math.Max(mp, 1);
        this.STATS_NUMBER = Math.Max(number, 1);
    }

    public abstract List<LogicSkill> GetDefaultAbilities();

    public int GetDefaultStatsNumber() {
        return this.STATS_NUMBER;
    }

    public int GetHP() {
        return HP;
    }

    public int GetMP() {
        return MP;
    }
}
