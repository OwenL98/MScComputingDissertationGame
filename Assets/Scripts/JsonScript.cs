using UnityEngine;
using UnityEngine.UI;

public class JsonScript : MonoBehaviour
{

    public TextAsset JsonFile;
    public GameObject CMA;

    [System.Serializable]
    public class SurveyResponse
    {
        public string name;
        public string ycoordinates;
        public string xcoordinates;
        public string Timesubmitted;
        public string ParticipantID;
        public string SessionStartTime;
    }


    [System.Serializable]
    public class SurveyList
    {
        public SurveyResponse[] survey;

        public string GetSurveyName(int surveyNum)
        {
            return survey[surveyNum].name;
        }
        public string GetSurveyYcoordinates(int surveyNum)
        {
            return survey[surveyNum].ycoordinates;
        }
        public string GetSurveyXcoordinates(int surveyNum)
        {
            return survey[surveyNum].xcoordinates;
        }
        public string GetSurveyTimeSubmitted(int surveyNum)
        {
            return survey[surveyNum].Timesubmitted; 
        }
        public string GetSurveyParticipantID(int surveyNum)
        {
            return survey[surveyNum].ParticipantID;
        }
        public string GetSurveySessionStartTime(int surveyNum)
        {
            return survey[surveyNum].SessionStartTime;
        }
    }

    public SurveyList surveylist = new SurveyList();

    void Start()
    {
        //for each survey create a point, add to CMA
        surveylist = JsonUtility.FromJson<SurveyList>(JsonFile.text);

        for (int i = 0; i < surveylist.survey.Length;i++)
        {
            string yCoordinate = surveylist.GetSurveyYcoordinates(i);
            string xCoordinate = surveylist.GetSurveyXcoordinates(i);
            string participantID = surveylist.GetSurveyParticipantID(i);
            string sessionStartTime = surveylist.GetSurveySessionStartTime(i);
            string timeSubmitted = surveylist.GetSurveyTimeSubmitted(i);

            GameObject Point = new GameObject("point");
            Point.transform.parent= CMA.transform ;
            Image PointImage = Point.AddComponent<Image>();

            Point.transform.localPosition = new Vector3(float.Parse(xCoordinate), float.Parse(yCoordinate), 0);
            RectTransform rectT = Point.GetComponent<RectTransform>();
            rectT.sizeDelta = new Vector2(10, 10);
            PointImage.color = Color.red;

         }
    }
}
