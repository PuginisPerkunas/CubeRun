using UnityEngine;
using UnityEngine.AI;

public class EnemyDisplay : MonoBehaviour
{
    private ObjectsMoveForvard objectsMoveForvard;

    private NavMeshAgent agent = null;

    private MeshRenderer meshRenderer;

    private void Awake() {
        objectsMoveForvard = gameObject.GetComponent<ObjectsMoveForvard>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void ApplyEnemyPropertys(EnemyData enemyData){
        meshRenderer.material = enemyData.enemyMaterial;
        objectsMoveForvard.SetForwardMoveSpeed(enemyData.enemyMoveSpeed);
        gameObject.tag = enemyData.enemyTag;
        if(agent != null){
            float dividerConstant = GameConstantsAndIds.Instance.aiSpeedDivider;
            agent.speed = enemyData.enemyMoveSpeed / (dividerConstant * 10);
        }
    }

}
