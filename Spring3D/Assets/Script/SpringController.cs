using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask ground;
    private Rigidbody _mainRb;

    private void Start()
    {
        _mainRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        if (IsGrounded())
        {
            Vector3 moveDir = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
            _mainRb.AddForce(moveDir * force);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

    public void Close()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }
}
