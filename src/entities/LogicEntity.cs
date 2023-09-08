public class LogicEntity {
    private static int entityCounter = 1;
    private int ID;

    public LogicEntity() {
        this.SetID();
    }

    private void SetID() {
        this.ID = LogicEntity.entityCounter;
        this.IncEntityCounter();
    }

    private void IncEntityCounter() {
        LogicEntity.entityCounter++;
    }

    public int GetID() {
        return this.ID;
    }
}