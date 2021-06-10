﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private Animator anim;

    public Collider2D enemyAttack;
    public Collider2D enemyAttackR;

    public GameObject cone1;
    public GameObject cone2;

    public GameObject enemyDeathEF;

    private SoundManager sound;

    //Kiểm tra dkien bên trái enemy
    private bool isLeft1;

    public bool attacking = false;

    public float delay = 0.6f;
    // Đặt lại thời gian chờ
    public float returnDelay = 0.6f;
    public int Health = 100;
    // Start is called before the first frame update
    void Start()
    {
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
            anim.SetBool("LeftAttack", attacking);
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
                    attacking = false;
                    enemyAttackR.enabled = true;
                    // Delay attack
                    StartCoroutine(DelayAtack());
                }

            }
            anim.SetBool("RightAttack", attacking);
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
        gameObject.GetComponent<Animation>().Play("take");
    }
    // Thời gian chờ tấn công của enemy
    IEnumerator DelayAtack()
    {
        yield return new WaitForSeconds(0.1f);
        enemyAttack.enabled = false;
        enemyAttackR.enabled = false;
    }
    public void Attack(bool attackLeft)
    {
        // Kich hoạt tấn công bến trái
        if (attackLeft)
        {
            sound.PlaySound("enemy3Attack");
            attacking = true;
            delay = returnDelay;
            isLeft1 = true;
            StartCoroutine(CountDown());
        }
        // Kich hoạt tấn công bến phải
        if (!attackLeft)
        {
            sound.PlaySound("enemy3Attack");
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