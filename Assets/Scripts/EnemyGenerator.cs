using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyGenerator : EnemyInstantiation
{
    public PlayerController playerController;
    public Transform playerTransform;
    public Transform Enemies;
    public float movementQueueAccuracy;
    public float movementQueneLength;
    public GameUIManager scoreManager;

    [Header("Difficulty")]
    public float difficulty;
    public float enemyMultiplier;
    public float difficultyDuration;

    [Header("Enemy Generation")]
    public float spawnRange;
    public float lookAheadPlayer;

    [Header("Enemies")]
    public GameObject[] enemy;
    public int[] enemyChances;
    public float[] enemyAppearTime;
    public float[] enemyRotationRange;
    

    private float difficultyTimer = 0;
    private Vector2 averageMovement = Vector2.zero;
    private float movementQueueTimer = 0;
    
    private Queue<Vector2> movementQueue = new Queue<Vector2>();
    
    private void Update()
    {
        //Setting queue for enemy generation 
        movementQueueTimer += Time.deltaTime;
        if(movementQueueTimer >= movementQueueAccuracy)
        {
            movementQueue.Enqueue(playerController.movement);
            if (movementQueue.Count > movementQueneLength / movementQueueAccuracy)
            {
                movementQueue.Dequeue();
            }
            averageMovement = Vector2.zero;
            for (int i = 0; i < movementQueue.Count; i++)
            {
                averageMovement += movementQueue.ToArray()[i];
            }

            averageMovement *= movementQueueAccuracy;

        }

        

        while(Enemies.childCount <= difficulty * enemyMultiplier)
        {
            //Tweaking transform for enemy transform
            transform.position = playerTransform.position;

            if (averageMovement != Vector2.zero)
            {
                transform.right = new Vector3(averageMovement.x, averageMovement.y, 0) - transform.position;
                transform.Translate(lookAheadPlayer, 0, 0);
            }
            
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0f, 360f));
            
            
            transform.Translate(-spawnRange, 0, 0);
            
            //Randomizing enemy selection
            int chanceTotal = 0;
            int enemyCount = 0;
            for (int i = 0; i < enemy.Length; i++)
            {
                if(enemyAppearTime[i] < difficulty)
                {
                    enemyCount++;
                }
            }
            for (int i = 0; i < enemyCount; i++)
            {
                chanceTotal += enemyChances[i];
            }
            int random = Random.Range(0, chanceTotal);
            int currentTotal = 0;
            int instantiateEnemy = -1;
            for (int i = 0; i < enemyCount; i++)
            {
                currentTotal += enemyChances[i];
                if (random < currentTotal)
                {
                    instantiateEnemy = i;
                    break;
                }
            }
            InstantiateEnemyWithRotation(enemy[instantiateEnemy], transform, enemyRotationRange[instantiateEnemy]);
        }

        difficultyTimer += Time.deltaTime;
        if (difficultyTimer > difficultyDuration)
        {
            difficulty = (float) Math.Round((difficulty + 0.1f) * 10) / 10;
            difficultyTimer -= difficultyDuration;
            scoreManager.Score(1);
        }
        
        
    }
}
