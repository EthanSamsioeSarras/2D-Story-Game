using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementV1 : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private Rigidbody2D rb;
    private SpriteRenderer rend;

    private float horizontalValue;

    private bool canMove;

    void Start()
    {
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {

        horizontalValue = Input.GetAxis("Horizontal");

    }
    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        rb.velocity = new Vector2(horizontalValue * moveSpeed * Time.deltaTime, rb.velocity.y);
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject, 0.5f);
        }
    }*/

}
