using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private GameMaster gm;
    public int sceneIndex;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //Hiện text khi va chạm
            gm.pressEText.text = "Press W To Enter";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Load scene mới
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.W))
            {
                Time.timeScale = 0f;
                anim.SetBool("NextLevel", true);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Xóa text khi rời khỏi va chạm
            gm.pressEText.text = "";
        }
    }
}
