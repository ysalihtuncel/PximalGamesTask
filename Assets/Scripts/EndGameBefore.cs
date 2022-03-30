using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameBefore : MonoBehaviour
{
    public CharacterMove characterMove;
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Pallet")
        {

            characterMove.fixedChar = true;

        }
    }
}
