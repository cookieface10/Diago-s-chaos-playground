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
    public float moveSpeed = 20;
    public float JumpForce;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;
    public float airMultiplier;
    public float airspeed;
    private void MovePlayer()
    {
        moveDirection = Watermelon.forward * VerticalInput + Watermelon.right * HorizontalInput;
        if (GroundCheck())
        {
            uwu.AddForce(moveDirection.normalized * moveSpeed * 10f * 1, ForceMode.Force);
        }
        else if (!GroundCheck())
        {
            uwu.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier * airspeed, ForceMode.Force);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
        if (Input.GetKeyDown("space") && GroundCheck())
        {
            uwu.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
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

    }
    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(Watermelon.position - transform.up * maxDistance, boxSize);
    }*/
    bool GroundCheck()
    {
        if (Physics.BoxCast(transform.position,boxSize,-transform.up,transform.rotation,maxDistance,layerMask))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
