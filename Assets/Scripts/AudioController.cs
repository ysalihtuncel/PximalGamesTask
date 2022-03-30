using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioClip box_crack;
    public AudioClip hit;
    public AudioClip award;
    public AudioClip lose;
    public AudioSource source;

    private static AudioController instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    public static void CollectBoxSound(int box_id) {
        if (instance == null) {
            Debug.Log("insatance null");
            return;
        }
        Debug.Log(PlayerPrefs.GetInt("Sound", 1));
        if (PlayerPrefs.GetInt("Sound", 1) == 1) {
            if (instance.source.isPlaying) {
                instance.source.Stop();
            }
            box_id = box_id > 4 ? 4 : box_id;
            instance.source.clip = instance.clips[box_id];
            instance.source.Play();
        }
    }
    public static void BreakBox() {
        if (instance == null) {
            return;
        }
        if (PlayerPrefs.GetInt("Sound", 1) == 1) {
            if (instance.source.isPlaying) {
                instance.source.Stop();
            }
            instance.source.clip = instance.box_crack;
            instance.source.Play();
        }
    }
    public static void HitSound() {
        if (instance == null) {
            return;
        }
        if (PlayerPrefs.GetInt("Sound", 1) == 1) {
            if (instance.source.isPlaying) {
                instance.source.Stop();
            }
            instance.source.clip = instance.hit;
            instance.source.Play();
        }
    }
    public static void AwardSound() {
        if (instance == null) {
            return;
        }
        if (PlayerPrefs.GetInt("Sound", 1) == 1) {
            if (instance.source.isPlaying) {
                instance.source.Stop();
            }
            instance.source.clip = instance.award;
            instance.source.Play();
        }
    }

    public static void LosingSound() {
        if (instance == null) {
            return;
        }
        if (PlayerPrefs.GetInt("Sound", 1) == 1) {
            if (instance.source.isPlaying) {
                instance.source.Stop();
            }
            instance.source.clip = instance.lose;
            instance.source.Play();
        }
    }
}
