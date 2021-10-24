using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class BackgroundRepeater : MonoBehaviour
{
    public Transform cameraTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2((float)Round(cameraTransform.position.x / 2) * 2, (float)Round(cameraTransform.position.y / 2) * 2);
    }
}
