using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeHellController : MonoBehaviour {
    public GameObject Explosion;
    float x = 12;
    public float speed;

    // Use this for initialization
    void Start () {
        StartCoroutine(Destroy());
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, x, 0f) + transform.forward * speed, ForceMode.Impulse);
    }
	
	// Update is called once per frame
	void Update () {
        /*if(transform.position.y <=0)
        {
            Instantiate(Explosion, new Vector3(transform.position.x, 0.2f, transform.position.z),transform.rotation);
            Destroy(gameObject);
        }*/

       // x -= 1.5f;

       // gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0f, x, 0f) + transform.forward*10,ForceMode.Impulse);

          //  transform.position += (transform.forward*10 + new Vector3(0f,x,0f)) * Time.deltaTime*speed;
           // x += 0.1f; 
        
		
	}

   /* private void OnTriggerEnter(Collider other)
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }*/
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3f);
        Instantiate(Explosion, new Vector3(transform.position.x, 0.2f, transform.position.z), transform.rotation);
        Destroy(gameObject);
    }
}
