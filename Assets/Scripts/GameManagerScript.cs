using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class GameManagerScript : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI level;

    public CharacterMove characterMove;
    public Animator animator;
    public GameObject playButton, shopButton, settingsButton, shopMenu, settingsMenu;
    public GameObject[] characters_1, characters_2;

    public CinemachineVirtualCamera vcam1, vcam2;

    public GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {

        characterMove.enabled = false;
        animator.SetBool("IdleToMove", true);
        characters_1[PlayerPrefs.GetInt("char", 0)].SetActive(true);
        characters_2[PlayerPrefs.GetInt("char", 0)].SetActive(true);

        tmp.text = PlayerPrefs.GetInt("box", 0).ToString();
        level.text = "Lvl: " + (PlayerPrefs.GetInt("level", 0) + 1).ToString();

        for (int j = 0; j < obstacles.Length; j++) {
            obstacles[j].SetActive(HelperScript.RandomBoolean(4));
        }
    }

    public void StartGame() {
        playButton.SetActive(false);
        shopButton.SetActive(false);
        settingsButton.SetActive(false);
        animator.SetBool("IdleToMove", false);
        animator.SetBool("IsMoving", true);
        characterMove.enabled = true;
    }

    public void CloseOrOpenMenu(int menu_id) {
        if (menu_id == 0) {
            settingsMenu.SetActive(!settingsMenu.activeSelf);
            

        }
        else {
            shopMenu.SetActive(!shopMenu.activeSelf);
            playButton.SetActive(!shopMenu.activeSelf);
            shopButton.SetActive(!shopMenu.activeSelf);
            settingsButton.SetActive(!shopMenu.activeSelf);
            vcam1.m_Priority = shopMenu.activeSelf ? 0 : 10;
            vcam2.m_Priority = shopMenu.activeSelf ? 10 : 0;
        }
    }
}
