using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    [Range(0, 15)]
    private float amount = .08f;
    public bool fixedChar = false;

    public PalletController palletController;
    private float screenCenterX;
    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        screenCenterX = Screen.width * 0.5f;
        amount = PlayerPrefs.GetFloat("speed", 0.08f) + PlayerPrefs.GetInt("level", 0) * .002f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveOnZ(amount);
    }

    private void MoveOnZ(float amount)
    {
        transform.position += transform.forward * amount;
        if (!fixedChar)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {

                    transform.position = new Vector3(transform.position.x + touch.deltaPosition.x * 0.005f, transform.position.y, transform.position.z);
                    transform.position = transform.position.x > 2 ? new Vector3(2, transform.position.y, transform.position.z) : transform.position.x < -2 ? new Vector3(-2, transform.position.y, transform.position.z) : transform.position;
                    if (transform.position.x < 2 && transform.position.x > -2)
                        palletController.HingedBoxes(-transform.position.x * 5);
                    else
                        palletController.HingedBoxes(0);
                }
            }
            else
            {
                palletController.HingedBoxes(0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveOnX(-0.05f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveOnX(0.05f);
            }
        }
        else
        {
            palletController.HingedBoxes(0);
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, transform.position.y, transform.position.z), 0.5f);
        }

    }

    private void MoveOnX(float val)
    {
        transform.position = new Vector3(transform.position.x + val, transform.position.y, transform.position.z);
        transform.position = transform.position.x > 2 ? new Vector3(2, transform.position.y, transform.position.z) : transform.position.x < -2 ? new Vector3(-2, transform.position.y, transform.position.z) : transform.position;
        if (transform.position.x < 2 && transform.position.x > -2)
            palletController.HingedBoxes(-transform.position.x * 5);
        else
            palletController.HingedBoxes(0);
    }
}
