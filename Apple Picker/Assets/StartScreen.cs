using UnityEngine;
using UnityEngine.SceneManagement; // This namespace allows scene management

public class StartScreen : MonoBehaviour
{
    // This function is called when the Start Button is clicked
    public void StartGame()
    {
        // Replace "ApplePicker" with the name of your main game scene
        SceneManager.LoadScene("_Scene_0");
    }
}