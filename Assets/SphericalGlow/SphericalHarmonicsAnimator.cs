using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SphericalHarmonicsAnimator : MonoBehaviour
{
    public Material sphereMaterial;

    float lastUpdate;
    float updateInterval = 30.0f;

    float targetM0;
    float targetM1;
    float targetM2;
    float targetM3;
    float targetM4;
    float targetM5;
    float targetM6;
    float targetM7;

    void Start()
    {
        targetM0 = 6;
        targetM1 = 6;
        targetM2 = 6;
        targetM3 = 6;
        // targetM4 = Random.Range(0, 6);
        // targetM5 = Random.Range(1, 6);
        // targetM6 = Random.Range(0, 6);
        // targetM7 = Random.Range(1, 6);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Time.time - lastUpdate > updateInterval || Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Space))
        {
            targetM0 = Random.Range(0, 6);
            targetM1 = Random.Range(1, 6);
            targetM2 = Random.Range(0, 6);
            targetM3 = Random.Range(1, 6);
            targetM4 = Random.Range(0, 6);
            targetM5 = Random.Range(1, 6);
            targetM6 = Random.Range(0, 6);
            targetM7 = Random.Range(1, 6);

            sphereMaterial.SetFloat("m0", targetM0);
            sphereMaterial.SetFloat("m1", targetM1);
            sphereMaterial.SetFloat("m2", targetM2);
            sphereMaterial.SetFloat("m3", targetM3);

            sphereMaterial.SetFloat("m4", targetM4);
            sphereMaterial.SetFloat("m5", targetM5);
            sphereMaterial.SetFloat("m6", targetM6);
            sphereMaterial.SetFloat("m7", targetM7);

            targetM0 = Random.Range(0, 6);
            targetM1 = Random.Range(1, 6);
            targetM2 = Random.Range(0, 6);
            targetM3 = Random.Range(1, 6);

            lastUpdate = Time.time;
        }

        sphereMaterial.SetFloat("m0", Mathf.Lerp(sphereMaterial.GetFloat("m0"), targetM0, Time.deltaTime / updateInterval));
        sphereMaterial.SetFloat("m1", Mathf.Lerp(sphereMaterial.GetFloat("m1"), targetM1, Time.deltaTime / updateInterval));
        sphereMaterial.SetFloat("m2", Mathf.Lerp(sphereMaterial.GetFloat("m2"), targetM2, Time.deltaTime / updateInterval));
        sphereMaterial.SetFloat("m3", Mathf.Lerp(sphereMaterial.GetFloat("m3"), targetM3, Time.deltaTime / updateInterval));
        //sphereMaterial.SetFloat("m4", Mathf.Lerp(sphereMaterial.GetFloat("m4"), targetM4, Time.deltaTime / updateInterval));
        //sphereMaterial.SetFloat("m5", Mathf.Lerp(sphereMaterial.GetFloat("m5"), targetM5, Time.deltaTime / updateInterval));
        //sphereMaterial.SetFloat("m6", Mathf.Lerp(sphereMaterial.GetFloat("m6"), targetM6, Time.deltaTime / updateInterval));
        //sphereMaterial.SetFloat("m7", Mathf.Lerp(sphereMaterial.GetFloat("m7"), targetM7, Time.deltaTime / updateInterval));


    }
}
