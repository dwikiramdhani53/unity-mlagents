using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public bool miss = false;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Item"){
            miss = true;
            Destroy(other.gameObject);
        }
    }

    public bool IsMiss(){
        return miss;
    }

    public void ResetMiss(){
        miss = false;
    }
}
