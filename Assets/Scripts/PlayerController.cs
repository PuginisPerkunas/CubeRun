using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private EnemyWithColor currentPlayerColor;
    [SerializeField]
    private MeshRenderer playerMeshRender;
    [SerializeField]
    private EnemyWithColor[] allEnemysAndColors;
    void Start()
    {
        GameEvents.current.onPlayerDestroyRequred += PlayerDestroyRequred;
        SetRandomPlayerColor();
    }

    private void SetRandomPlayerColor()
    {
        currentPlayerColor = allEnemysAndColors[UnityEngine.Random.Range(0, allEnemysAndColors.Length)];
        playerMeshRender.material.color = currentPlayerColor.enemyColor;
    }

    private void OnCollisionEnter(Collision collision) {
        var coliderTag = collision.gameObject.tag;
        if(coliderTag== currentPlayerColor.enemyColorTag){
            var id = collision.gameObject.GetComponent<EnemyController>().GetId();
            GameEvents.current.EnemeyDestroyRequred(id);
            SetRandomPlayerColor();
        }else{
            for (int i = 0; i < allEnemysAndColors.Length; i++)
            {
                if(coliderTag == allEnemysAndColors[i].enemyColorTag){
                    GameEvents.current.PlayerDestroyRequred();
                }
            }
        }
    }

    
    private void PlayerDestroyRequred()
    {
        LeanTween.moveLocal(gameObject, new Vector3(5,5,10), 0.5f).setEase(LeanTweenType.once);
        //Todo all movements should be stoped, this could be maded with event system
          //a) by pasing "game over " event to all enemys and stoping it, also to ame manager for restart;
          //b) passing "game over" event to GameManager, whitch get all enemys, stop it and restart a game;
    }

    private void OnDestroy() {
        GameEvents.current.onPlayerDestroyRequred -= PlayerDestroyRequred;
    }
}
