using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameMaster : MonoBehaviour {

    GameObject scenecam;
    public Transform startlocation;
    public GameObject player;
	void Awake () {
        scenecam = GameObject.FindGameObjectWithTag("scenecam");

        
	}

     void Start()
    {
        Instantiate(player,startlocation.position,startlocation.rotation);
        scenecam.SetActive(false);
    }
    void Update () {
		
	}
}
