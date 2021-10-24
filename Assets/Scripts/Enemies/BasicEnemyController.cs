using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : EnemyController
{
    private void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
