using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool isQutting = false;
    private PlatformsManager platformsManager;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        platformsManager = GameObject.FindObjectOfType<PlatformsManager>();   
    }

    /// <summary>
    /// OnBecameInvisible is called when the renderer is no longer visible by any camera.
    /// </summary>
    void OnBecameInvisible()
    {
        if(platformsManager != null && !isQutting){
            platformsManager.RecyclePlatform(this.gameObject);
        }
    }
    
    /// <summary>
    /// Callback sent to all game objects before the application is quit.
    /// </summary>
    void OnApplicationQuit()
    {
        isQutting = true;
    }
}
