using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("LayerMasks")]
    public LayerMask groundMask;
    public Transform offset;
    RaycastHit hit;

    [Header("PlayerJump")]
    public float jumpPower;
    Vector3 jumpPlayer;
    float disFromGround;
    public float currentDisFromGround;
    public bool inAir, doubleJump,groundJump;

    [Header("MovementPlayer")]
    Vector3 movePlayer;
    float ver, hor;
    public float moveSpeed;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            disFromGround = Vector3.Distance(transform.position,CreateDistanceCheck(groundMask).transform.position);
            doubleJump = true;
            groundJump = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        jumpPlayer.y = jumpPower;
        if(Physics.Raycast(offset.position, -transform.up, out hit, Mathf.Infinity, groundMask))
        {
            currentDisFromGround = Vector3.Distance(offset.position,hit.transform.position);
        }
        if(currentDisFromGround > disFromGround)
        {
            inAir = true;
        }
        else
        {
            inAir = false;
        }
        GroundMovement();
        if (Input.GetButtonDown("Jump"))
        {
            if (!inAir && groundJump)
            {
                Jump();
                groundJump = false;
            }
            if(inAir && doubleJump)
            {
                Jump();
                doubleJump = false;
                return;
            }
        }
    }

    public void GroundMovement()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        movePlayer.x = hor;
        movePlayer.z = ver;
        transform.Translate(movePlayer * moveSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        GetComponent<Rigidbody>().velocity += jumpPlayer;
    }

    public RaycastHit CreateDistanceCheck(int layerMask)
    {
        Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity,layerMask);
        return hit;
    }
}
