using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 20;
    [SerializeField] private GameObject attaclEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Truyền lượng damage vào đối tượng tag Enemy
        if(collision.isTrigger != true&& collision.CompareTag("Enemy"))
        {
            FindObjectOfType<SoundManager>().Play("Hit");
            collision.SendMessageUpwards("Damage", dmg);
            GameObject clone = Instantiate(attaclEffect, collision.transform.position, transform.rotation);
            Destroy(clone, 0.5f);
        }
    }
}
