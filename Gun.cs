using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float range;
    [SerializeField]
    protected GameObject bulletSource;
    [SerializeField]
    protected float fireRate = 15f;
    [SerializeField]
    protected int currentAmmo = 30;

    [SerializeField]
    ThirdPersonMovement player;

    [SerializeField]
    ParticleSystem muzzleFlash;
    [SerializeField]
    GameObject[] bulletHolePrefabs;

    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip shootSFX;
    [SerializeField]
    AudioClip reloadSFX;

    private float nextTimeToFire = 0f;
    private int baseCpacity = 30;
    [SerializeField]
    private bool isReloading = false;

    private void InnerShot() 
    {
        currentAmmo--;
        audioSource.PlayOneShot(shootSFX);
        // Setting up fire rate
        nextTimeToFire = Time.time + 1f / fireRate;

        // Debug line and vfx
        Debug.DrawLine(bulletSource.transform.position, -bulletSource.transform.forward, Color.green, range);
        muzzleFlash.Play();

        // Shooting a ray for earning information about object that we shooting to
        RaycastHit hit;
        if (Physics.Raycast(bulletSource.transform.position, -bulletSource.transform.forward, out hit, range))
        {
            // Saving a pbject type of pawn that we hit
            Pawn pawn = hit.transform.GetComponent<Pawn>();

            // if exists - deal damage
            if (pawn != null)
            {
                pawn.TakeDamage(damage);
            }

            // Leaving buuletholes on pawn
            GameObject holeInstance = Instantiate(bulletHolePrefabs[Random.Range(0, bulletHolePrefabs.Length - 1)], hit.point + hit.normal * 0.0001f, Quaternion.LookRotation(hit.normal));
            Destroy(holeInstance, 2f);
        }
    }

    protected virtual IEnumerator Reload(float time) 
    {
        isReloading = true;

        audioSource.PlayOneShot(reloadSFX);

        yield return new WaitForSeconds(time);

        if (isReloading)
        {
            player.amountMagazines--;
        }

        Debug.Log("Reloaded!");
        currentAmmo = baseCpacity;
        isReloading = false;
    }

    protected virtual void Shoot() 
    {
        if (isReloading)
            return;

        if (currentAmmo > 0)
        {
            if (Time.time >= nextTimeToFire)
            {
                InnerShot();
            }
        }
        else
        {
            if(player.amountMagazines > 0)
                StartCoroutine(Reload(reloadSFX.length));
        }
    }
}
