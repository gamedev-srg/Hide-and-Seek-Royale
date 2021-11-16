using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    private Animator animator;
    private CharacterController characterController;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] private float sprinting_speed;
    [SerializeField] private float speedToUse;
    private HealthSystem healthSystem;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        speedToUse = movementSpeed;
        sprinting_speed = movementSpeed * 2;
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (healthSystem.currentHealth > 0)
        {
            var xAxisMouse = Input.GetAxis("Mouse X");
            var zAxis = Input.GetAxis("Vertical");
            //var xShuffle = Input.GetAxis("Horizontal");

            var movmentVector = new Vector3(xAxisMouse, 0, zAxis);

            animator.SetFloat("speed", movmentVector.magnitude);
            //characterController.SimpleMove(xShuffle * transform.right * speedToUse);
            transform.Rotate(Vector3.up, xAxisMouse * rotationSpeed * Time.deltaTime);
            if (zAxis != 0)
            {
                characterController.SimpleMove(transform.forward * speedToUse * zAxis);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speedToUse = sprinting_speed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speedToUse = movementSpeed;
            }
        }
    }
}
