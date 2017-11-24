using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public bool IsMoving = false;

    private Rigidbody rb;
    private float speed = 8f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        if (IsMoving)
        {
            rb.velocity = this.transform.forward * speed;
        }
        else
        {
            rb.Sleep();
            this.transform.position = new Vector3(
                this.transform.position.x, 11.65f, this.transform.position.z);
        }

        MoveControl();
    }

    private void MoveControl()
    {
        if (Input.GetButtonDown("Fire1"))
            IsMoving = !IsMoving;
    }

}
