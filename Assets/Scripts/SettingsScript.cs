using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    // Start is called before the first frame update
    public void ToggleOnchange() {
        Toggle toggle = toggleGroup.GetFirstActiveToggle();
        int k = toggle.GetComponentInChildren<Text>().text == "On" ? 1 : 0;
        PlayerPrefs.SetInt("Sound", k);
    }
}
