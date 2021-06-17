using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCone2 : MonoBehaviour
{
    private Enemy2 enemyAI;
    // Start is called before the first frame update
    void Start()
    {
        enemyAI = gameObject.GetComponentInParent<Enemy2>();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger == false && col.CompareTag("Player"))
        {
            enemyAI.Attack();
            gameObject.SetActive(false);
        }
    }


}
