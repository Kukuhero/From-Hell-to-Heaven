using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    public float speed;
    public Transform FireSpawnpoint;
    public GameObject Fireprojektil;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += Input.GetAxis("Mouse X") * 10;
        gameObject.transform.rotation = Quaternion.Euler(rotationVector);
        
       

       
            if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0)
            {
                
                transform.position += Vectornormieren(transform.forward) * Input.GetAxis("Vertical") * speed + 
                    Vectornormieren(Normalenvectorberechnung(transform.forward))* Input.GetAxis("Horizontal") * speed;

            }
            if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
            {
                
                transform.position += Vectornormieren(transform.forward) * Input.GetAxis("Vertical") * speed + 
                    Vectornormieren(Normalenvectorberechnung(transform.forward))* Input.GetAxis("Horizontal") * speed* 1/Mathf.Sqrt(2f);
            }

        if( Input.GetMouseButtonDown(0))
        {
            Instantiate(Fireprojektil, FireSpawnpoint.position, transform.rotation);
        }
        
	
	}

    Vector3 Vectorberechnung(Vector3 start, Vector3 ziel)
    {
        return new Vector3(ziel.x - start.x, ziel.y - start.y, ziel.z - start.z);
    }

    float Vectorlaenge(Vector3 Vector)
    {
        return  Mathf.Sqrt(Vector.x * Vector.x + Vector.y * Vector.y + Vector.z * Vector.z);
    }

    Vector3 Normalenvectorberechnung(Vector3 vector)
    {
        return vector = new Vector3(vector.z, 0f, -vector.x);
    }

    Vector3 Vectornormieren(Vector3 vector)
    {
        float Länge = Mathf.Sqrt (vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return (1 / Länge) * vector; 
    }
}
