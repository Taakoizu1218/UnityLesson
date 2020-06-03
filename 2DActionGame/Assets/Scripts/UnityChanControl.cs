using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class UnityChanControl : MonoBehaviour
{
    Rigidbody2D rigidbody = null;
    [SerializeField] float movePower = 50.0f;
    [SerializeField] float JumpPower = 10.0f;
    [SerializeField] float MaxSpeed = 3.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        int key=0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
            rigidbody.AddForce(Vector2.right * movePower);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
            rigidbody.AddForce(Vector2.left * movePower);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }

        //if (Mathf.Abs(rigidbody.velocity.x) > MaxSpeed)
        //{
            
        //    var Velocity = rigidbody.velocity;
        //    Velocity.x = MaxSpeed * key;
        //    rigidbody.velocity = Velocity;
        //}

    }
}
