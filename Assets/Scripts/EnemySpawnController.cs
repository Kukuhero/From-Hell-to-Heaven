using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawnController : MonoBehaviour
{
    public int lvl;
    public int count;
    public GameObject[] enemys = new GameObject[10];
    private int random;
    private bool spawned = false;
    // Use this for initialization
    void Start()
    {
        count = enemys.Length - 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator spawnintervall()
    {
        while (count > 0 && !spawned)
        {
			random = 0;//Random.Range(0, enemys.Length - 1);
           // enemys[random].GetComponent<EnemyController>().lvl = lvl;
            Instantiate(enemys[random], transform.position, transform.rotation);
            count--;
            yield return new WaitForSeconds(1f);
        }
        spawned = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !spawned)
        {
            StartCoroutine(spawnintervall());
        }
    }
}
