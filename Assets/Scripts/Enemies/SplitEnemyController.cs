using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitEnemyController : InstantiateEnemyController
{
    public float splitAngle;
    public string splitRangeTag;
    private void Start()
    {
        instantiator.parent = GameObject.FindWithTag("Enemies").transform;
    }
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(splitRangeTag))
        {
            transform.Rotate(0, 0, -splitAngle);
            for (int i = 0; i < 3; i++)
            {
                instantiator.InstantiateEnemy(instantateEnemy, transform);
                transform.Rotate(0, 0, splitAngle);
            }
            Destroy(gameObject);
        }
    }
}
