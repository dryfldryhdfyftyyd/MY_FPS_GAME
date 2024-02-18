using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    public float speed = 5;
    public float gravity;
    public float jumpheight = 3;

    public Transform groundCheckPos;
    public LayerMask groundMask;

    private CharacterController controller;
    private bool isGrounded = false;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheckPos.position, 0.4f, groundMask);

        if(isGrounded && velocity.y <0) velocity.y = 0;

        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        var move = transform.right * x + transform.forward * y;

        controller.Move(move * speed * Time.deltaTime);

        //Jump
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2 * gravity);
        }



        //Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
