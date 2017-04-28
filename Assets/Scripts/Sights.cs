using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sights : MonoBehaviour
{
    
    public float mainFov = 60.0f;
    public float zoomFov = 10.0f;
    public float zoomTime = .3f;


    PlayerInput pI;

    // Use this for initialization
    void Start()
    {
        pI = GetComponent<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pI.isAiming == true)
        {
            AimDownSights();
        }
        else if (pI.isAiming == false)
        {
            NormalView();
        }
    }

    public void AimDownSights()
    {
        Camera.main.fieldOfView = Mathf.Lerp(mainFov, zoomFov, zoomTime);
    }

    public void NormalView()
    {
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, mainFov, zoomTime);
    }
}
