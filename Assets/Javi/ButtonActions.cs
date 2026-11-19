using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    public float StartTime = 1;

    public void Startbutton(string sceneName)
    {
        Time.timeScale = StartTime;
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("yo");
    }
}
