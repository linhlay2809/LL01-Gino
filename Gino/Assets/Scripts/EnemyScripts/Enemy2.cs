using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Animator anim;

    public Rigidbody2D r2;

    public Collider2D enemyAttack;
    public Collider2D enemyAttackR;
    public GameObject cone1;
    public GameObject cone2;

    public GameObject enemyDeathEF;

    public float speed = 50f, maxSpeed = 3f;
    public bool faceRight = true;

    public bool isLeft1;
    public bool isTrigger;

    public bool attacking = false;

    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Walk", Mathf.Abs(r2.velocity.x));

        
    }
    void FixedUpdate()
    {
        r2.velocity = new Vector2(r2.velocity.x * 0.7f, r2.velocity.y);
        if (isLeft1 == true && isTrigger == true)
        {
            r2.AddForce(-(Vector2.right) * speed);
        }
        if (isLeft1 == false && isTrigger == true)
        {
            r2.AddForce((Vector2.right) * speed);
        }
        // Trả giá trị lực đẩy về maxSpeed khi vượt quá maxSpeed--------
        if (r2.velocity.x > maxSpeed)
        {
            r2.velocity = new Vector2(maxSpeed, r2.velocity.y);
        }
        if (r2.velocity.x < -maxSpeed)
        {
            r2.velocity = new Vector2(-maxSpeed, r2.velocity.y);
        }
        
        if (Health <= 0)
        {
            Destroy(gameObject);
            GameObject clone = Instantiate(enemyDeathEF, transform.position, transform.rotation);
            Destroy(clone, 0.5f);
        }
    }
    public void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    public void Attack(bool attackLeft)
    {
        // Kich hoạt tấn công bến trái
        if (attackLeft)
        {
            isLeft1 = true;
        }
        // Kich hoạt tấn công bến phải
        if (!attackLeft)
        {
            isLeft1 = false;
        }
    }
}
