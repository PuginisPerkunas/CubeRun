using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;
    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obsticle"){
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
