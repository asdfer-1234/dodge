using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AssaultEnemyController : InstantiateEnemyController
{
    private float instantiationTimer = 0;
    public float instantiationDuration;
    public float enemyRotationRange;
    public Transform target;

    private void Start()
    {
        instantiator.parent = GameObject.FindWithTag("Enemies").transform;
        target = GameObject.FindWithTag("Player").transform;
    }
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        instantiationTimer += Time.deltaTime;
        if (instantiationTimer >= instantiationDuration)
        {
            GameObject emptyGameObject = new GameObject();
            Transform instantiateEnemyTransform = emptyGameObject.transform;
            Destroy(emptyGameObject);
            instantiateEnemyTransform.position = transform.position;
            instantiateEnemyTransform.right = target.position - transform.position;
            instantiator.InstantiateEnemyWithRotation(instantateEnemy, instantiateEnemyTransform, enemyRotationRange);
            instantiationTimer -= instantiationDuration;
        }
    }
}
