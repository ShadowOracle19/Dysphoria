using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public GameManager gameManager;

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool coverFace = false;
    
    //UI
    public GameObject panel;
    public GameObject taskPopUp;
    public TextMeshProUGUI taskText;
    public Image timerSprite;

    //Task Timer stuff
    public float timer = 0;
    public float maxTimer = 1;
    public float timerTik = 0.1f;
    public bool mouseHeldDown = false;
    public bool lookingAtTask = false;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Movement();
        timerSprite.fillAmount = timer;
        

        if(Input.GetMouseButtonDown(0))
        {
            mouseHeldDown = true;            
        }
        if(Input.GetMouseButtonUp(0))
        {
            mouseHeldDown = false;
        }

        if (Input.GetMouseButtonDown(1))
        {
            print("hide face");
            panel.SetActive(true);
            coverFace = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            print("Uncover");
            panel.SetActive(false);
            coverFace = false;
        }

    }

    private void FixedUpdate()
    {
        LookAt();
    }

    private void Movement()
    {
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpSpeed;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }

    private void LookAt()
    {
        RaycastHit hit;
        Vector3 p1 = transform.position + characterController.center + Vector3.up * -characterController.height * 0.5f;
        Vector3 p2 = p1 + Vector3.up * characterController.height;

        if (Physics.CapsuleCast(p1, p2, characterController.radius, transform.forward, out hit, 10))
        {
            if (hit.transform.gameObject.CompareTag("Mirror"))
            {
                if (coverFace)
                    return;
                gameManager.dysphoriaLevel += 0.01f;
            }
            else if (hit.transform.gameObject.CompareTag("TaskObject"))
            {
                taskPopUp.SetActive(true);
                taskText.text = hit.transform.gameObject.GetComponent<Task>().taskName;
                lookingAtTask = true;

                if (mouseHeldDown && lookingAtTask)
                {
                    timer += timerTik * Time.deltaTime;
                    if (timer >= maxTimer)
                    {
                        //task done code right here 
                        hit.transform.gameObject.GetComponent<Task>().taskFinished = true; ;
                        print("Task done");
                    }
                }
                else
                {
                    timer = 0;
                }
            }
            else
            {
                taskPopUp.SetActive(false);
                lookingAtTask = false;
            }
        }
        else
        {

            if (!(gameManager.dysphoriaLevel <= 0))
            {
                gameManager.dysphoriaLevel -= 0.01f;
                return;
            }


        }
    }
}