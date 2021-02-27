using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    [SerializeField]
    AudioClip pickupMagazineSFX;
    [SerializeField]
    ThirdPersonMovement player;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Picked");
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(pickupMagazineSFX);
        player.amountMagazines++;

        Destroy(gameObject);
    }
}
