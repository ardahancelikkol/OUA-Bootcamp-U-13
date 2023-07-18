using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform RightBorder;
    public Transform LeftBorder;
    public Transform PlayerTF;
    public Rigidbody2D PlayerRB;

    public bool VerticalMovement;
    public float yoffset = 5;

    private Transform CameraTF;

    private float CameraWidth;
    private Vector3 desiredPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        CameraTF = GetComponent<Transform>();
        CameraWidth = GetComponent<Camera>().orthographicSize * GetComponent<Camera>().aspect;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (VerticalMovement)
        {
            desiredPosition = new Vector3(PlayerTF.position.x, PlayerTF.position.y + yoffset, CameraTF.position.z);
        }
        else
        {
            desiredPosition = new Vector3(PlayerTF.position.x, CameraTF.position.y, CameraTF.position.z);

        }

        if (Mathf.Abs(PlayerTF.position.x - LeftBorder.position.x) >= CameraWidth && Mathf.Abs(PlayerTF.position.x - RightBorder.position.x) >= CameraWidth)
        {
            CameraTF.position = desiredPosition;
        }
        else if(Mathf.Abs(PlayerTF.position.x - LeftBorder.position.x) < CameraWidth)
        {
            if (VerticalMovement)
            {
                CameraTF.position = new Vector3(LeftBorder.position.x + CameraWidth, PlayerTF.position.y+ yoffset, CameraTF.position.z);

            }
            else
            {
                CameraTF.position = new Vector3(LeftBorder.position.x + CameraWidth, CameraTF.position.y, CameraTF.position.z);
            }
        }
        else
        {
            if (VerticalMovement)
            {
                CameraTF.position = new Vector3(RightBorder.position.x - CameraWidth, PlayerTF.position.y + yoffset, CameraTF.position.z);

            }
            else
            { 
                CameraTF.position = new Vector3(RightBorder.position.x - CameraWidth, CameraTF.position.y, CameraTF.position.z);
            }
        }
    }

}

