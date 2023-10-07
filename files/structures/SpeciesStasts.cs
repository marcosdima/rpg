public class SpeciesStats {
    public int HP { get; set; } = 1;
    public int MP { get; set; } = 1;
    public int STATS_NUMBER { get; set; } = 1;

    public List<SkillReferenceJSON> DefaultSkills { get; set; } = new List<SkillReferenceJSON>();
}