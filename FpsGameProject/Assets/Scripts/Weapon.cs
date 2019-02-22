using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public enum Weapontype
    {
        laser,
        shotgun,
        launcher
    };
    public Weapontype weapontype;
    // Use this for initialization
    void Start () {
        if (weapontype == Weapontype.laser)
        {
            Debug.Log("laser");
        }
        else if (weapontype == Weapontype.shotgun)
        {
            Debug.Log("shotgun");
        }
        else if (weapontype == Weapontype.launcher)
        {
            Debug.Log("Launcher");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
