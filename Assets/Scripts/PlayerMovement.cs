using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;
    public float forwardMoveSpeed = 2000f;
    private float minFallDetectionValue = -5;

    void Awake () {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
    }

    private void FixedUpdate(){
        // Side movement
        if (Input.GetKey ("a")) {
           MovePlayer(SwipeDirection.Right);
        }
        if (Input.GetKey ("d")) {
            MovePlayer(SwipeDirection.Left);
        }
        //Reset the game when fall from platform
        if (rb.position.y < minFallDetectionValue) {
            //Todo uncomment when GameManager egsist in scene
            //FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void SwipeDetector_OnSwipe (SwipeData data) {    
        MovePlayer(data.Direction);
    }

    private void MovePlayer(SwipeDirection direction){
        switch (direction)
        {
            case SwipeDirection.Left:
                    Vector3 endPosition = new Vector3(rb.position.x + 2, 1.05f, rb.position.z);
                    LeanTween.moveLocal(gameObject, endPosition, 0.2f).setEase( LeanTweenType.once );
                break;
            
            case SwipeDirection.Right:
                    Vector3 endPositionRight = new Vector3(rb.position.x - 2, 1.05f,rb.position.z);
                    LeanTween.moveLocal(gameObject, endPositionRight, 0.2f).setEase( LeanTweenType.once );
                break;
            
            default: break;
        }
    }

}