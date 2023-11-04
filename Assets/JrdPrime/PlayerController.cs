using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;

    [SerializeField] float speed = 12;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] float JumpHeigh = 3;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundDist = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    float x;
    float z;

    public float turnSpeed = 5f;
    public float horizontalInput;
    public float vertInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed* horizontalInput * -1);
        transform.Translate(Vector3.right * Time.deltaTime * turnSpeed  * vertInput);

    }
}
