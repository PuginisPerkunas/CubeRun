using UnityEngine;

public class GameConstantsAndIds : SingletonClassAbstractor<GameConstantsAndIds>
{
    private int enemyId = 0;

    public int GetEnemyId(){
        enemyId += 1;
        return enemyId;
    }
}
