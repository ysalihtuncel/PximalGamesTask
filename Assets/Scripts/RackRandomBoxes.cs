using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RackRandomBoxes : MonoBehaviour
{
    public GameObject[] rackBoxes;
    // Start is called before the first frame update
    void OnEnable()
    {
        for(int j = 0; j < rackBoxes.Length; j++) rackBoxes[j].SetActive(HelperScript.RandomBoolean());
    }
}
