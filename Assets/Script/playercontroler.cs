using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class playercontroler : MonoBehaviour
{


    [Header("References")]
    public Camera playercam;

    [Header ("General")]
    public float walkspeed = 5f;
    public float run = 10f;
    public float jump = 2f;
    public float gravityScale = -20f;
    private float Hp;

    [Header("Rotation")]
    public float rotationSensibility = 10f;
    private float camVerticalangle;

    Vector3 moveInput = Vector3.zero;
    Vector3 rotationimput = Vector3.zero;
    CharacterController characterController;


    public void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Move()
    {
        if (characterController.isGrounded)
        {
           moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            if (Input.GetButtonDown("Debug Multiplier"))
            {
               moveInput = transform.TransformDirection(moveInput) * run;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * walkspeed;
            }
         
            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jump * -2 * gravityScale);
            }
        }

        moveInput.y += gravityScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

     private void look()
    {
        rotationimput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
        rotationimput.y = Input.GetAxis("Mouse Y") * rotationSensibility * Time.deltaTime;

        camVerticalangle = camVerticalangle + rotationimput.y;
        camVerticalangle = Mathf.Clamp(camVerticalangle, -70, 70);
        transform.Rotate(Vector3.up * rotationimput.x);
        playercam.transform.localRotation = Quaternion.Euler(-camVerticalangle, 0f, 0f);
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bot"))
        {
            Debug.Log("daño");
            Hp =Hp - 5;
            if (Hp <= 0)
            {
               
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bot"))
        {
            Hp =Hp - 5;
            if(Hp <= 0)
            {
              
            }
        }

    }*/
    void Update()
    {
        Move();
        look();
        if(Hp <= 1)
        {
            Cursor.lockState = CursorLockMode.None; Cursor.visible = false;
        }
    }
    private void Start()
    {
        Hp = 100f;
        Cursor.lockState = CursorLockMode.Locked;
        
        
    }
}
