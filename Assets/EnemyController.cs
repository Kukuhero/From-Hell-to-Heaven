using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    bool walk = false;
    Vector3 Richtungsvector;
    public float speed; 

	// Use this for initialization
	void Start () {
        StartCoroutine(Walk());
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (walk)
        {
            float angle = Mathf.Atan2(Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            transform.position += Richtungsvector * speed;
        }
    }
    void OnTriggerEnter (Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                
                break;
            case "Player":
                break;
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

        }
	}
    Vector3 Vectornormieren(Vector3 vector)
    {
        float Länge = Mathf.Sqrt (vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return (1 / Länge) * vector; 
    }
}
