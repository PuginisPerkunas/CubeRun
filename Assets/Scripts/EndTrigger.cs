using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider collider)
    {
        gameManager.CompleteLevel();
    }
}
