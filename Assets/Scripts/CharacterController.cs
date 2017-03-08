using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {
    private float speed;
    public Transform Weaponspawnpoint;
    GameObject Weapon;
    int Invnumb = 0,counter = 0,oldcounter=-20;
    bool firstWeapon = true;
    public Animator anim;
    public int lvl, dashlenght, dashspeedadd, dashcooldown;
	private bool dashavailable = true;
	private float normalspeed;
	// Use this for initialization
	void Start () {
        speed = transform.GetComponent<CharacterStats>().speed;
        if (transform.GetComponent<Inventar>().inventar[0] != null)
        {
            Weapon = transform.GetComponent<Inventar>().inventar[0];
            Instantiate(Weapon, Weaponspawnpoint.position, transform.rotation, Weaponspawnpoint);
           
        }
		normalspeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		
		counter++;

		if (counter-oldcounter==dashcooldown) 
		{
			dashavailable = true;
		}

        Animation();
        Vector3 rotationVector = transform.rotation.eulerAngles;
        rotationVector.y += Input.GetAxis("Mouse X") * 10;
        gameObject.transform.rotation = Quaternion.Euler(rotationVector);


        if (transform.GetComponent<Inventar>().inventar[0] != null && firstWeapon == true)
        {
            Weapon = transform.GetComponent<Inventar>().inventar[0];
            Instantiate(Weapon, Weaponspawnpoint.position, transform.rotation, Weaponspawnpoint);
            
            firstWeapon = false;
        }


        if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") != 0)
            {
            
                transform.position += (Vectornormieren(transform.forward) * Input.GetAxis("Vertical") * speed + 
                    Vectornormieren(Normalenvectorberechnung(transform.forward))* Input.GetAxis("Horizontal") * speed) * Time.deltaTime;
        }
       
            if (Input.GetAxis("Vertical") != 0 && Input.GetAxis("Horizontal") != 0)
            {
            transform.position += (Vectornormieren(transform.forward) * Input.GetAxis("Vertical") * speed + 
                    Vectornormieren(Normalenvectorberechnung(transform.forward))* Input.GetAxis("Horizontal") * speed)* 1/Mathf.Sqrt(2f)*Time.deltaTime;
            }
        
		if (Input.GetKeyDown (KeyCode.LeftShift)&&dashavailable) 
		{
			speed += dashspeedadd;
			oldcounter = counter;
			dashavailable = false;
		}

		if (counter - oldcounter == dashlenght) 
		{
			speed = normalspeed;
		}

        if( Input.GetMouseButtonDown(0))
        {
            transform.FindChild("Weaponspawnpoint").GetChild(0).gameObject.GetComponent<WeaponController>().shoot = true;
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Destroy(transform.FindChild("Weaponspawnpoint").GetChild(0).gameObject);
            if(Input.GetAxis("Mouse ScrollWheel")<0)
            {
                Invnumb--;
                if(Invnumb < 0)
                {
                    int i = 0;
                    while( i<= 20 && transform.GetComponent<Inventar>().inventar[i] !=null)
                    {
                        i++;
                    }
                    i--;
                    Invnumb = i;
                    print("(CC) Invnumb: " + Invnumb);
                }
                Weapon = transform.GetComponent<Inventar>().inventar[Invnumb];
                Instantiate(Weapon, Weaponspawnpoint.position, transform.rotation, Weaponspawnpoint);
              


            }
            else
            {
                Invnumb++;
                if(transform.GetComponent<Inventar>().inventar[Invnumb]==null)
                {
                    Invnumb = 0;
                }
                Weapon = transform.GetComponent<Inventar>().inventar[Invnumb];
                Instantiate(Weapon, Weaponspawnpoint.position, transform.rotation, Weaponspawnpoint);
              
            }
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
    void Animation()
    {
        if(Input.GetAxis("Vertical")> 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            anim.SetBool("Back", true);
        }
        else
        {
            anim.SetBool("Back", false);
        }
        if(!firstWeapon )
        {
            anim.SetBool("Weapon", true);
        }
    }

	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Wall")
		{
			speed = normalspeed;
		}
	}

}
