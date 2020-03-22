using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VariableJoystick joystick;
    public float speed = 0.2f;
    public float jumpForce = 100f;

    Rigidbody rb;

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float _x = joystick.Horizontal;
        
        if(rb.velocity.y <= 1.65f)
        {
            rb.AddForce(Vector3.down * Time.deltaTime * 1150f, ForceMode.Acceleration);
        }

        rb.MovePosition(rb.position + (Vector3.right * _x * speed));
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
