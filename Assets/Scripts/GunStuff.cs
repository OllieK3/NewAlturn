using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStuff : MonoBehaviour
{
    public float Damage = 20f;
    public float Range = 150f;
    public Camera FpsCam;
    public float FireRate = 10f;
    public float NextTimeToFire= 0;

    public GameObject hitEffect;


    public void Update()
    {
        if (Input.GetButtonDown("Fire1")&& Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FpsCam.transform.position , FpsCam.transform.forward , out hit))
            {
            EnemyDamage enemy = hit.transform.GetComponent<EnemyDamage>();
            Debug.Log(hit.transform.name);

            GameObject hitGo = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(hitGo, 0.5f);
            if(enemy != null)
            {
                enemy.TakeDamage(Damage);
            }
        }
    }
}

