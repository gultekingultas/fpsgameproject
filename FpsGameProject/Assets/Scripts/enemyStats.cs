using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : MonoBehaviour {

    public float health;
	void Start () {
        health = 100;
	}

    public void getDamage(float damage)
    {
        health -= damage;
    }

	// Update is called once per frame
	void Update () {
        if (health<= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
