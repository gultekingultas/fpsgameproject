using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerStats : MonoBehaviour {

    public float health = 100f;
    GameObject healthtext;
    GameObject ammotext;
    GameObject weapontext;
     bool shotgun = false;
     bool laser = false;
     bool launcher = false;
     void Start () {
        healthtext = GameObject.FindGameObjectWithTag("healthtext");
        ammotext = GameObject.FindGameObjectWithTag("ammotext");
        weapontext = GameObject.FindGameObjectWithTag("weapontext");
    }

   public  void Shotgun()
    {
        shotgun = true;
        laser = false;
        launcher = false;
        weapontext.GetComponent<Text>().text = "Weapon:Shotgun";
    }
    public void Laser()
    {
        shotgun = false;
        laser = true;
        launcher = false;
        weapontext.GetComponent<Text>().text = "Weapon:Laser";
    }
    public void Launcher()
    {
        shotgun = false;
        laser = false;
        launcher = true;
        weapontext.GetComponent<Text>().text = "Weapon:Launcher";
    }
	void Update () {
        healthtext.GetComponent<Text>().text = "Health:"+health;
        if (health<=0)
        {
            health = 0;
            Debug.Log("Died");
        }
        if (shotgun)
        {
            ammotext.GetComponent<Text>().text = "Ammo:"+Weapon.currentAmmo+" / "+ Weapon.clipsize;
        }
        if (laser)
        {
            ammotext.GetComponent<Text>().text = "Ammo:"+ Weapon.currentlaser;
        }
	}
}
