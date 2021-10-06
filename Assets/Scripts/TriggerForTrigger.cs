using UnityEngine;
using System.Collections;

/******************************************************************************/

//Author: French, J. 2019.
//Title: How to fade audio in Unity: I tested every method, this one’s the best.
//Available at: https://gamedevbeginner.com/how-to-fade-audio-in-unity-i-tested-every-method-this-ones-the-best/
//Accessed: 2 October 2021
//The above was used for FadeAudio function

/******************************************************************************/

public class TriggerForTrigger : MonoBehaviour
{
    public GameObject SurveyTrigger;
    public GameObject SurveyTrigger2;
    public GameObject SurveyTrigger3;
    public GameObject SurveyTrigger4;
    public GameObject SurveyTrigger5;
    public GameObject SurveyTrigger6;
    public GameObject SurveyTrigger7;
    public GameObject SurveyTrigger8;


    public GameObject TriggerForSurvey1;
    public GameObject TriggerForSurvey2;
    public GameObject TriggerForSurvey3;
    public GameObject TriggerForSurvey4;
    public GameObject TriggerForSurvey5;
    public GameObject TriggerForSurvey6;
    public GameObject TriggerForSurvey7;
    public GameObject TriggerForSurvey8;

    public AudioSource LightAudio;
    public AudioSource DarkAudio;


    //Author French (2019)
    private static IEnumerator FadeAudio(AudioSource audio, float duration, float TargetVolume)
    {
        float currentTime = 0;
        float start = audio.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audio.volume = Mathf.Lerp(start, TargetVolume, currentTime / duration);
            yield return null;
        }
        yield break;

    }
    //End of code used


    private void OnTriggerEnter(Collider other)
    {
        //Location 1 = silent light - was 1
        //Location 2 = silence to sound dark - was 8
        //Location 3 = static light - was 2
        //Location 4 = sound to silence dark - was 7
        //Location5 = silence to sound light - was 4
        //Location 6 = static dark - was 6
        //Location 7 = Sound to silence light - was 3
        //Location 8 = silence dark- was 5

        if (other.CompareTag("TriggerForSurvey2")) //Static NOW LOCATION 3
        {
            LightAudio.time = 13;
            LightAudio.Play();
        }

        if (other.CompareTag("TriggerForSurvey3")) //Sound to silent NOW LOCATION 7
        {
            LightAudio.time = 13;
            LightAudio.Play();
            LightAudio.volume = 0.5f;
            StartCoroutine(FadeAudio(LightAudio, 50, 0));
        }

        if (other.CompareTag("TriggerForSurvey4")) // Silence to sound NOW LOCATION 5
        {
            LightAudio.time = 13;
            LightAudio.PlayDelayed(10f);
            LightAudio.volume = 0;
            StartCoroutine(FadeAudio(LightAudio, 50, 1));
        }

        if (other.CompareTag("TriggerForSurvey6")) // Static NOW LOCATION 6
        {
            DarkAudio.Play();
        }

        if (other.CompareTag("TriggerForSurvey7")) // Sound to silent NOW LOCATION 4
        {
            DarkAudio.Play();
            DarkAudio.volume = 1;
            StartCoroutine(FadeAudio(DarkAudio, 50, 0));
        }

        if (other.CompareTag("TriggerForSurvey8"))//Silent to sound NOW LOCATION 2
        {
            DarkAudio.PlayDelayed(10f);
            DarkAudio.volume = 0;
            StartCoroutine(FadeAudio(DarkAudio, 50, 1));
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerForSurvey1"))
        {
            SurveyTrigger.SetActive(true);
        }

        if (other.CompareTag("TriggerForSurvey2"))
        {
            SurveyTrigger2.SetActive(true);
            LightAudio.Stop();
        }

        if (other.CompareTag("TriggerForSurvey3"))
        {
            SurveyTrigger3.SetActive(true);
            LightAudio.Stop();
            StopAllCoroutines();
        }

        if (other.CompareTag("TriggerForSurvey4"))
        {
            SurveyTrigger4.SetActive(true);
            LightAudio.Stop();
            StopAllCoroutines();
        }

        if (other.CompareTag("TriggerForSurvey5"))
        {
            SurveyTrigger5.SetActive(true);
        }

        if (other.CompareTag("TriggerForSurvey6"))
        {
            SurveyTrigger6.SetActive(true);
            DarkAudio.Stop();
        }

        if (other.CompareTag("TriggerForSurvey7"))
        {
            SurveyTrigger7.SetActive(true);
            DarkAudio.Stop();
            StopAllCoroutines();
        }

        if (other.CompareTag("TriggerForSurvey8"))
        {
            SurveyTrigger8.SetActive(true);
            DarkAudio.Stop();
            StopAllCoroutines();
        }

    }

}
