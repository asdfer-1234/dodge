using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemyController : EnemyController
{
    private bool isRight;
    public float rotationSpeed;
    public float rotationDuration;
    private float rotationTimer;

    void Awake()
    {
        rotationTimer = rotationSpeed / 2;
    }
    void Start()
    {
        if (Random.Range(0, 2) == 0)
        {
            isRight = true;
        }
        else
        {
            isRight = false;
        }
    }

    
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        if (isRight)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -(rotationSpeed * Time.deltaTime));
        }
        rotationTimer += Time.deltaTime;
        if(rotationTimer > rotationDuration)
        {
            isRight = !isRight;
            rotationTimer -= rotationDuration;
        }
    }
}
