using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    GameObject player;

    public float speed = 1.0f;
    public float aimSpeed = .25f;
    public float maxMoveSpeed = 1.0f;

    public bool isAiming = false;
    bool hasMoved = false;

    public GameObject crosshair;

    // Use this for initialization
    void Start()
    {
        crosshair.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        
        float translationUD = Input.GetAxis("Vertical");
        if (translationUD >= 1.0f && hasMoved == false && !isAiming)
        {
            hasMoved = true;
            MoveUp();
        }
        if (translationUD <= -1.0f && hasMoved == false && !isAiming)
        {
            hasMoved = true;
            MoveDown();
        }
        if (translationUD < .01f && translationUD > -.01f)
        {
            hasMoved = false;
        }
        if (isAiming)
        {
            speed = aimSpeed;
        }
        else
        {
            speed = maxMoveSpeed;
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
            if (isAiming)
                crosshair.SetActive(true);
            else
                crosshair.SetActive(false);
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
