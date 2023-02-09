using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class move : MonoBehaviour
{
    public Transform Watermelon;
    public Rigidbody uwu;
    private Vector3 moveDirection;
    float HorizontalInput;
    float VerticalInput;
    float moveSpeed = 20;
    // Start is called before the first frame update
    void Start()
    {

    }
    //Func for moving player
    private void MovePlayer()
    {
        moveDirection = Watermelon.forward * VerticalInput + Watermelon.right * HorizontalInput;
        uwu.AddForce(moveDirection.normalized * moveSpeed * 10f * 1, ForceMode.Force);
    }
    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(uwu.velocity.x, 0f, uwu.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            uwu.velocity = new Vector3(limitedVel.x, uwu.velocity.y, limitedVel.z);
        }
    }
    private void MyInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        MovePlayer();
        //if (Input.GetKeyDown("w"))
        //{
            //Watermelon.position = new Vector3(Input.GetAxis("Horizontal"),Watermelon.position.y, Input.GetAxis("Vertical")) * 2;
        //}
    }
}
