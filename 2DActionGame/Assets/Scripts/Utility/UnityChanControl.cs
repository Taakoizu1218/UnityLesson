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

    Animator animator = null;

    Vector3 Startpos;
    float gravity;
    bool LiftFlg = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        gravity = rigidbody.gravityScale;
        Startpos = gameObject.transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int key = 0;
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

        //梯子の処理
        if (Input.GetKey(KeyCode.UpArrow) && LiftFlg)
        {
            rigidbody.MovePosition(rigidbody.position + new Vector2(0.0f, 0.1f));
        }
        if (Input.GetKey(KeyCode.DownArrow) && LiftFlg)
        {
            rigidbody.MovePosition(rigidbody.position + new Vector2(0.0f, -0.1f));
        }


        var VelocityX = Mathf.Abs(rigidbody.velocity.x);
        if (VelocityX > MaxSpeed)
        {

            var Velocity = rigidbody.velocity;
            Velocity.x = MaxSpeed * key;
            rigidbody.velocity = Velocity;
        }
        if (key != 0)
        {
            var scale = transform.localScale;
            scale.x = key;
            transform.localScale = scale;
        }

        animator.speed = VelocityX / MaxSpeed;
    }
    public void GameOver()
    {
        gameObject.SetActive(false);
    }
    public void Restart()
    {
        gameObject.transform.position =Startpos;
        gameObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var Tag = collision.tag;
        Debug.Log(Tag);
        if (Tag == "Damage")
        {
            GameManager.Instance.gameOver();
        }

        if (Tag == "Lift")
        {
            LiftFlg = true;
            rigidbody.gravityScale = 0.0f;
            rigidbody.velocity = Vector2.zero;
        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        var Tag = collision.tag;
        if (Tag == "Lift")
        {
            LiftFlg = false;
            rigidbody.gravityScale = gravity;
        }
    }

}
