using UnityEngine;
using System.Collections;

public class Skeleton_VikingEnemyController : MonoBehaviour
{

    Vector3 Richtungsvector;
    public float speed;
    float originalspeed;
    bool attack = false;
    GameObject target;
    public int lvl;
    public Animator anim;
    bool walk = true;
	public bool dead= false;
	bool inattack = false;
	public Transform[] Waypoints = new Transform[10];
	int x = -1;
	int anzahl = 0;
	bool forward = true;
	//int ii = 0;
	public bool Kreislaufen;
	bool searching = false;
	public float damage1;
	public float damage2;
	public float damage3;
	public GameObject Sword;
	float ii;

    // Use this for initialization
    void Start()
    {
		speed = 4f;
		originalspeed = speed;
		anzahl = Waypoints.Length;

		Waypointwalk ();


			
    
			//InvokeRepeating ("Richtungswechsel", 2f, Random.Range (1f, 4f));
    }

    // Update is called once per frame
    void Update()
	{
		if (searching) 
		{
			RaycastHit hit2;
			//if (Physics.Raycast (transform.position, target.transform.position, out hit2, 10f)) 
			{
				
				//if (hit2.transform.tag == "Player") transform.position vom Player ist nicht Position vom Player, wird mit eigenem Modell gefixt
				{
					
					attack = true;
					print ("Enemy: Spieler gefunden");
					float angle = Mathf.Atan2(Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
					transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
					//transform.position += Richtungsvector * speed * Time.deltaTime;
				}
			}
		}
		//print (speed);
		//print (Richtungsvector);
		//print (target.GetComponent<Health> ().health);
		//print (anzahl);

		if (gameObject.GetComponent<EnemyStats> ().health == 0 && !dead) 
		{
			dead = true;
			transform.GetComponent<Drops> ().Drop ();
			StartCoroutine(GetComponent<EnemyStats> ().Destroy());
			Destroy(gameObject.GetComponent<CapsuleCollider>());
			Destroy(gameObject.transform.FindChild("HealthbarCanvas").gameObject);
			anim.SetFloat ("life", gameObject.GetComponent<EnemyStats> ().health);
		}
		if (!dead) 
		{
			if (walk)
			{
				transform.position += Richtungsvector * speed * Time.deltaTime;
				anim.SetBool ("walk", true);
				//print(Vectorlaenge(Vectorberechnung(transform.position,Waypoints[x].transform.position)));
				//if (i != 0 && transform.position.x*0.8f >= Waypoints [x].transform.position.x && transform.position.z*0.8f >= Waypoints[x].transform.position.z )
				if (Vectorlaenge (Vectorberechnung (transform.position, Waypoints [x].transform.position)) <= 2f && !attack) {
					Waypointwalk ();
				}
			} else 
			{
				anim.SetBool ("walk", false);
			}

			float angle = Mathf.Atan2 (Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);

			if (attack) 
			{
				

				CancelInvoke ("Richtungswechsel");
				//print (Vectornormieren (Vectorberechnung (transform.position, target.transform.position)));
				Richtungsvector = Vectornormieren (Vectorberechnung (transform.position, target.transform.position));
				if (Vectorlaenge (Vectorberechnung (transform.position, target.transform.position)) <= 2f) 
				{
					print ("Enemy: Spieler vor mir");
					speed = 0;
					anim.SetBool ("walk", false);
					if (!inattack) 
					{
						inattack = true;
						InvokeRepeating ("Attack", 0f, 3f);
					}
					walk = false;
					CancelInvoke ("Richtungswechsel");
				} else 
				{
					walk = true;
					speed = originalspeed;
					inattack = false;
					CancelInvoke ("Attack");
					anim.SetBool("attack1", false);
					anim.SetBool("attack2", false);
					//anim.SetBool("attack3", false);
				}

			}
		}
	}
    
    void OnTriggerEnter(Collider other)
    {

        switch (other.transform.tag)
        {
		case "Wall":
			print ("WallinTrigger(Enemy)");
			RaycastHit hit;
			if (Physics.Raycast (transform.position, Richtungsvector, out hit, 10f)) {
				print ("Wall in my way (Enemy)");
				//Richtungsvector = Normalenvectorberechnung(Richtungsvector);
				if (Physics.Raycast (transform.position, Richtungsvector, out hit, 10f)) {
					// Richtungsvector = -Richtungsvector;
				}
			}
		break;

        case "Player":
			if (!other.isTrigger/* && other.name == "Player"*/ && other.gameObject != target)
            {
					//searching = true;
               		target = other.transform.gameObject;
					attack = true;
					print ("Enemy: Spieler gefunden");
					float angle = Mathf.Atan2(Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
					transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
					//transform.position += Richtungsvector * speed * Time.deltaTime;
            }
        break;
        }
    }



    private void OnTriggerExit(Collider other)
    {
		if (other.name == "Player" && !other.isTrigger && other.gameObject != target)
        {
			print ("Enemy: Spiler verlässt Trigger");
			searching = false;
            speed = originalspeed;
            attack = false;
            walk = true;
			x = 0;
			//InvokeRepeating ("Walk", 0f, Random.Range (1f, 4f));
			CancelInvoke ("Attack");
			inattack = false;
			anim.SetBool("attack1", false);
			anim.SetBool("attack2", false);
			anim.SetBool("attack3", false);
        }
    }

    void Attack()
	{
		anim.SetBool("attack1", false);
		anim.SetBool("attack2", false);
		anim.SetBool("attack3", false);
		print ("inattack");
            ii = Mathf.Round(Random.Range(1f, 1f));

            if (ii == 1f)
            {
                anim.SetBool("attack1", true);
            }
            if (ii == 2f)
            {
                anim.SetBool("attack2", true);
            }
            if (ii == 3f)
            {
                anim.SetBool("attack3", true);
            }
            

    }

    void Richtungswechsel()
    {
		

			//Richtungsvector = Vectornormieren (new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f)));

            

      }

	void Waypointwalk()
	{
		print ("in Waypointwalk");
		if (x+1 < anzahl && forward) 
		{
			x++;
			Richtungsvector = Vectornormieren(new Vector3(Waypoints [x].position.x,0f,Waypoints[x].position.z)-transform.position);


		} else 
		{
			x--;
			Richtungsvector = Vectornormieren(new Vector3(Waypoints [x].position.x,0f,Waypoints[x].position.z)-transform.position);
			forward = false;
			if (Kreislaufen) 
			{
				x = 0;
				Richtungsvector = Vectornormieren (new Vector3 (Waypoints [x].position.x, 0f, Waypoints [x].position.z) - transform.position);
				forward = true;
			}
		}
		if (x == 0) 
		{
			forward = true;
		}

			walk = false;
		Invoke ("Wait", Random.Range(2,4));

	}
	void Wait()
	{
		walk = true;
	}
    
    Vector3 Vectornormieren(Vector3 vector)
    {
        float Länge = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
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
    float Vectorlaenge(Vector3 Vector)
    {
        return Mathf.Sqrt(Vector.x * Vector.x + Vector.y * Vector.y + Vector.z * Vector.z);
    }
}
