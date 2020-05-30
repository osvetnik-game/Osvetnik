using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    private void OnTriggerEnter(Collider other)
    {
        Target target = other.transform.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(damage);
            Debug.Log(other.name + " : " + target.health);
        }
    }
}
