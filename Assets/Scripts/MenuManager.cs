using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
        // loads the next scene in the Build Settings list
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // closes the game application (only works in a built executable, not the Unity editor)
        Debug.Log("Quit Button Clicked");
        Application.Quit();
    }
}
