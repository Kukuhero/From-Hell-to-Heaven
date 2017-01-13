using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    public float speed; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += Input.GetAxis("Mouse X") * 10;
        gameObject.transform.rotation = Quaternion.Euler(rotationVector);
        
        /*
        Vector3 position = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 direction = Input.mousePosition - position;
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);*/

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 80f))
        {
            if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0)
            {
                Vector3 richVector = Vectorberechnung(transform.position, new Vector3(hit.point.x,transform.position.y,hit.point.z));
                transform.position += Vectornormieren(richVector) * Input.GetAxis("Vertical") * speed + 
                    Vectornormieren(Normalenvectorberechnung(richVector))* Input.GetAxis("Horizontal") * speed;

            }
            if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
            {
                Vector3 richVector = Vectorberechnung(transform.position, hit.point);
                transform.position += Vectornormieren(richVector) * Input.GetAxis("Vertical") * speed + 
                    Vectornormieren(Normalenvectorberechnung(richVector))* Input.GetAxis("Horizontal") * speed* 1/Mathf.Sqrt(2f);
            }
			transform.FindChild ("AimCircle").position = hit.point;
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
