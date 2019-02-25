using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombmech : MonoBehaviour {

    public GameObject explosioneffect;
    bool explode = false;
    public float radius = 5f;
    public float force= 700f;
    public float damage = 5;
	void Start () {
		
	}

	void Update () {
		
	}
    private void OnCollisionEnter(Collision col)
    {
        
        if (col != null)
        {
           Collider[] colliders= Physics.OverlapSphere(transform.position,radius);
            foreach (Collider closeobject in colliders)
            {
                //force
                Rigidbody rb = closeobject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(force,transform.position,radius);
                }
                if (closeobject.gameObject.tag == "enemy")
                {
                    float dis = Vector3.Distance(transform.position ,  closeobject.transform.position);
                    closeobject.gameObject.GetComponent<enemyStats>().getDamage(damage*(1/dis));
                }
            
            }
            GameObject exp = Instantiate(explosioneffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
            Destroy(exp, 2f);
            
        }
    }
   
}
