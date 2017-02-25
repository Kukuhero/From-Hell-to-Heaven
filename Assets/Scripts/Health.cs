using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health;
    public float maxhealth;
    private Vector3 screenPos;
    public Texture2D healthTexture;
    private int Position = 30;


	// Use this for initialization
	void Start () {
        maxhealth = health;
		
	}
	
	// Update is called once per frame
	void Update () {
        if( health <= 0)
        {
			health = 0;
			StartCoroutine (Destroy ());
        }
		
	}

	IEnumerator Destroy()
	{
		yield return new WaitForSeconds(10f);
		Destroy(gameObject);
	}

   
    Vector3 Vectorberechnung(Vector3 start, Vector3 ziel)
    {
        return new Vector3(ziel.x - start.x, ziel.y - start.y, ziel.z - start.z);
    }

    float Vectorlaenge(Vector3 Vector)
    {
        return Mathf.Sqrt(Vector.x * Vector.x + Vector.y * Vector.y + Vector.z * Vector.z);
    }
}
