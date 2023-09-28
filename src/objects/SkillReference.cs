public class SkillReference {
    public SkillName Name { get; set; }
    public SkillCategory Type { get; set; }

    public SkillReference(SkillName name, SkillCategory cat) {
        this.Type = cat;
        this.Name = name;
    }

    public override string ToString() {
        return $"{this.Type}.{this.Name}";
    }
}