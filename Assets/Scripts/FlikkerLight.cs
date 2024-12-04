using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FlikkerLight : MonoBehaviour
{
    public Light2D pointLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 1.5f;
    public float flickerSpeed = 0.1f;
    public bool randomizeSpeed = true;

    private float nextFlickerTime;
    void Start()
    {
        pointLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if it's time to flicker
        if (Time.time >= nextFlickerTime)
        {
            // Randomize the light intensity within the range
            pointLight.intensity = Random.Range(minIntensity, maxIntensity);

            // Determine the next flicker time
            nextFlickerTime = Time.time + (randomizeSpeed ? Random.Range(0.05f, flickerSpeed) : flickerSpeed);
        }
    }
}
