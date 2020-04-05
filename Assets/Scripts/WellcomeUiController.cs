using UnityEngine;
using UnityEngine.SceneManagement;

public class WellcomeUiController : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
