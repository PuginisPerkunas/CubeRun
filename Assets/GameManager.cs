using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float restartDelay = 2f;

    public GameObject completeLevelUI;

    private bool isGameEnded = false;

    public void CompleteLevel(){
        completeLevelUI.SetActive(true);
    }

    public void EndGame(){
        if(!isGameEnded){
            Debug.Log("game over");
            isGameEnded = true;
            Invoke("RestartGame", restartDelay);
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
