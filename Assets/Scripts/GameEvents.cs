using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake() {
        //Todo maybe should change that with SingletonClassAbstractor, will decide in future
        current = this;
    }

    public event Action onEnemyCollisionEnter;
    public void EnemyCollisionEnter(){
        onEnemyCollisionEnter?.Invoke();
    }

    public event Action<int> onEnemyDestroyRequred;
    public void EnemeyDestroyRequred(int enemyId){
        onEnemyDestroyRequred?.Invoke(enemyId);
    }

    public event Action onPlayerDestroyRequred;
    public void PlayerDestroyRequred(){
        onPlayerDestroyRequred?.Invoke();
    }
}
