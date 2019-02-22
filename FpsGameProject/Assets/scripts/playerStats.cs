using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour {

    public float health = 100f;
    GameObject healthtext;
	void Start () {
        healthtext = GameObject.FindGameObjectWithTag("healthtext");
	}
	
	
	void Update () {
        healthtext.GetComponent<Text>().text = "Health:"+health;
        if (health<=0)
        {
            health = 0;
            Debug.Log("Died");
        }
	}
}
