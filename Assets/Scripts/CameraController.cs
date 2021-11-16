using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    private CinemachineComposer composer;
    private CinemachineVirtualCamera vCam;
    [SerializeField] float sensitivity;
    // Start is called before the first frame update
    void Start()
    {
        vCam = GetComponent<Cinemachine.CinemachineVirtualCamera>();
        composer = vCam.GetCinemachineComponent<Cinemachine.CinemachineComposer>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float yAxis = Input.GetAxis("Mouse Y") * sensitivity;
        if (vCam.LookAt.GetComponent<CharacterController>().enabled)
        {
            composer.m_TrackedObjectOffset.y += yAxis;
        }
    }
}
