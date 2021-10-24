using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float dashDistance;
    public GameObject rotationTarget;
    public GameUIManager gameUiManager;
    public PlayerStats stat;
    [HideInInspector] public Vector2 movement;
    [HideInInspector] public bool isDying;

    private ParticleSystem particle;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        movement = Vector2.zero;
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.R)) && !isDying)
        {
            if (Input.GetKey(KeyCode.S))
            {
                movement.x += 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                movement.x -= 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                movement.y += 1;
            }

            if (Input.GetKey(KeyCode.R))
            {
                movement.y -= 1;
            }
            if (Input.GetKeyDown(KeyCode.Mouse1) && stat.Stamina >= 1)
            {
                Ability();
            }
        }
        Debug.Log(movement.x + " " + movement.y);
        rotationTarget.GetComponent<PlayerRotationTargetController>().UpdateRotation();
        
        if (movement != Vector2.zero)
        {
            transform.right = rotationTarget.transform.position - transform.position;
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        

        if (isDying && !particle.IsAlive())
        {
            gameObject.SetActive(false);
            gameUiManager.Gameover();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")){
            Destroy(other.gameObject);
            particle.Play();
            stat.Damage();
        }
    }

    private void Ability()
    {
        transform.Translate(dashDistance, 0, 0);
        stat.Dash();
    }
    
    public void Death()
    {
        if (!isDying)
        {
            isDying = true;
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
