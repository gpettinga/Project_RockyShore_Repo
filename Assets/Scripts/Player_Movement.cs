using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    GameObject player;

    public float speed = 1.0f;

    bool isAiming = false;
    bool hasMoved = false;


    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        
        float translationUD = Input.GetAxis("Vertical");
        if (translationUD >= 1.0f && hasMoved == false)
        {
            hasMoved = true;
            MoveUp();
        }
        if (translationUD <= -1.0f && hasMoved == false)
        {
            hasMoved = true;
            MoveDown();
        }
        if (translationUD < .01f && translationUD > -.01f)
        {
            hasMoved = false;
        }
        Debug.Log(translationUD);
        float translationLR = Input.GetAxis("Horizontal") * speed;
        //translationUD *= Time.deltaTime;
        translationLR *= Time.deltaTime;

        transform.Translate(translationLR, 0, 0);

        if (Input.GetKeyDown("joystick button 4"))
        {
            isAiming = !isAiming;
            Debug.Log("am i aiming?" + " " + isAiming);
        }
    }

    public void MoveUp()
    {
        transform.Translate(0, 2, 0);
        Debug.Log("moving UP");
    }
    public void MoveDown()
    {
        transform.Translate(0, -2, 0);
        Debug.Log("moving Down");
    }
}
