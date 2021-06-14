using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Animator anim;

    public Collider2D enemyAttack;
    public Collider2D enemyAttackR;
    public GameObject cone1;
    public GameObject cone2;

    private SoundManager sound;

    public GameObject enemyDeathEF;

    private bool isLeft1;

    public bool attacking = false;

    public float delay = 0.7f, returnDelay = 0.7f;
    public int Health = 100;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        enemyAttack.enabled = false;
        enemyAttackR.enabled = false;
        anim = gameObject.GetComponent<Animator>();
        sound = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tấn công bên trái
        if (isLeft1 == true)
        {
            
            if (attacking)
            {
                if (delay > 0)
                {
                    delay -= Time.deltaTime;
                }
                else
                {
                    attacking = false;
                    enemyAttack.enabled = true;
                    StartCoroutine(DelayAtack());
                }

            }
            anim.SetBool("Attack", attacking);
        }
        // Tấn công bên phải
        if (isLeft1 == false)
        {
            
            if (attacking)
            {
                if (delay > 0)
                {
                    delay -= Time.deltaTime;
                }
                else
                {
                    // Delay attack
                    attacking = false;
                    enemyAttackR.enabled = true;
                    StartCoroutine(DelayAtack());
                }

            }
            anim.SetBool("Attack", attacking);
        }
        // Enemy Death
        if (Health <= 0)
        {
            sound.audioSource.Stop();
            Destroy(gameObject);
            GameObject clone = Instantiate(enemyDeathEF, transform.position, transform.rotation);
            Destroy(clone, 0.5f);
        }
    }
    // Nhận sát thương từ damage truyền vào
    void Damage(int damage)
    {
        Health -= damage;
        gameObject.GetComponent<Animation>().Play("TakeDamage");
    }
    // Thời gian chờ tấn công của enemy
    IEnumerator DelayAtack()
    {
        yield return new WaitForSeconds(0.2f);
        enemyAttack.enabled = false;
        enemyAttackR.enabled = false;
    }
    public void Attack(bool attackLeft)
    {
        // Kich hoạt tấn công bến trái
        if (attackLeft)
        {
            sound.PlaySound("enemy1Attack");
            attacking = true;
            delay = returnDelay;
            isLeft1 = true;
            StartCoroutine(CountDown());
        }
        // Kich hoạt tấn công bến phải
        if (!attackLeft)
        {
            sound.PlaySound("enemy1Attack");
            attacking = true;
            delay = returnDelay;
            isLeft1 = false;
            StartCoroutine(CountDown2());
        }
    }
    
    // Active LeftCone sau thời gian chờ
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(1f);
        cone1.SetActive(true);
    }
    // Active RightCone sau thời gian chờ
    IEnumerator CountDown2()
    {
        yield return new WaitForSeconds(1f);
        cone2.SetActive(true);
    }
}
