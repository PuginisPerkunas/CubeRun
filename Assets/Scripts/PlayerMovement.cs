using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardMoveSpeed = 2000f;
    public float sidesMoveSpeed = 500f;

    private float minFallDetectionValue = -5;

    private void FixedUpdate() {
        // Forward movement
        rb.AddForce(0,0, forwardMoveSpeed * Time.deltaTime);
        // Side movement
        if(Input.GetKey("a")){
            rb.AddForce(-sidesMoveSpeed * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }
        if(Input.GetKey("d")){
            rb.AddForce(sidesMoveSpeed * Time.deltaTime, 0 , 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < minFallDetectionValue){
            //Todo uncomment when GameManager egsist in scene
            //FindObjectOfType<GameManager>().EndGame();
        }
    }
}
