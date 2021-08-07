using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    [Header("Condition Attack")]
    public bool throwAttacking = false;
    public bool attacking = false;

    [Header("Knife")]
    public GameObject knife;
    public Transform spawnKnife;

    [Header("Attack Trigger")]
    public Collider2D trigger;
    public Collider2D triggerB;
    public Collider2D triggerC;
    public Collider2D triggerD;

    private GameMaster gm;

    public static PlayerAttack instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        trigger.enabled = false;
        triggerB.enabled = false;
        triggerC.enabled = false;
        triggerD.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Player Attack
        if (Input.GetKeyDown(KeyCode.J) && !attacking)
        {
            attacking = true;
        }
        // Player throwAttack
        if (Input.GetKeyDown(KeyCode.K) && !throwAttacking)
        {
            if(gm.amountKnife > 0)
            {
                gm.amountKnife -= 1;
                throwAttacking = true;
            }    
        }
    }
    public void ThrowKnife()
    {
        FindObjectOfType<SoundManager>().Play("ThrowKnife");
        StartCoroutine(DelayThrow());
    }
    // Thời gian kiếm bắt đầu bay ra
    IEnumerator DelayThrow()
    {
        yield return new WaitForSeconds(0.15f);
        Instantiate(knife, spawnKnife.transform.position, knife.transform.rotation);
    }
    // Attack A ---------------------------------------------
    public void AttackA()
    {
        FindObjectOfType<SoundManager>().Play("Attack");
        StartCoroutine(DelayTriggerA());
    }
    // Bật tắt trigger A khi attack
    IEnumerator DelayTriggerA()
    {
        yield return new WaitForSeconds(0.1f);
        trigger.enabled = true;
        yield return new WaitForSeconds(0.3f);
        trigger.enabled = false;
    }
    // Attack B ---------------------------------------------
    public void AttackB()
    {
        FindObjectOfType<SoundManager>().Play("Attack");
        StartCoroutine(DelayTriggerB());
    }
    // Bật tắt trigger B khi attack
    IEnumerator DelayTriggerB()
    {
        yield return new WaitForSeconds(0.1f);
        triggerB.enabled = true;
        yield return new WaitForSeconds(0.3f);
        triggerB.enabled = false;
    }
    // Attack C ---------------------------------------------
    public void AttackC()
    {
        FindObjectOfType<SoundManager>().Play("Attack");
        StartCoroutine(DelayTriggerC());
    }
    // Bật tắt trigger C khi attack
    IEnumerator DelayTriggerC()
    {
        yield return new WaitForSeconds(0.1f);
        triggerC.enabled = true;
        yield return new WaitForSeconds(0.3f);
        triggerC.enabled = false;
    }
    // Attack D ---------------------------------------------
    public void AttackD()
    {
        FindObjectOfType<SoundManager>().Play("MagicAttack");
        StartCoroutine(DelayTriggerD());
    }
    // Bật tắt trigger D khi attack
    IEnumerator DelayTriggerD()
    {
        yield return new WaitForSeconds(0.4f);
        triggerD.enabled = true;
        yield return new WaitForSeconds(0.6f);
        triggerD.enabled = false;
    }

}
