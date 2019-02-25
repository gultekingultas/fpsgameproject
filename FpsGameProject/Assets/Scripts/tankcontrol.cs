using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tankcontrol : MonoBehaviour {

    public GameObject target;
    NavMeshAgent agent;
    public static bool startfollow = false;
	void Start () {
        agent = GetComponent<NavMeshAgent>();
       
        
       // target = GameObject.FindGameObjectWithTag("player");
            
    }
	
	// Update is called once per frame
	void Update () {


        if (startfollow)
        {
            Debug.Log(target.transform.position);

            agent.destination = target.transform.position;
        }

    }
}
