using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Range(5,50)]
    public float jumpSpeed = 50f;
    [Range(5,50)]
    public float fallSpeed = 30f;
    [Range(5,50)]
    public float forwardSpeed = 10f;
    Rigidbody rb;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Controller Starting Up!");

        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown) Jump();

    }
    void FixedUpdate() {
        Debug.Log("Fixed Update frame time = " + Time.deltaTime);

        rb.AddRelativeForce(Vector3.right * forwardSpeed);

        if(isGrounded == false) {
            rb.AddRelativeForce(Vector3.down * fallSpeed);
        }
    }
    void Jump() {
        if(isGrounded) {
               rb.AddRelativeForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        isGrounded = false;

        }
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
