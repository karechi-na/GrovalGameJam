using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLimit : MonoBehaviour
{
    public float rotationSpeed = 5f;
    public float noiseIntensity = 2f;
    private float timeOffsetX;
    private float timeOffsetY;
    private float timeOffsetZ;

    // Start is called before the first frame update
    void Start()
    {
        timeOffsetX = Random.Range(0f, 100f);
        timeOffsetY = Random.Range(0f, 100f);
        timeOffsetZ = Random.Range(0f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        float noiseX = Mathf.PerlinNoise(timeOffsetX, Time.time * 0.1f) * 2f - 1f;
        float noiseY = Mathf.PerlinNoise(timeOffsetY, Time.time * 0.1f) * 2f - 1f;
        float noiseZ = Mathf.PerlinNoise(timeOffsetZ, Time.time * 0.1f) * 2f - 1f;

        Vector3 rotationAngles = new Vector3(
            noiseX * noiseIntensity,
            noiseY * noiseIntensity,
            noiseZ * noiseIntensity
        );

        transform.Rotate(rotationAngles * rotationSpeed * Time.deltaTime, Space.Self);

    }
}
