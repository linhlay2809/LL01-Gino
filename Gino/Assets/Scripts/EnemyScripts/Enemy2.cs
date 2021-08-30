using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D r2;

    [Space(10)]
    public GameObject target;

    [Space(10)]
    public Collider2D enemyAttack;
    public GameObject cone;
    public GameObject enemyDeathEF;
    
    [Space(10)]
    public float speed = 50f, maxSpeed = 3f;
    public float delay = 0.2f, returnDelay = 0.2f;
    public bool isTrigger;
    public bool attacking = false;

    Vector3 scale;
    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        anim = gameObject.GetComponent<Animator>();
        r2 = gameObject.GetComponent<Rigidbody2D>();
        enemyAttack.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Walk", Mathf.Abs(r2.velocity.x));
        if (attacking)
        {
            anim.SetBool("Attack", true);
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                // Delay attack
                enemyAttack.enabled = true;
                StartCoroutine(DelayAtack());
            }
            StartCoroutine(CountDown());
        }
        
    }
    void FixedUpdate()
    {
        r2.velocity = new Vector2(r2.velocity.x * 0.9f, r2.velocity.y);
        if (target.transform.position.x < gameObject.transform.position.x)
        {
            if (isTrigger == true)
            {
                r2.AddForce((Vector2.right) * -speed);
            }
            scale.x = -1;
            transform.localScale = scale;
        }
        else
        {
            if (isTrigger == true)
            {
                r2.AddForce((Vector2.right) * speed);
            }
            scale.x = 1;
            transform.localScale = scale;
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
            FindObjectOfType<SoundManager>().Play("EnemyDie");
            Destroy(gameObject);
            GameObject clone = Instantiate(enemyDeathEF, transform.position, transform.rotation);
            Destroy(clone, 0.5f);
        }
    }
    void Damage(int damage)
    {
        Health -= damage;
        gameObject.GetComponent<Animation>().Play("Enemy2_TakeDmg");
    }
    // Thời gian chờ tấn công của enemy
    IEnumerator DelayAtack()
    {
        yield return new WaitForSeconds(0.1f);
        enemyAttack.enabled = false;
        yield return new WaitForSeconds(0.4f);
        anim.SetBool("Attack", false);
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);
        cone.SetActive(true);
    }
    public void Attack()
    {
        attacking = true;
        FindObjectOfType<SoundManager>().Play("Enemy2Attack");
    }

}
