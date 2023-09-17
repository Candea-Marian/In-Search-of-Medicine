using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float baseSpeed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float sprintSpeed = 5f;

    float speedBoost = 1f;
    Vector3 velocity;

    // Camera transition variables
    public Transform tableCameraTarget;
    Vector3 targetPosition;
    Quaternion targetRotation;
    bool isCameraTransitioning = false;
    float transitionDuration = 1f;
    float transitionStartTime;

    void Start()
    {

    }

    void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (Input.GetButton("Fire3"))
            speedBoost = sprintSpeed;
        else
            speedBoost = 1f;

        Vector3 move = transform.right * x + transform.forward * z;

        // Disable player movement during camera transition
        if (!isCameraTransitioning)
        {
            controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            // Handle mouse click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is the table
                if (hit.collider.gameObject.CompareTag("Table"))
                {
                    // Call the function to initiate the camera transition to the table target position
                    SmoothCameraTransitionToTable(tableCameraTarget.position);
                }
            }
        }

        if (isCameraTransitioning)
        {
            // Perform camera transition
            float transitionProgress = (Time.time - transitionStartTime) / transitionDuration;

            if (transitionProgress < 1f)
            {
                // Smoothly move the camera towards the target position
                transform.position = Vector3.Lerp(transform.position, targetPosition, transitionProgress);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, transitionProgress);
            }
            else
            {
                // Camera transition complete
                isCameraTransitioning = false;
            }
        }
    }

    void SmoothCameraTransitionToTable(Vector3 desiredPosition)
    {
        // Disable player movement during camera transition
        isCameraTransitioning = true;

        // Set the target position and rotation for the camera
        targetPosition = desiredPosition;
        targetRotation = Quaternion.LookRotation(transform.position - targetPosition, Vector3.up);

        // Start the camera transition
        transitionStartTime = Time.time;
    }
}



// // Disable player movement during camera transition
        // if (!isCameraTransitioning)
        // {
        //     controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);
        // }
// if (Input.GetMouseButtonDown(0))
        // {
        //     // Handle mouse click
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     RaycastHit hit;
        //     if (Physics.Raycast(ray, out hit))
        //     {
        //         // Check if the clicked object is the table
        //         if (hit.collider.gameObject.CompareTag("Table"))
        //         {
        //             // Call the function to initiate the camera transition to the table target position
        //             SmoothCameraTransitionToTable(tableCameraTarget.position);
        //         }
        //     }
        // }

        // if (isCameraTransitioning)
        // {
        //     // Perform camera transition
        //     float transitionProgress = (Time.time - transitionStartTime) / transitionDuration;

        //     if (transitionProgress < 1f)
        //     {
        //         // Smoothly move the camera towards the target position
        //         transform.position = Vector3.Lerp(transform.position, targetPosition, transitionProgress);
        //         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, transitionProgress);
        //     }
        //     else
        //     {
        //         // Camera transition complete
        //         isCameraTransitioning = false;
        //     }
        // }

// void SmoothCameraTransitionToTable(Vector3 desiredPosition)
    // {
    //     // Disable player movement during camera transition
    //     isCameraTransitioning = true;

    //     // Set the target position and rotation for the camera
    //     targetPosition = desiredPosition;
    //     targetRotation = Quaternion.LookRotation(transform.position - targetPosition, Vector3.up);

    //     // Start the camera transition
    //     transitionStartTime = Time.time;
    // }


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public CharacterController controller;
//     public float baseSpeed = 12f;
//     public float gravity = -9.81f;
//     public float jumpHeight = 3f;
//     public float sprintSpeed = 5f;

//     float speedBoost = 1f;
//     Vector3 velocity;

//     public Transform tableCameraTarget; // Reference to the empty object representing the camera target
//     Vector3 targetPosition;
//     Quaternion targetRotation;
//     bool isCameraTransitioning = false;
    
//     void Start()
//     {

//     }

//     void Update()
//     {
//         if (controller.isGrounded && velocity.y < 0)
//         {
//             velocity.y = -2f;
//         }

//         float x = Input.GetAxis("Horizontal");
//         float z = Input.GetAxis("Vertical");

//         if (Input.GetButton("Fire3"))
//             speedBoost = sprintSpeed;
//         else
//             speedBoost = 1f;


//         Vector3 move = transform.right * x + transform.forward * z;

//         controller.Move(move * (baseSpeed + speedBoost) * Time.deltaTime);

//         if (Input.GetButtonDown("Jump") && controller.isGrounded)
//         {
//             velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
//         }

//         velocity.y += gravity * Time.deltaTime;

//         controller.Move(velocity * Time.deltaTime);


//         if (Input.GetMouseButtonDown(0))
//         {
//             // Handle mouse click
//             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//             RaycastHit hit;
//             if (Physics.Raycast(ray, out hit))
//             {
//                 // Check if the clicked object is the table
//                 if (hit.collider.gameObject.CompareTag("Table"))
//                 {
//                     // Call a function to initiate the camera transition
//                     SmoothCameraTransitionToTable(tableCameraTarget.position);
//                 }
//             }
//         }

//     }



