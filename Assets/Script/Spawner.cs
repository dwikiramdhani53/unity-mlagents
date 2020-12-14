using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    public float respawnTime = 2.0f;

    private void Start() {
        StartCoroutine(obstacleWave());
    }

    private void spawn(){
        GameObject a = Instantiate(obstaclePrefabs) as GameObject;
        a.transform.parent = gameObject.transform;
        a.transform.position = new Vector3(Random.Range(GetComponent<Collider>().bounds.min.x, GetComponent<Collider>().bounds.max.x), 1.5f, GetComponent<Collider>().bounds.max.z);
    }

    IEnumerator obstacleWave(){
        while(true){
            yield return new WaitForSeconds(respawnTime);
            spawn();
        }
    }

    public void ClearItem(){
        foreach (Transform child in transform)
        {
            if(child.CompareTag("Item"))
                Destroy(child.gameObject);
        }
    }
}
