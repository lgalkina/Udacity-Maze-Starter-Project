using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
    // Create a boolean value called "locked" that can be checked in OnDoorClicked() 
    // Create a boolean value called "opening" that can be checked in Update() 
    public bool locked = true;
    public bool opening = false;
    float startTime = 0f;
    public AudioClip doorLockedSound;
    public AudioClip doorUnlockSound;

    // for door opening animation
    Quaternion startRotation;
    Quaternion stopRotation;

    private void Start()
    {
        startRotation = Quaternion.Euler(0f, 0f, 0f);
        stopRotation = startRotation * Quaternion.Euler(0f, 90f, 0f);
    }

    void Update() {
        // If the door is opening and it is not fully raised
        // Animate the door raising up
        if (opening)
        {
            transform.rotation = Quaternion.Slerp(startRotation, stopRotation, startTime / 0.5f);
            startTime += Time.deltaTime;
        }
    }

    public void OnDoorClicked() {
        // If the door is clicked and unlocked
        // Set the "opening" boolean to true
        // (optionally) Else
        // Play a sound to indicate the door is locked
        AudioSource audio = GetComponent<AudioSource>();
        if (Key.isKeyCollected)
        {
            opening = true;
            locked = false;
            audio.PlayOneShot(doorUnlockSound);
        }
        else
        {
            audio.PlayOneShot(doorLockedSound);
        }
    }

    public void Unlock()
    {
        // You'll need to set "locked" to false here
        locked = false;
    }
}
