using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Update is called once per frame
    private void FixedUpdate(){
        transform.position = new Vector3(offset.x, offset.y , Mathf.Round(player.transform.position.z + offset.z));
    }
}
