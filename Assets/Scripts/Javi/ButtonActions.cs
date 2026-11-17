using UnityEngine;

public class ButtonActions : MonoBehaviour
{
    public void Start()
    {
       
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("yo");
    }
}
