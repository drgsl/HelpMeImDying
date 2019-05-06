using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    public int maxAmmo = 10;
    public float reloadTime = 1f; 

    private int currentAmmo;
    private bool isreloading = false;

    public Camera fpscam;
    public ParticleSystem muzzleFlash;
    public GameObject ImpactEffect;

    private float nextTimeToFire = 0f;

    //public Animator animator; 


	// Use this for initialization
	void Start ()
    {
        currentAmmo = maxAmmo; 
	}

    private void OnEnable()
    {
        isreloading = false;
        //animator.SetBool("Reloading", false); 
    }

    // Update is called once per frame
    void Update () {
        if (isreloading)
        {
            return; 
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot(); 
        }
	}

    IEnumerator reload()
    {
        isreloading = true;
        Debug.Log("Reloading...");

        //animator.SetBool("Reloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);

        //animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isreloading = false; 
    }


    void Shoot()
    {
        muzzleFlash.Play();
        currentAmmo--;
        RaycastHit hit; 
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); 
            }

            GameObject impactGo = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            impactGo.transform.parent = hit.transform;
            Destroy(impactGo, 2f);
        }
    }

}
