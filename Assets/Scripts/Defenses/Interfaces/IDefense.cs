using System.Collections;

public interface IDefense {
    void InitStats();
    void DefenseUpdate();
    void StatChanged(DefenseStat stat);
    void AttemptFire();
    void ExecuteFire();
}