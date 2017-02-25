using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireprojektilController : MonoBehaviour {
    Vector3 richVector;
    public float speed ;
    GameObject schongetroffen;
    float step;
    // Use this for initialization
    void Start () {
        step = speed * Time.deltaTime;
        StartCoroutine(Destroy());
		
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
                        other.GetComponent<Health>().health -= 5f;
                    schongetroffen = other.gameObject;
                }
                break;
        }
    }

   
    IEnumerator Destroy()
    {
        while(true)
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }
    Vector3 Vectornormieren(Vector3 vector)
    {
        float Länge = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return (1 / Länge) * vector;
    }
}
