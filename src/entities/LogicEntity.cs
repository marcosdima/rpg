public class LogicEntity {
    private static int entityCounter = 1;
    private int id;
    public int ID { get => id; private set => id = value; }

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

}