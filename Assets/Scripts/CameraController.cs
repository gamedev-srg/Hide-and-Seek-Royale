using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //script for the cinemachine that tracks the player.
    private CinemachineComposer composer; 
    private CinemachineVirtualCamera vCam;
    [Tooltip("Camera sensitivity")]
    [SerializeField] float sensitivity;

    void Start()
    {
        vCam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        composer = vCam.GetCinemachineComponent<Cinemachine.CinemachineComposer>();
        Cursor.lockState = CursorLockMode.Locked; //hide cursor and lock it inside the game screen, this should be its own script but its a one liner anyway..
    }

    void Update()
    {
        float yAxis = Input.GetAxis("Mouse Y") * sensitivity;
        //if the camera is looking at something(it our case its the player), move the Y offset of the lookat using your mouse.
        if (vCam.LookAt.GetComponent<CharacterController>().enabled)
        {
            composer.m_TrackedObjectOffset.y += yAxis;
        }
    }
}
