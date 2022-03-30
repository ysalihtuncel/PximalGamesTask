using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderCheck : MonoBehaviour
{
    public PalletController pc;

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Pallet") {
            col.gameObject.GetComponentInParent<PalletController>().UpdatePallet();
            GameObject.Destroy(gameObject);
        } 
    }
}
