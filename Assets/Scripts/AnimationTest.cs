using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ieNum());
    }

    IEnumerator ieNum() {

        yield return new WaitForSeconds(5f);
        anim.SetBool("IsMoving", false);
        anim.SetBool("IsKick_1", true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
