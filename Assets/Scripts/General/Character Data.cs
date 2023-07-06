using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [Header("Basic Data")]
    public float maxHealth;
    public float currentHealth;


    [Header("Invincible Data")]
    public float inVincinbleDuration;
    private float inVincinbleCounter;
    private bool Invincible;
    private void Start()
    {
        currentHealth = maxHealth;

    }
    private void Update()
    {
        if (Invincible)
        {
            inVincinbleCounter -= Time.deltaTime;
        }
        if (inVincinbleCounter <= 0)
        {
            Invincible = false;
        }
    }

    public void TakeDamage(Attack attacker)
    {
        if (Invincible)
            return;
        if (currentHealth - attacker.Damage > 0)
        {
            currentHealth = currentHealth - attacker.Damage;
            inVincinble();
        }
        else { currentHealth = 0; }
    }

    public void inVincinble()
    {
        Invincible = true;
        inVincinbleCounter = inVincinbleDuration;
    }
}
