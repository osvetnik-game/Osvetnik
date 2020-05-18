using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public GameObject muzzleFlash;
    public Transform muzzleFlashPosition;
    public Transform impact;

    public AudioClip shootSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        GameObject muzzleFlashObject =  Instantiate(muzzleFlash, muzzleFlashPosition.position, muzzleFlashPosition.rotation);
        muzzleFlashObject.transform.SetParent(gameObject.transform);

        audioSource.PlayOneShot(shootSound);

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            Transform impactObject = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject.gameObject, 2f);
        }
    }
}
