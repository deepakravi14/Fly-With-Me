using UnityEngine;

public class QuitApplication : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("The Game Had Ended");
            Application.Quit();
        }
    }
}
