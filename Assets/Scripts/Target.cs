using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public float health = 50f;

    public bool isBoss = false;
    // Start is called before the first frame update
    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isBoss)
        {
            GameObject.Find("LoadNextLevel").GetComponent<LoadNextLevel>().bossDead = true;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.LogWarning("die");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

}
