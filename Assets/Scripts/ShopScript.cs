using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public GameObject[] characters_1, characters_2;
    public GameObject BuyButton;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("char_0", 1);
        index = PlayerPrefs.GetInt("char", 0);
        characters_1[index].SetActive(true);
        characters_2[index].SetActive(true);
        BuyButton.SetActive(false);
    }

    public void PrevNext(int val) {
        index = index + val < 0 ? characters_2.Length -1 : index + val == characters_2.Length ? 0 : index + val;
        BuyButton.SetActive(PlayerPrefs.GetInt("char_" + index.ToString(), 0) == 0);
        if (PlayerPrefs.GetInt("char_" + index.ToString(), 0) == 1) {
            PlayerPrefs.SetInt("char", index);
            for(int j = 0; j < characters_1.Length; j++) characters_1[j].SetActive(false);
            characters_1[index].SetActive(true);
        }
        for(int j = 0; j < characters_2.Length; j++) characters_2[j].SetActive(false);
        characters_2[index].SetActive(true);
    }
    public void BuyCharacter() {
        if(PlayerPrefs.GetInt("box", 0) >= 50) {
            PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box", 0) - 50);
            PlayerPrefs.SetInt("char_" + index.ToString(), 1);
            PlayerPrefs.SetInt("char", index);
            for(int j = 0; j < characters_1.Length; j++) characters_1[j].SetActive(false);
            characters_1[index].SetActive(true);
            BuyButton.SetActive(false);
        }
    }
}
