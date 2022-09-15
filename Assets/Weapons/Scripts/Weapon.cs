using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;


public class Weapon : MonoBehaviour
{
    [SerializeField] float range = 100f;
    [SerializeField] float weaponDamage = 10f;
    [SerializeField] float timeBetweenShots = 0.2f;
    [SerializeField] GameObject hitVFX;
    [SerializeField] float hitVFXdestroyTime = 2f;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    StarterAssetsInputs playerInput;
    ParticleSystem muzzleFlash;
    Camera playerCamera;
    bool canShoot =  true;

    private void Awake()
    {
        playerInput = FindObjectOfType<StarterAssetsInputs>();
    }

    private void OnEnable()
    {
        canShoot = true;
    }

    private void Start()
    {
        playerCamera = FindObjectOfType<Camera>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        if (playerInput.fire && canShoot)
            StartCoroutine(Fire());
    }

    IEnumerator Fire()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        playerInput.fire = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        if (!muzzleFlash.isPlaying)
        {
            muzzleFlash.Play();
        }
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, range))
        {
            CreateHitEffect(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }    
    }

    private void CreateHitEffect(RaycastHit hit)
    {
        GameObject newHitEffect = Instantiate(hitVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(newHitEffect, hitVFXdestroyTime);
    }
}
