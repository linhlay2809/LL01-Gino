using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone1 : MonoBehaviour
{
    private Enemy1 enemyAI;
    public bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = gameObject.GetComponentInParent<Enemy1>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false && col.CompareTag("Player"))
        {
            if (isLeft)
            {
                enemyAI.Attack(true);
                gameObject.SetActive(false);
            }
            if (!isLeft)
            {
                enemyAI.Attack(false);
                gameObject.SetActive(false);
            }
        }
    }
}
