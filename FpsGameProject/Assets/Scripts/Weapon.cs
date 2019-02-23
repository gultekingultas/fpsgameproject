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
    public enum FireType
    {
        auto,
        semi
    };
    public Weapontype weapontype;
    public FireType firetype;
    public int pelletnumber;
    public float accuracy;
    public Transform firepoint;
    public Camera mycamera;
    public float range;
    public GameObject bullethole;
    public float fireRate;
    private float fireDelay;
    

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
        if (firetype == FireType.auto)
        {
            fireRate = 15f;
            fireDelay = 0f;
        }
        else if (firetype == FireType.semi)
        {
            fireRate = 1f;
            fireDelay = 0f;
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
                GameObject impactGo = Instantiate(bullethole, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 1f);

            }
        }
      
    }
	// Update is called once per frame
	void Update () {
        if (firetype == FireType.auto)
        {

            if (Input.GetButton("Fire1") && Time.time >= fireDelay)
            {
                fireDelay = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        else if (firetype == FireType.semi)
        {

            if (Input.GetButtonDown("Fire1") && Time.time >= fireDelay)
            {
                fireDelay = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        
       
	}
}
