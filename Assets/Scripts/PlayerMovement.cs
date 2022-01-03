    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    [Tooltip("Player rotation speed at which you rotate via mouse")]
    [SerializeField] float rotationSpeed = 5f;
    [Tooltip("Player movement speed")]
    [SerializeField] float movementSpeed;
    [Tooltip("Player sprinting speed")]
    [SerializeField] private float sprinting_speed;
    [Tooltip("Player value switch between regulart and sprinting speed")]
    [SerializeField] private float speedToUse;
    private HealthSystem healthSystem;

    void Start()
    {
     
        healthSystem = GetComponent<HealthSystem>();
        //start with normal speed
        speedToUse = movementSpeed;
        //sprinting speed is double the normal speed.
        sprinting_speed = movementSpeed * 2;
        //animator for the player model
        animator = GetComponentInChildren<Animator>();
        //controller for momvement
        characterController = GetComponent<CharacterController>();
    }
    void Update(){
            Vector3 temp = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            temp.Normalize();
            float velocityZ = Vector3.Dot(temp.normalized, transform.forward);
            float velocityX = Vector3.Dot(temp.normalized, transform.right);
            animator.SetFloat("velocityZ", velocityZ,0.1f,Time.deltaTime);
            animator.SetFloat("velocityX", velocityX,0.1f,Time.deltaTime);
    }
    void FixedUpdate()
    {
        //only move if you're not dead.
        if (healthSystem.currentHealth > 0)
        {
            var xAxisMouse = Input.GetAxis("Mouse X");
            var zAxis = Input.GetAxis("Vertical");
            var xShuffle = Input.GetAxis("Horizontal");
            var movmentVector = new Vector3(0f,0f,0f);
            if( xAxisMouse != 0){
                movmentVector = new Vector3(xAxisMouse, 0, zAxis);
            }else if( xShuffle != 0 ){
                movmentVector = new Vector3(xShuffle,0,zAxis);
            }else if( zAxis != 0){
                movmentVector = new Vector3(0,0,zAxis);
            }
            animator.SetFloat("speed", movmentVector.magnitude);
            //used for AD movment but it didn't work well.
            characterController.SimpleMove(xShuffle * transform.right * speedToUse);
            //rotate with mouse
            transform.Rotate(Vector3.up, xAxisMouse * rotationSpeed * Time.deltaTime);
            if (xAxisMouse != 0 && zAxis == 0)
            {
                animator.SetBool("rotating", true);
            }
            else
            {
                if (animator.GetBool("rotating") == true)
                {
                    animator.SetBool("rotating", false);
                }
            }          
            characterController.SimpleMove(transform.forward * speedToUse * zAxis);       
            //this is to sprint when holding leftshift.
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
