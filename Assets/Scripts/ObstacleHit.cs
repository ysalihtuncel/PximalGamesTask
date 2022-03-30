using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{   
    public PalletController pc;
    void OnTriggerEnter(Collider col) {
        if (col.tag == "Obstacle") {
            pc = gameObject.GetComponentInParent<PalletController>();
            pc.RemoveObject(gameObject.transform.parent.gameObject);
        } 
    }
}
