using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireprojektilEnemyController : MonoBehaviour {

    Vector3 richVector;
    public float speed;
    // Use this for initialization
    void Start()
    {
        //richVector =Vectornormieren(transform.parent.parent.parent.transform.forward);
        StartCoroutine(Destroy());

    }

    // Update is called once per frame
    void Update()
    {
        // print(richVector);
        float step = speed * Time.deltaTime;
        transform.position += transform.forward * step;


    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Wall":
                print("Fire hit Wall(Fireprojektil)");
                Destroy(gameObject);
                break;

            case "Player":
                print("Enemy hit (shoot)");
                //other.GetComponent<Health>().health -= 5f;
                break;
        }
    }


    IEnumerator Destroy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);
        }
    }
    Vector3 Vectornormieren(Vector3 vector)
    {
        float Länge = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y + vector.z * vector.z);
        return (1 / Länge) * vector;
    }
}
