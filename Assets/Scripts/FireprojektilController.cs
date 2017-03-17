using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireprojektilController : MonoBehaviour {
    Vector3 richVector;
    public float speed ;
    GameObject schongetroffen;
    float step;
	public float reichweite;
	public float light;
	public float fire;
	public float damage;
    // Use this for initialization
    void Start () {
		Invoke ("Destroy", reichweite);
        step = speed * Time.deltaTime;
		
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position += transform.forward * step;
        
		
	}
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "Wall":
                print("Fire hit Wall(Fireprojektil)");
                step = 0;
                
                break;

            case "Enemy":

                if (!other.isTrigger)
                {
                    //print("Enemy hit (shoot) " + other);
				if (other.gameObject != schongetroffen)
					other.GetComponent<EnemyStats>().health -= 5f;
                    schongetroffen = other.gameObject;
                }
                break;
        }
    }

   
    void Destroy()
    {
            
            Destroy(gameObject);
        
    }
    Vector3 Vectornormieren(Vector3 vector)
    {
        float Länge = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return (1 / Länge) * vector;
    }
}
