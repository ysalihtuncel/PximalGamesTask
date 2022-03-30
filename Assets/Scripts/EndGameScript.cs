using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndGameScript : MonoBehaviour
{
    public PalletController palletController;
    public CharacterMove characterMove;

    public Animator animator, truckAnimator;
    public TextMeshProUGUI tmp;

    private bool _update = false, touched = true, enumarator = false;
    int palletCount = 0, _count = 0;
    public ParticleSystem particle;

    void Start() {
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Pallet")
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsIdle", true);
            characterMove.enabled = false;
            palletCount = palletController.pallets.Count;
            palletController.PalletsParent();
            _update = true;
        }
    }

    void Update()
    {
        if (_update)
        {
            if (palletCount == 0) {
                StartCoroutine(FailedLevel());
            }
            else {

            
                #if UNITY_EDITOR
                if (Input.GetKeyDown(KeyCode.UpArrow)) {
                    palletController.PalletsToTruck(_count);
                    PlayAnim(_count);
                    _count++;
                    if(particle.isPlaying) {
                        particle.Stop();
                    }
                    particle.Play();
                    AudioController.HitSound();
                    PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box", 0)+1);
                    tmp.text = PlayerPrefs.GetInt("box", 0).ToString();
                    Debug.Log("count: " + _count);
                    Debug.Log("box count: " + PlayerPrefs.GetInt("box", 0));
                    if (_count >= palletCount)
                    {
                        animator.SetBool("IsIdle", false);
                        animator.SetBool("IsDancing", true);
                        StartCoroutine(TriggerUpdate());
                    }
                    
                    
                }

                #elif UNITY_ANDROID
                if (Input.touchCount > 0 && !touched)
                {
                    switch (Input.GetTouch(0).phase)
                    {
                        //When a touch has first been detected, change the message and record the starting position
                        case TouchPhase.Began:
                            touched = true;
                            break;

                        case TouchPhase.Ended:
                            // Report that the touch has ended when it ends
                            touched = false;
                            break;
                        case TouchPhase.Stationary:
                            touched = false;
                            break;
                        case TouchPhase.Moved:
                            touched = false;
                            break;
                    }
                    //palletController.PalletsToTruck(_count);
                    if (_count < palletCount ) {
                        StartCoroutine(BoxIEnumerator(_count));
                        PlayAnim(_count);
                        PlayerPrefs.SetInt("box", PlayerPrefs.GetInt("box", 0)+1);
                        tmp.text = PlayerPrefs.GetInt("box", 0).ToString();
                        if(particle.isPlaying) {
                            particle.Stop();
                        }
                        particle.Play();
                        AudioController.HitSound();
                        _count++;
                        if (_count == palletCount) {
                            animator.SetBool("IsIdle", false);
                            animator.SetBool("IsDancing", true);
                            StartCoroutine(TriggerUpdate());
                        }
                        
                    }
                }
                if(Input.touchCount == 0) {
                    touched = false;
                }
                #endif
            }
        } 
    }

    private void PlayAnim(int animIndex)
    {
        int _index = animIndex % 3;
        if (_index == 0)
        {
            animator.SetTrigger("Kick_1");
        }
        else if (_index == 1)
        {
            
            animator.SetTrigger("Kick_2");
        }
        else
        {
            animator.SetTrigger("Kick_3");
        }
    }

    IEnumerator TriggerUpdate()
    {
        if (!enumarator) {
            enumarator = true;
            yield return new WaitForSeconds(1f);
            AudioController.AwardSound();
            truckAnimator.SetBool("truck_start", true);
            yield return new WaitForSeconds(2f);
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0) + 1);
            yield return new WaitForSeconds(5f);
            enabled = false;
        }

    }

    IEnumerator FailedLevel() {
        if (!enumarator) {
            enumarator = true;
            yield return new WaitForSeconds(1f);
            AudioController.LosingSound();
            truckAnimator.SetBool("truck_start", true);
            yield return new WaitForSeconds(5f);
            enabled = false;
        }
    }

    IEnumerator BoxIEnumerator(int index)
    {
        yield return new WaitForSeconds(0.2f);
        palletController.PalletsToTruck(index);
    }
    void OnDisable()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    bool AnimatorIsPlaying()
    {
        return animator.GetCurrentAnimatorStateInfo(0).length < 1;
    }


}
