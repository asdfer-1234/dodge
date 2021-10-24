using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public PlayerController player;
    [Header("Health")]
    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = value; 
            UpdateHealthUI();
        }
    }

    private int MaxHealth
    {
        get => healthBar.MaxAmount;
    }
    private float healthRegen;
    public float healthRegenCooldown;
    public SegmentBar healthBar;
    [Header("Stamina")]
    private int stamina;
    public int Stamina
    {
        get => stamina;
        set
        {
            stamina = value;
            UpdateStaminaUI();
        }
    }
    private int MaxStamina
    {
        get => staminaBar.MaxAmount;
    }
    private float staminaRegen;
    public float staminaRegenCooldown;
    public SegmentBar staminaBar;

    public int startHealth;
    public int startStamina;

    private void Awake()
    {
        Health = startHealth;
        Stamina = startStamina;
    }

    public GameUIManager gameover;

    
    private void Update()
    {
        if (Health < MaxHealth)
        {
            healthRegen += Time.deltaTime;
            if (healthRegen > healthRegenCooldown)
            {
                healthRegen -= healthRegenCooldown;
                Health++;
            }
        }

        if (Stamina < MaxStamina)
        {
            staminaRegen += Time.deltaTime;
            if (staminaRegen > staminaRegenCooldown)
            {
                staminaRegen -= staminaRegenCooldown;
                Stamina++;
            }
        }

        UpdateStatUI();
        //Debug.Log(Health);
        //Debug.Log(healthRegen);
    }

    private void UpdateStatUI()
    {
        UpdateHealthUI();
        UpdateStaminaUI();
    }
    private void UpdateHealthUI()
    {
        healthBar.Amount = health;
        healthBar.Extra = healthRegen / healthRegenCooldown;
    }

    private void UpdateStaminaUI()
    {
        staminaBar.Amount = stamina;
        staminaBar.Extra = staminaRegen / staminaRegenCooldown;
    }

    public void Damage()
    {
        Health--;
        if (Health <= 0)
        {
            player.Death();
            gameover.Gameover();
        }
    }

    public void Dash()
    {
        Stamina--;
    }
}
