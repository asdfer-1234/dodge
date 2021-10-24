using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstantiation : MonoBehaviour
{
    public Transform parent;
    public GameObject InstantiateEnemy(GameObject original, Transform enemyTransform)
    {
        return Instantiate(original, enemyTransform.position, enemyTransform.rotation, parent);
    }

    public void InstantiateEnemyWithRotation(GameObject original, Transform enemyTransform, float rotationRange)
    {
        GameObject rotate = InstantiateEnemy(original, enemyTransform);
        rotate.transform.Rotate(0, 0, Random.Range(-rotationRange, rotationRange));
    }
}
