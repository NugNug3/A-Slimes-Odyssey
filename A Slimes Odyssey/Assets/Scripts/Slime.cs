using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{

    [SerializeField] float speed = 1f;
    [SerializeField] float jumpForce = 20;

    public enum MovementType { transforming, physics };

    [SerializeField] MovementType movementType = MovementType.transforming;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveSlime(Vector3 direction)
    {
        Vector3 currentVelocity = new Vector3(0, rigidBody.velocity.y, 0);
        rigidBody.velocity = (currentVelocity) + (direction * speed);
    }

    public void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

}
