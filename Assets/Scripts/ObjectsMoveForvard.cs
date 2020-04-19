using UnityEngine;

public class ObjectsMoveForvard : MonoBehaviour
{
    [SerializeField]
    private float forwardMoveSpeed = 1000f;

    public void SetForwardMoveSpeed(float speed){
        forwardMoveSpeed = speed;
    }
    // Update is called once per frame
    private void FixedUpdate(){
        // Forward movement
        gameObject.GetComponent<Rigidbody>().AddForce (0, 0, forwardMoveSpeed * Time.deltaTime);
    }
}
