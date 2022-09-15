using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float currentHelth;

    private void Start()
    {
        currentHelth = maxHealth;
    }

    public void DamagePlayer(float damage)
    {
        currentHelth -= damage;
        if (currentHelth <= 0f)
        {
            GetComponent<GameOverHandler>().HandleDeath();

        }
    }
}
