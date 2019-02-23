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
    public int pelletnumber;
    public float accuracy;
    public Transform firepoint;
    public Camera mycamera;
    public float range;
   // public GameObject bullethole;
    

    // Use this for initialization
    void Start () {
        if (weapontype == Weapontype.laser)
        {
            Debug.Log("laser");
            accuracy = 100f;
            firepoint = mycamera.transform;
            range = Mathf.Infinity;
            pelletnumber = 1;
        }
        else if (weapontype == Weapontype.shotgun)
        {
            Debug.Log("shotgun");
            accuracy = 20;
            firepoint = mycamera.transform;
            range = Mathf.Infinity;
            pelletnumber = 21;
        }
        else if (weapontype == Weapontype.launcher)
        {
            Debug.Log("Launcher");
        }
	}


    void Shoot()
    {
        for (int i = 0; i < pelletnumber; i++)
        {
            RaycastHit hit;
            Vector3 direction = firepoint.forward;
            float accuracyVary = (100 - accuracy) / 1000;
            direction.x += Random.Range(-accuracyVary, accuracyVary);
            direction.y += Random.Range(-accuracyVary, accuracyVary);
            direction.z += Random.Range(-accuracyVary, accuracyVary);
            if (Physics.Raycast(firepoint.position, direction, out hit, range))
            {
                Debug.Log(hit.transform.name);
             //   GameObject impactGo = Instantiate(bullethole, hit.point, Quaternion.LookRotation(hit.normal));
               // Destroy(impactGo, 1f);

            }
        }
      
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}
}
