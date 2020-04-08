using UnityEngine;

public class PlatformController : MonoBehaviour
{
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
        if(platformsManager != null){
            platformsManager.RecyclePlatform(this.gameObject);
        }
    }
}
