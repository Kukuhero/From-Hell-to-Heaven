using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    bool walk = false;
    Vector3 Richtungsvector;
    public float speed;
    public Transform Spawnpoint;
    public GameObject Fire;
    float orspeed;
    int i = 0;
    bool shoot = false;
    GameObject target;

	// Use this for initialization
	void Start () {
        orspeed = speed;
        StartCoroutine(Walk());
	}
	
	// Update is called once per frame
	void Update () 
    {
        print("walk " + walk + "anzahl an triggerenter des players(Enemy) : " + i );
        if (walk)
        {
            float angle = Mathf.Atan2(Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            transform.position += Richtungsvector * speed;
        }

        if(shoot)
        {
            Richtungsvector = Vectorberechnung(transform.position, target.transform.position);
        }
    }
    void OnTriggerEnter (Collider other)
    {
       
        switch (other.transform.tag)
        {
            case "Wall":
                print("WallinTrigger(Enemy)");
                RaycastHit hit;
                if (Physics.Raycast(transform.position, Richtungsvector, out hit, 10f))
                {
                    print("Wall in my way (Enemy)");
                    Richtungsvector = Normalenvectorberechnung(Richtungsvector);
                    if (Physics.Raycast(transform.position, Richtungsvector, out hit, 10f))
                    {
                        Richtungsvector = -Richtungsvector;
                    }
                }
                    break;
            case "Player":
                shoot = true;
                speed = 0;
                StopCoroutine(Walk());
                target = other.transform.gameObject;
                Richtungsvector = Normalenvectorberechnung(Vectorberechnung(transform.position, target.transform.position));
                float angle = Mathf.Atan2(Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                transform.position += Richtungsvector * speed;
                
                StartCoroutine(Shoot());
                break;
        }
    }

    
    
    private void OnTriggerExit(Collider other)
    {if (other.tag == "Player")
        {
            speed = orspeed;
            shoot = false;
            StopCoroutine(Shoot());
            StartCoroutine(Walk());
        }
    }

    IEnumerator Shoot()
    {
        i++;
        while(true)
        {
            if (!shoot && i <= 1)
            {
                i--;
                break;
            }

            yield return new WaitForSeconds(0.1f);
            Instantiate(Fire, Spawnpoint.position, transform.rotation);
            yield return new WaitForSeconds(2f);

            
        }
    }

    IEnumerator Walk()
    {
        while (true)
        {
            Richtungsvector= Vectornormieren(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)));
            walk = true;
            float Richtungswechsel = Random.Range(1f, 4f);
            yield return new WaitForSeconds(Richtungswechsel);
            if(shoot)
            {
                break;
            }

        }
	}
    Vector3 Vectornormieren(Vector3 vector)
    {
        float Länge = Mathf.Sqrt (vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return (1 / Länge) * vector; 
    }
    Vector3 Normalenvectorberechnung(Vector3 vector)
    {
        return vector = new Vector3(vector.z, 0f, -vector.x);
    }
    Vector3 Vectorberechnung(Vector3 start, Vector3 ziel)
    {
        return new Vector3(ziel.x - start.x, ziel.y - start.y, ziel.z - start.z);
    }
}
