using UnityEngine;

public class ChangeSkyBox : MonoBehaviour
{
    public Material SkyboxSunny;
    public Material SkyboxDark;
    public Light DirectionalLight;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SkyboxTrigger"))
        {
            RenderSettings.skybox = SkyboxDark;
            RenderSettings.fog = true;
            RenderSettings.ambientIntensity = 0.1f;
            DirectionalLight.intensity = 0.5f;
            DirectionalLight.shadowStrength = 0.5f;

            RenderSettings.reflectionIntensity = 0.3f;
        }


    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("SkyboxTrigger"))
        {
            RenderSettings.skybox = SkyboxSunny;
            RenderSettings.fog = false;
            RenderSettings.ambientIntensity = 1f;
            DirectionalLight.intensity = 1f;
            DirectionalLight.shadowStrength = 1f;
            RenderSettings.reflectionIntensity = 1f;
        }

    }

}
