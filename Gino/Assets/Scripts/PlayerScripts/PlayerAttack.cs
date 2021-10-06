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
                gm.AddKnife(-1);
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

}
