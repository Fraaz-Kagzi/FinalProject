using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust as needed
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask solidObjects;
    public Camera mainCamera;
    private Vector2 input;

    Vector2 movement;

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Animation
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        var targetPos = transform.position;
        targetPos.x += input.x;
        targetPos.y += input.y;
        // Movement
        if (isWalkable(targetPos))
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Camera Follow
        Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, 0.1f);
    }

    public bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.2f, solidObjects)!= null)
        {
            return false;
        }
        return true;
    }
}

