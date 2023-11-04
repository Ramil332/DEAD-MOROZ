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

    void Start()
    {
        
    }

    void Update()
    {
        transform.Tra
    }
}
