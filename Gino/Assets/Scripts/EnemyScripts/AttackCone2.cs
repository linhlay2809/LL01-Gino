using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone2 : MonoBehaviour
{
    private Enemy2 enemyAI;
    public bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = gameObject.GetComponentInParent<Enemy2>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false && col.CompareTag("Player"))
        {
            if (isLeft)
            {
                enemyAI.isTrigger = true;
                enemyAI.Attack(true);
            }
            if (!isLeft)
            {
                enemyAI.isTrigger = true;
                enemyAI.Attack(false);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.isTrigger == false && col.CompareTag("Player"))
        {
            if (isLeft)
            {
                enemyAI.isTrigger = false;
                enemyAI.Attack(true);
            }
            if (!isLeft)
            {
                enemyAI.isTrigger = false;
                enemyAI.Attack(false);
            }
        }
    }
}
