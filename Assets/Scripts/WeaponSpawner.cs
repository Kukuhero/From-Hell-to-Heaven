using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour {
    public GameObject Weapon;
    public GameObject player;
    int Inventarnumber;

	// Use this for initialization
	void Start () {
        Instantiate(Weapon, transform.position, Weapon.transform.rotation, transform);
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Inventarnumber = player.GetComponent<Inventar>().number;
        //print("(WeaponSpawner) Invnumber: " + Inventarnumber);
        player.GetComponent<Inventar>().number++;
        player.GetComponent<Inventar>().inventar[Inventarnumber] = Weapon;
        Destroy(gameObject);
    }
}
