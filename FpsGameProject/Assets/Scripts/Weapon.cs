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
    GameObject player;

    public Weapontype weapontype;
    public FireType firetype;
    public int pelletnumber;
    public float accuracy;
    public float damage;
    public Transform firepoint;
    public Camera mycamera;
    public Transform launcherfp;
    public float range;
    public GameObject bullethole;
    public GameObject laserimpact;
    private GameObject hiteffect;
    public float fireRate;
    private float fireDelay;
    public bool isReloading =false;
    public bool canfire = true;

    // shotgun
    public static int currentAmmo;
    public int maxAmmo;
    public float reloadTime;
    public static int  clipsize;
  
    //
    // Laser
    public static float currentlaser;
    public float maxlaser;
    public float reloadlaserpersecond;
    public float timeforcharge;

    //
    //Launcher
    public GameObject bomb;
    public static int currentBomb;
    public int maxBomb;
    public float reloadlaunchertime;
    public static int clipsizelauncher;
    public float throwforce;
    

    //
    // Use this for initialization
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("player");
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    void Start () {
        if (weapontype == Weapontype.laser)
        {
            
            Debug.Log("laser");
            accuracy = 100f;
            firepoint = mycamera.transform;
            range = Mathf.Infinity;
            pelletnumber = 1;
            hiteffect = laserimpact;
            maxlaser = 10f;
            currentlaser = maxlaser;
            reloadlaserpersecond = .5f;
            timeforcharge = 4f;
            damage = 5f;
          
        }
        else if (weapontype == Weapontype.shotgun)
        {
            Debug.Log("shotgun");
            accuracy = 20;
            firepoint = mycamera.transform;
            range = Mathf.Infinity;
            pelletnumber = 21;
            hiteffect = bullethole;
            maxAmmo = 6;
            currentAmmo = maxAmmo;
            clipsize = 12;
            reloadTime = 2f;
            damage = 5f;
          
          
        }

        else if (weapontype == Weapontype.launcher)
        {
            Debug.Log("Launcher");
            firepoint = launcherfp;
            maxBomb = 3;
            currentBomb = maxBomb;
            clipsizelauncher = 3;
            reloadlaunchertime = 2f;
            throwforce = 12f;
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

    void ThrowBomb()
    {
        GameObject bombGO = Instantiate(bomb,firepoint.position, firepoint.rotation);
        Rigidbody rb = bombGO.GetComponent<Rigidbody>();
        rb.AddForce(firepoint.forward*throwforce,ForceMode.VelocityChange);
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
                GameObject impactGo = Instantiate(hiteffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 1f);
                if (hit.collider.tag == "enemy")
                {
                    hit.collider.gameObject.GetComponent<enemyStats>().getDamage(damage);
                }

            }
        }
      
    }
    void ReloadLaser()
    {
       currentlaser += Time.deltaTime*reloadlaserpersecond;
    }
    IEnumerator Reload()
    {
        isReloading = true;
        canfire = false;
        yield return new WaitForSeconds(reloadTime);
        if (clipsize < maxAmmo)
        {
            currentAmmo = clipsize;
            clipsize = 0;
        }
        else
        {
            clipsize = clipsize - (maxAmmo - currentAmmo);
   
     
     
            currentAmmo = maxAmmo;
        }
       
        isReloading = false;
        canfire = true;
    }
    private void FixedUpdate()
    {
        if (canfire)
        {
            if (firetype == FireType.auto)
            {
             
                if (Input.GetButton("Fire1") && Time.time >= fireDelay)
                {
                    fireDelay = Time.time + 1f / fireRate;
                    Shoot();
                    if (weapontype == Weapontype.laser)
                    {
                        currentlaser--;
                    }
           

                }
            }
            else if (firetype == FireType.semi)
            {

                if (Input.GetButtonDown("Fire1") && Time.time >= fireDelay)
                {
                    fireDelay = Time.time + 1f / fireRate;
                    
                    if (weapontype == Weapontype.shotgun)
                    {
                        Shoot();
                        currentAmmo--;
                    }
                    else if (weapontype == Weapontype.launcher )
                    {
                        ThrowBomb();
                        currentBomb--;

                    }

                }
            }
        }
    }

    // Update is called once per frame
    void Update () {

        // SHOTGUN
        if (weapontype == Weapontype.shotgun)
        {
            player.GetComponent<playerStats>().Shotgun();
            if (isReloading)
            {
                return;
            }

            if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
            {
                if (clipsize > 0)
                {
                    StartCoroutine(Reload());
                    return;
                }
                else
                {
                    if (currentAmmo > 0)
                    {
                        return;
                    }
                    else
                    {
                        canfire = false;
                    }
                  
                }

            }
            if (clipsize < 0)
            {
                clipsize = 0;
            }
        }


        //
        // LASER
        if (weapontype == Weapontype.laser)
        {
            player.GetComponent<playerStats>().Laser();
            if (currentlaser < maxlaser)
            {
                ReloadLaser();
            }
            if (currentlaser <= 0)
            {
                currentlaser = 0;
                canfire = false;
            }
            if (currentlaser > 2f)
            {
                canfire = true;
            }
            if (currentlaser >= maxlaser)
            {
                currentlaser = maxlaser;
            }
        }

        //
        if (weapontype == Weapontype.launcher)
        {
            player.GetComponent<playerStats>().Launcher();
            if (currentBomb <= 0)
            {
                
                canfire = false;
            }
            if (currentBomb > 0)
            {
                canfire = true;
            }
        }

    }
}
