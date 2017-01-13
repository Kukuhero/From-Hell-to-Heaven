using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float health;
    private float maxhealth;
    private Vector3 screenPos;
    public Texture2D healthTexture;
    private int Position = 30;
    public GameObject Player;

	// Use this for initialization
	void Start () {
        maxhealth = health;
		
	}
	
	// Update is called once per frame
	void Update () {
        if( health <= 0)
        {
            Destroy(gameObject);
        }
		
	}

    private void OnGUI()
    {
        if (health != maxhealth && Vectorlaenge(Vectorberechnung(transform.position, Player.transform.position)) <= 10f)
        {
            screenPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            GUI.DrawTexture(new Rect(screenPos.x - 40, Screen.height - screenPos.y - Position, health, 5), healthTexture);
            GUI.color = Color.white;
            GUI.Label(new Rect(screenPos.x - 35, Screen.height - screenPos.y - Position, 50, 30), "" + health + "/" + maxhealth);
        }
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
