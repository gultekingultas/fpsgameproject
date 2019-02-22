using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	private Transform target;
	public float speed=70f;
	public GameObject impactEffect;
    public float bulletdamage;
    
    // Update is called once per frame
    private void Awake()
    {
        bulletdamage = GameObject.FindGameObjectWithTag("turret").GetComponent<turret>().damage;
    }
    void Update () {
		if (target==null) {
			Destroy (gameObject);
			return;
		}
		Vector3 dir = target.position - transform.position;
		float distancethisframe = speed * Time.deltaTime;

		if (dir.magnitude <= distancethisframe) {
			hitTarget ();
			return;
		}
		transform.Translate (dir.normalized*distancethisframe,Space.World);
	}

	public void seek(Transform _target)
	{
		target = _target;
	}
	void hitTarget() // hitted something
	{
		GameObject effectIns=Instantiate (impactEffect, transform.position, transform.rotation) as GameObject;
		Destroy (effectIns,2f);
        target.gameObject.GetComponent<playerStats>().health -= bulletdamage;
		Destroy (gameObject);
	}
}
