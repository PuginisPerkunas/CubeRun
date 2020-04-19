using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int id;

    public int GetId(){
        return id;
    }

    private void SetId(int id){
        this.id = id;
    }

    private void Awake() {
        SetId(GameConstantsAndIds.Instance.GetEnemyId());
    }

    void Start()
    {
        GameEvents.current.onEnemyDestroyRequred += OnDestroyRequred;
    }

    private void OnDestroyRequred(int enemyId)
    {
        if(enemyId == id){
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        GameEvents.current.onEnemyDestroyRequred -= OnDestroyRequred;
    }

}
