using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private EnemyWithColor currentCollor;
    [SerializeField]
    private MeshRenderer meshRenderer;
    [SerializeField]
    public EnemyWithColor[] enemysWithTagsWithColors;
    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        SetRandomPlayerColor();
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == currentCollor.enemyColorTag){
            Destroy(collision.gameObject);
            SetRandomPlayerColor();
        }else{
            for (int i = 0; i < enemysWithTagsWithColors.Length; i++)
            {
                //Need this check because we can collide with anything 
                if(collision.gameObject.tag == enemysWithTagsWithColors[i].enemyColorTag){
                   // playerMovement.enabled = false;
                }
            }
        }
    }

    private void SetRandomPlayerColor()
    {
        currentCollor = enemysWithTagsWithColors[Random.Range(0, enemysWithTagsWithColors.Length)];
        meshRenderer.material.color = currentCollor.enemyColor;
    }
}
