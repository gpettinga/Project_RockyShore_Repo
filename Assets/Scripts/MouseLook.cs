using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    Vector2 mouseLook;
    Vector2 smoothV;

    public float maxSensitivity = .0025f;
    public float sensitivity = .0025f;
    public float minSensitivity = .00125f;
    public float smoothing = 2.0f;

    GameObject character;

    PlayerInput pI;

    public GameObject rifle;

	// Use this for initialization
	void Start ()
    {
        character = this.transform.parent.gameObject;
        sensitivity = maxSensitivity;
        Cursor.lockState = CursorLockMode.Locked;
        pI = GetComponentInParent<PlayerInput>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pI.isAiming == true)
        {
            //Debug.Log("is aiming ?" + pI.isAiming);
            sensitivity = minSensitivity;
            rifle.gameObject.transform.parent = this.gameObject.transform;
        }
        else if(pI.isAiming == false)
        {
            sensitivity = maxSensitivity;
            rifle.gameObject.transform.parent = character.gameObject.transform;
        }
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse_Horizontal"), Input.GetAxisRaw("Mouse_Vertical"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;
        mouseLook.y = Mathf.Clamp(mouseLook.y, -45f, 45f);
        mouseLook.x = Mathf.Clamp(mouseLook.x, -45f, 45f);

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
