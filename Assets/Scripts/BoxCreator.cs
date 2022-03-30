using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreator : MonoBehaviour
{
    public GameObject prefabBox;
    public List<GameObject> boxes = new List<GameObject>();
    public Transform firstPoint;
    public int box_count = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        UpdatePallet();
    }

    public void UpdatePallet()
    {
        GameObject gm;
        float right;
        for (int i = 0; i < box_count; i++)
        {
            if (boxes.Count == 0)
            {
                gm = Object.Instantiate(prefabBox, firstPoint.position, firstPoint.rotation);
            }
            else
            {
                right = HelperScript.RandomBoolean(2) ? 1.4f : -1.4f;
                gm = Object.Instantiate(prefabBox, new Vector3(right, boxes[boxes.Count - 1].transform.position.y, boxes[boxes.Count - 1].transform.position.z + 8), boxes[boxes.Count - 1].transform.rotation);
            }
            boxes.Add(gm);
        }

    }
}
