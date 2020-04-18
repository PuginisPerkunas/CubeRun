using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    private void FixedUpdate(){
        transform.position = new Vector3(15,15, player.transform.position.z);
    }
}
