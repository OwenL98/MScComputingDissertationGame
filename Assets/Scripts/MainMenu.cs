using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button StartButton;
    public Text StartText;

    private void Awake()
    {
        bool checkSaveExists = Save.CheckPathExists();

        if (checkSaveExists.Equals(true))
        {
            StartButton.enabled = false;
            StartButton.image.enabled = false;
            StartText.enabled = false;
        }
        else
        {
            StartButton.enabled = true;
        }
    }

}
