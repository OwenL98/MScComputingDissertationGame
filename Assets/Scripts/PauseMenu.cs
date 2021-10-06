using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PauseCanvas;

    private bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            if (paused)
            {
                play();
            }
            else
            {
                pause();
            }
        }
    }
    
    private void pause()
    {
        PauseCanvas.SetActive(true);
        paused = true;
        Time.timeScale = 0f;
    }

    public void play()
    {
        PauseCanvas.SetActive(false);
        paused = false;
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
