using UnityEngine;
using System.Collections;

public class Skeleton_VikingEnemyController : MonoBehaviour
{

    Vector3 Richtungsvector;
    public float speed;
    float originalspeed;
    int i = 0;
    bool attack = false;
    GameObject target;
    public int lvl;
    public Animator anim;
    bool walk = true;
	bool dead= false;
	bool inattack = false;

    // Use this for initialization
    void Start()
    {
        originalspeed = speed;
			InvokeRepeating ("Richtungswechsel", 2f, Random.Range (1f, 4f));
    }

    // Update is called once per frame
    void Update()
	{
		

		if (gameObject.GetComponent<Health> ().health == 0 && !dead) 
		{
			dead = true;
			anim.SetFloat ("life", gameObject.GetComponent<Health> ().health);
		}
		if (!dead) 
		{
			if (walk) 
			{
				transform.position += Richtungsvector * speed * Time.deltaTime;
				anim.SetBool ("walk", true);
			}

			float angle = Mathf.Atan2 (Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.up);

			if (attack) 
			{
				CancelInvoke ("Richtungswechsel");
				Richtungsvector = Vectornormieren (Vectorberechnung (transform.position, target.transform.position));
				if (Vectorlaenge (Vectorberechnung (transform.position, target.transform.position)) <= 2.5f) 
				{
					speed = 0;
					anim.SetBool ("walk", false);
					if (!inattack) {
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
					anim.SetBool("attack3", false);
				}

			}
		}
	}
    
    void OnTriggerEnter(Collider other)
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
                if (!other.isTrigger)
                {
                    attack = true;
				print ("Enemy: Spieler in Sicht");
                    target = other.transform.gameObject;
                    float angle = Mathf.Atan2(Richtungsvector.x, Richtungsvector.z) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
				transform.position += Richtungsvector * speed * Time.deltaTime;
                }
                break;
        }
    }



    private void OnTriggerExit(Collider other)
    {
		if (other.tag == "Player" && !other.isTrigger)
        {
            speed = originalspeed;
            attack = false;
            walk = true;
			InvokeRepeating ("Walk", 0f, Random.Range (1f, 4f));
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
            float ii = Mathf.Round(Random.Range(1f, 1f));

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
		
			
			Richtungsvector = Vectornormieren (new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f)));
            

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
