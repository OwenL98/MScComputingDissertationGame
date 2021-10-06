using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Cinemachine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameAnalytics : MonoBehaviour
{
    //Surveys
    public GameObject Survey1;
    public GameObject Survey2;
    public GameObject Survey3;
    public GameObject Survey4;
    public GameObject Survey5;
    public GameObject Survey6;
    public GameObject Survey7;
    public GameObject Survey8;

    //SurveyTrigger variables
    public Canvas canvas;
    private int SurveyNumber;
    private GameObject SurveyToDeactivate;

    //get ID on start variables
    public Canvas IdCanvas;
    public GameObject GetID;
    private InputField InputID;
    private string InputText;

    //Session Start Time variable
    private System.DateTime StartTime;


    //Pause menu variables
    public GameObject PausePanel;
    private bool IsSurvey1Active;
    private bool IsSurvey2Active;
    private bool IsSurvey3Active;
    private bool IsSurvey4Active;
    private bool IsSurvey5Active;
    private bool IsSurvey6Active;
    private bool IsSurvey7Active;
    private bool IsSurvey8Active;

    //Game Completion variables
    private bool Survey1Complete;
    private bool Survey2Complete;
    private bool Survey3Complete;
    private bool Survey4Complete;
    private bool Survey5Complete;
    private bool Survey6Complete;
    private bool Survey7Complete;
    private bool Survey8Complete;
    public GameObject CompletionCanvas;
    

    private void Awake()
    {

        StartTime = System.DateTime.Now;

        GameObject FPSCamera = GameObject.Find("FPCamera");
        gameObject.GetComponent<PlayerController>().enabled = false;
        FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;


        //Get start time & date of gaming session
        Analytics.CustomEvent("GetSessionStartTime", new Dictionary<string, object>
        {
            {"Session Start Time", StartTime }
        });

    }

    public void EnableMovement()
    {
        GameObject FPSCamera = GameObject.Find("FPCamera");
        gameObject.GetComponent<PlayerController>().enabled = true;
        FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {

        GameObject FPSCamera = GameObject.Find("FPCamera");

        //Check trigger tag, disable movement, display Circumplex Model of Affect

        if (other.CompareTag("SurveyTrigger"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 1;
            SurveyToDeactivate = Survey1;
        }

        if (other.CompareTag("SurveyTrigger2"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 2;
            SurveyToDeactivate = Survey2;
        }

        if (other.CompareTag("SurveyTrigger3"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 3;
            SurveyToDeactivate = Survey3;
        }

        if (other.CompareTag("SurveyTrigger4"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 4;
            SurveyToDeactivate = Survey4;
        }

        if (other.CompareTag("SurveyTrigger5"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 5;
            SurveyToDeactivate = Survey5;
        }

        if (other.CompareTag("SurveyTrigger6"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 6;
            SurveyToDeactivate = Survey6;
        }

        if (other.CompareTag("SurveyTrigger7"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 7;
            SurveyToDeactivate = Survey7;
        }

        if (other.CompareTag("SurveyTrigger8"))
        {
            canvas.enabled = true;
            gameObject.GetComponent<PlayerController>().enabled = false;
            FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = false;
            SurveyNumber = 8;
            SurveyToDeactivate = Survey8;
        }
    }

    private void Update()
    {

        IsSurvey1Active = Survey1.activeSelf;
        IsSurvey2Active = Survey2.activeSelf;
        IsSurvey3Active = Survey3.activeSelf;
        IsSurvey4Active = Survey4.activeSelf;
        IsSurvey5Active = Survey5.activeSelf;
        IsSurvey6Active = Survey6.activeSelf;
        IsSurvey7Active = Survey7.activeSelf;
        IsSurvey8Active = Survey8.activeSelf;

        //get input id from start canvas
        InputID = GetID.GetComponent<InputField>();
        InputText = InputID.text.ToString();


        
        //if canvas is activated from OnTrigger, get mouse position and send coordinates to relavent survey
        if (canvas.isActiveAndEnabled)
        {
            //Only logs click when click is on canvas
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 mousePosition = Input.mousePosition;

                    //Each trigger has a survey number, when triggered this is sent to SurveyNumber
                    // switch creates customevent for each survey number
                    switch (SurveyNumber)
                    {
                        case 1:
                            Analytics.CustomEvent("surveyResponse", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID", InputText},
                            {"SessionStartTime", StartTime }
                        });
                            Survey1Complete = true;
                            break;

                        case 2:
                            Analytics.CustomEvent("surveyResponse2", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID", InputText },
                            {"SessionStartTime", StartTime }
                        });
                            Survey2Complete = true;
                            break;

                        case 3:
                            Analytics.CustomEvent("surveyResponse3", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID",InputText },
                            {"SessionStartTime", StartTime }
                        });
                            Survey3Complete = true;
                            break;

                        case 4:
                            Analytics.CustomEvent("surveyResponse4", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID",InputText },
                            {"SessionStartTime", StartTime }
                        });
                            Survey4Complete = true;
                            break;

                        case 5:
                            Analytics.CustomEvent("surveyResponse5", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID",InputText },
                            {"SessionStartTime", StartTime }
                        });
                            Survey5Complete = true;
                            break;

                        case 6:
                            Analytics.CustomEvent("surveyResponse6", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID",InputText },
                            {"SessionStartTime", StartTime }
                        });
                            Survey6Complete = true;
                            break;

                        case 7:
                            Analytics.CustomEvent("surveyResponse7", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID",InputText },
                            {"SessionStartTime", StartTime }
                        });
                            Survey7Complete = true;
                            break;

                        case 8:
                            Analytics.CustomEvent("surveyResponse8", new Dictionary<string, object>
                        {
                            {"xcoordinates", mousePosition.x },
                            {"ycoordinates", mousePosition.y },
                            {"Timesubmitted", System.DateTime.Now },
                            {"ParticipantID",InputText },
                            {"SessionStartTime", StartTime }
                        });
                            Survey8Complete = true;
                            break;
                    }

                    canvas.enabled = false;
                    gameObject.GetComponent<PlayerController>().enabled = true;
                    GameObject FPSCamera = GameObject.Find("FPCamera");
                    FPSCamera.GetComponent<CinemachineVirtualCamera>().enabled = true;
                    SurveyToDeactivate.SetActive(false);
                    SurveyToDeactivate.GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
        if (Survey1Complete.Equals(true) && Survey2Complete.Equals(true) && Survey3Complete.Equals(true) && Survey4Complete.Equals(true) && Survey5Complete.Equals(true) && Survey6Complete.Equals(true) && Survey7Complete.Equals(true) && Survey8Complete.Equals(true))
        {
            CompletionCanvas.SetActive(true);
        }
    }

    public void SaveInfo()
    {
        if (IsSurvey1Active == true || IsSurvey2Active == true || IsSurvey3Active == true || IsSurvey4Active == true || IsSurvey5Active == true || IsSurvey6Active == true || IsSurvey7Active == true || IsSurvey8Active == true)
        {
            if (GameObject.Find("NoSaveMessage") == null)
            {
                GameObject CannotSaveText = new GameObject("NoSaveMessage");
                Text text = CannotSaveText.AddComponent<Text>();
                text.text = "Cannot save, please return to the center and complete the survey before saving";
                text.transform.SetParent(PausePanel.transform);
                text.transform.localPosition = new Vector3(-3, 120, 0);
                text.rectTransform.sizeDelta = new Vector2(300, 100);

                Font arial;
                arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
                text.font = arial;
            }

        }
        else
        {
            GameObject CannotSaveText = GameObject.Find("NoSaveMessage");
            Destroy(CannotSaveText);

            Save.SavePlayer(this, IsSurvey1Active, IsSurvey2Active, IsSurvey3Active, IsSurvey4Active, IsSurvey5Active, IsSurvey6Active, IsSurvey7Active, IsSurvey8Active);
        }
    }

    public void LoadInfo()
    {
        SaveData data = Save.LoadData();

        Vector3 position;
        position.x = data.PlayerPosition[0];
        position.y = data.PlayerPosition[1];
        position.z = data.PlayerPosition[2];

        transform.position = position;


        if (data.surveyActive1.Equals(true))
        {
            Survey1.SetActive(true);
        }
        else
        {
            Survey1.SetActive(false);
        }

        if (data.surveyActive2.Equals(true))
        {
            Survey2.SetActive(true);
        }
        else
        {
            Survey2.SetActive(false);
        }

        if (data.surveyActive3.Equals(true))
        {
            Survey3.SetActive(true);
        }
        else
        {
            Survey3.SetActive(false);
        }

        if (data.surveyActive4.Equals(true))
        {
            Survey4.SetActive(true);
        }
        else
        {
            Survey4.SetActive(false);
        }

        if (data.surveyActive5.Equals(true))
        {
            Survey5.SetActive(true);
        }
        else
        {
            Survey5.SetActive(false);
        }

        if (data.surveyActive6.Equals(true))
        {
            Survey6.SetActive(true);
        }
        else
        {
            Survey6.SetActive(false);
        }

        if (data.surveyActive7.Equals(true))
        {
            Survey7.SetActive(true);
        }
        else
        {
            Survey7.SetActive(false);
        }

        if (data.surveyActive8.Equals(true))
        {
            Survey8.SetActive(true);
        }
        else
        {
            Survey8.SetActive(false);
        }

    }
    
}
