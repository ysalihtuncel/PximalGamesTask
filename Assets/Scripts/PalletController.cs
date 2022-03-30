using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletController : MonoBehaviour
{
    public GameObject prefabBox;
    public List<GameObject> pallets = new List<GameObject>();
    public Transform firstPoint;

    public Transform[] truckPoints;
    // Start is called before the first frame update

    public void UpdatePallet()
    {
        GameObject gm;
        if(pallets.Count == 0) {
            gm = Object.Instantiate(prefabBox, firstPoint);
        }
        else {
            gm = Object.Instantiate(prefabBox, pallets[pallets.Count -1].transform.GetChild(pallets[pallets.Count -1].transform.childCount - 1).gameObject.transform.position, pallets[pallets.Count -1].transform.GetChild(pallets[pallets.Count -1].transform.childCount - 1).gameObject.transform.rotation, pallets[pallets.Count -1].transform);
        }
        
        pallets.Add(gm);
        AudioController.CollectBoxSound(pallets.Count);
    }

    public void RemoveObject(GameObject _obj) {
        int index = pallets.IndexOf(_obj);
        Debug.Log("indexxx: " + index);
        for (int j = pallets.Count -1; j >= index; j--) {
            pallets[j].transform.GetChild(0).gameObject.SetActive(true);
            pallets[j].transform.GetChild(1).gameObject.SetActive(false);
            pallets.RemoveAt(j);
            Debug.Log("tersten count: " + pallets.Count);
        }
        Debug.Log(pallets.Count);
        AudioController.BreakBox();
        _obj.transform.SetParent(null);
        StartCoroutine(destroyObject(_obj));

    }

    IEnumerator destroyObject(GameObject gm) {
        yield return new WaitForSeconds(2f);
        Destroy(gm);
    }

    public void HingedBoxes(float radius) {
        
        for (int i = 0; i < pallets.Count; i++) {
            if(i % 2 == 0) {
                Vector3 rotationVector =  pallets[i].transform.rotation.eulerAngles;
                rotationVector.z = radius * i;
                pallets[i].transform.rotation =  Quaternion.Lerp(pallets[i].transform.rotation, Quaternion.Euler(rotationVector), 0.1f);
                
            }
        }

    }

    public void PalletsParent() {
        for (int j = 0; j < pallets.Count; j++){
            pallets[j].transform.parent = null;
            pallets[j].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
        }
            
    }

    public void PalletsToTruck(int index) {
        pallets[index].gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(SmoothTranlation(pallets[index].transform, truckPoints[index]));
            
    }

    IEnumerator SmoothTranlation(Transform origin, Transform target)
     {
        while (origin.transform.position != target.position)
        {
            origin.transform.position = Vector3.Lerp(origin.transform.position, target.position, Time.deltaTime * 1.5f);
            yield return new WaitForEndOfFrame();
        }
 
     }

}
