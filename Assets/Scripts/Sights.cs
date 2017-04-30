using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sights : MonoBehaviour
{
    
    public float mainFov = 60.0f;
    public float zoomFov = 10.0f;
    public float zoomTime = .3f;

    public GameObject sightBox;
    //public GameObject downSightLocation;

    //public Vector3 sightStart;
    //public Vector3 downSights;
    
    PlayerInput pI;

    // Use this for initialization
    void Start()
    {
        pI = GetComponentInParent<PlayerInput>();
        //sightStart = sightBox.transform.position;
        //downSights = downSightLocation.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pI.isAiming == true)
        {
            AimDownSights();
            //Debug.Log("aim down sights");
        }
        else if (pI.isAiming == false)
        {
            NormalView();
            //Debug.Log("nomral view");

        }
    }

    public void AimDownSights()
    {
        //Camera.main.fieldOfView = Mathf.Lerp(mainFov, zoomFov, zoomTime);
        sightBox.transform.localPosition = new Vector3(0,0,.164f);
    }

    public void NormalView()
    {
        //Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, mainFov, zoomTime);
        sightBox.transform.localPosition = new Vector3(.346f,-.181f,.371f);
    }
}
