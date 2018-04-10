using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    //Create a reference to the KeyPoofPrefab and Door
    public GameObject keyPoofPrefab;

    public static bool isKeyCollected = false;

    void Update()
	{
		//Not required, but for fun why not try adding a Key Floating Animation here :)
	}

	public void OnKeyClicked()
	{
        // Instatiate the KeyPoof Prefab where this key is located
        // Make sure the poof animates vertically
        // Call the Unlock() method on the Door
        // Set the Key Collected Variable to true
        // Destroy the key. Check the Unity documentation on how to use Destroy
        Door door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
        door.Unlock();
        Object.Instantiate(keyPoofPrefab, transform.position, Quaternion.identity);
        Object.Destroy(this.gameObject);
        isKeyCollected = true;
    }
}
