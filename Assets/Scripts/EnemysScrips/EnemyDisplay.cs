using UnityEngine;

public class EnemyDisplay : MonoBehaviour
{
    private ObjectsMoveForvard objectsMoveForvard;

    private MeshRenderer meshRenderer;

    private void Awake() {
        objectsMoveForvard = gameObject.GetComponent<ObjectsMoveForvard>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void ApplyEnemyPropertys(EnemyData enemyData){
        meshRenderer.material = enemyData.enemyMaterial;
        objectsMoveForvard.SetForwardMoveSpeed(enemyData.enemyMoveSpeed);
        gameObject.tag = enemyData.enemyTag;
    }

}
