using UnityEngine;

public class GameConstantsAndIds : SingletonClassAbstractor<GameConstantsAndIds>
{
    internal int aiSpeedDivider = 10;
    private int enemyId = 0;

    public int GetEnemyId(){
        enemyId += 1;
        return enemyId;
    }
}
