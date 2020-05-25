using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class raycastShoot : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 3f)]
    private float fireRamge = 1f;

    [SerializeField]
    [Range(1f, 10f)]
    private int damage = 1;

  

    [SerializeField]

    private Transform face;


    [SerializeField]
    private ParticleSystem muzzleParticle;

    [SerializeField]
    private AudioSource gunSound;


    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>= fireRamge)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireRun();

            }
        }
       
    }

    private void FireRun()
    {
        Debug.DrawRay(face.position, face.forward * 100, Color.red, 1f);

        muzzleParticle.Play();
        gunSound.Play();
        Ray ray = new Ray(face.position, face.forward);
        RaycastHit hitinfo;
        
        if(Physics.Raycast(ray, out hitinfo, 100))
        {
            var health =hitinfo.collider.GetComponent<Health>();

            if(health != null)
            {
                health.TakeDamage(damage);

            }

        } 
    }

   
}
