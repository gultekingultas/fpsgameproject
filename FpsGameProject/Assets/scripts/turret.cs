using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {

	[Header("Attributes")] // editörde public olanlarda başlık koyat editöre bak
	public float fireRate=1f; // saniyede kac mermi
	private float fireCountDown=0f; // bekleme süresini ayarlama
	public float range=5f;
   
    public float health = 100f;
	[Header("Unity Setup Fields")]
	private Transform target;
	public string enemytag = "player";
	public Transform PartToRotate;
	public float rotationspeed=10f;
	public GameObject bulletPrefab;
	public Transform FirePoint;
	void Start () {
		InvokeRepeating ("UpdateTarget",0f,0.5f);
	}
	

	void Update () {

		if (target==null) {
			return;
		}
		Vector3 dir  = target.position-transform.position;
		Quaternion look = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(PartToRotate.rotation,look,rotationspeed*Time.deltaTime).eulerAngles;
		PartToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if (fireCountDown<=0f) {
			Shoot ();
			fireCountDown = 1f / fireRate; // saniyede 2 mermi olsaydı 1/2 =0.5 bekleme süresi 
		}
		fireCountDown -= Time.deltaTime;
	}
	void UpdateTarget()
	{
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		GameObject[] enemies = GameObject.FindGameObjectsWithTag (enemytag);
		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (transform.position,enemy.transform.position);
			if (distanceToEnemy<shortestDistance) {
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}
		if (nearestEnemy != null && shortestDistance <= range) 
		{
			target = nearestEnemy.transform;
		} else 
		{
			target = null;
		}
	}
	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position,range);
	}

	void Shoot()
	{
		GameObject bulletGO=Instantiate (bulletPrefab, FirePoint.position, FirePoint.rotation) as GameObject;
		bullet bullet = bulletGO.GetComponent<bullet> ();
		if (bullet!=null) {
			bullet.seek (target);
		}
	}
}
