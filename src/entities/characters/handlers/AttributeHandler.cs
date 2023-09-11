public class AttributeHandler {
    private int upgrades = 0;
    private BaseAttributes attributes;

    public AttributeHandler(BaseAttributes attributes) {
        this.attributes = attributes;
    }

    private void UpgradeAttribute(Attribute att) {
        this.attributes.RiseAttribute(att);
        this.upgrades--;
    }

    public void UpgradeAttribute(Attribute att, int value) {
        for (int i = 0; i < value; i++) {
            if (this.HasUpgrades()) {
                this.UpgradeAttribute(att);
            }
        }
    }

    public void AddUpgrades(int amount) {
        this.upgrades += amount;
    }

    public bool HasUpgrades() {
        return (this.upgrades > 0);
    }
}