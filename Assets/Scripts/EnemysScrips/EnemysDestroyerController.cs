using UnityEngine;

public class EnemysDestroyerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Destroy(other.gameObject);
    }
}
