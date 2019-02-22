using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour {

    public float health = 100f;
	void Start () {
		
	}
	
	
	void Update () {
        if (health<=0)
        {
            Debug.Log("Died");
        }
	}
}
