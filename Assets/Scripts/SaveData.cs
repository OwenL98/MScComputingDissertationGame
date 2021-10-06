using System.Collections.Generic;

/******************************************************************************/

//Author: Brackeys 2018
//Title: SAVE & LOAD SYSTEM in Unity
//Available at: https://www.youtube.com/watch?v=XOjd_qU2Ido
//Accessed: 2 October 2021 

//The above was used to assist with the code below

/******************************************************************************/

[System.Serializable]
public class SaveData
{

    public float[] PlayerPosition;
    public bool surveyActive1;
    public bool surveyActive2;
    public bool surveyActive3;
    public bool surveyActive4;
    public bool surveyActive5;
    public bool surveyActive6;
    public bool surveyActive7;
    public bool surveyActive8;

    public List<int> DestroyedCollectable;


    public SaveData(GameAnalytics analytics,bool SurveyActive1, bool SurveyActive2, bool SurveyActive3, bool SurveyActive4, bool SurveyActive5, bool SurveyActive6, bool SurveyActive7, bool SurveyActive8)
    {

        PlayerPosition = new float[3];
        PlayerPosition[0] = analytics.transform.position.x;
        PlayerPosition[1] = analytics.transform.position.y;
        PlayerPosition[2] = analytics.transform.position.z;

        surveyActive1 = SurveyActive1;
        surveyActive2 = SurveyActive2;
        surveyActive3 = SurveyActive3;
        surveyActive4 = SurveyActive4;
        surveyActive5 = SurveyActive5;
        surveyActive6 = SurveyActive6;
        surveyActive7 = SurveyActive7;
        surveyActive8 = SurveyActive8;
    }

    public SaveData(List<int> Collectables)
    {
        DestroyedCollectable = Collectables;
    }

}
