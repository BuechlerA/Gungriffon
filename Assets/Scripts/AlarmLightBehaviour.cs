using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLightBehaviour : MonoBehaviour
{

    public AudioClip alarmSound;
    public AudioSource audioSource;
    public Light lightSource;

    public float lowIntensity = 1f;
    public float highIntensity = 4f;

    public float fadeSpeed = 2f;
    public float changeMargin = 0.2f;
    public float curTargetIntensity;

    public bool isAlarm;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lightSource = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlarm)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.PlayOneShot(alarmSound);             
            }
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, curTargetIntensity, fadeSpeed * Time.deltaTime);
            CheckCurTargetIntensity();
        }
        else
        {
            audioSource.Stop();
            lightSource.intensity = Mathf.Lerp(lightSource.intensity, 0f, fadeSpeed * Time.deltaTime);
        }
    }

    void CheckCurTargetIntensity()
    {
        if (Mathf.Abs(curTargetIntensity - lightSource.intensity) < changeMargin)
        {
            // ... if the target intensity is high...
            if (curTargetIntensity == highIntensity)
                // ... then set the target to low.
                curTargetIntensity = lowIntensity;
            else
                // Otherwise set the targer to high.
                curTargetIntensity = highIntensity;
        }
    }
}
