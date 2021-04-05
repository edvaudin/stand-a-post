using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    public void TakeDamage(float damage)
    {
        if (health - damage <= 0)
        {
            health = 0;
            Die();
            Debug.Log(gameObject + " has died.");
        }
        else
        {
            health -= damage;
            Debug.Log(gameObject + " has " + health + " health.");
        }
    }

    private void Die()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
