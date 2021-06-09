using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeMove : MonoBehaviour
{
    public float speed = 40;
    public int damage = 30;

    public GameObject knifeEffect;
    Vector2 velocity;

    private PlayerController player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        velocity = new Vector2(speed * Time.deltaTime, 0);
    }
    void Start()
    {
        if(player.faceRight == true)
        {
            velocity = new Vector2(speed * 1 * Time.deltaTime, 0);
        }
        else
        {
            transform.localScale = player.transform.localScale;
            velocity = new Vector2(speed * -1 * Time.deltaTime, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.SendMessageUpwards("Damage", damage);
            GameObject clone = Instantiate(knifeEffect, transform.position, transform.rotation);
            Destroy(clone, 0.4f);
            Destroy(gameObject);
        }
        if (col.CompareTag("Ground"))
        {
            GameObject clone = Instantiate(knifeEffect, transform.position, transform.rotation);
            Destroy(clone, 0.4f);
            Destroy(gameObject);
        }
    }
}
