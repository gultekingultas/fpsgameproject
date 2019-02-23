using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSystem : MonoBehaviour {

    public GameObject[] weapons; // 1-Shotgun  2-Laser  3-Launcher
    
	void Start () {
        
	}
	
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == 0)
                {
                    weapons[i].SetActive(true);
                }
                else
                {
                    weapons[i].SetActive(false);
                }
               
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == 1)
                {
                    weapons[i].SetActive(true);
                }
                else
                {
                    weapons[i].SetActive(false);
                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == 2)
                {
                    weapons[i].SetActive(true);
                }
                else
                {
                    weapons[i].SetActive(false);
                }
            }

        }
    }
}
