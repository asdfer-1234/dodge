using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingEnemyController : EnemyController
{
    Transform target;
    public float homingDuration;
    private bool isHoming = true;
    private float timer = 0;

    private void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (isHoming)
        {
            transform.right = target.position - transform.position;
        }
        transform.Translate(speed * Time.deltaTime, 0, 0);
        timer += Time.deltaTime;
        if(isHoming && timer > homingDuration)
        {
            isHoming = false;
        }
    }
}