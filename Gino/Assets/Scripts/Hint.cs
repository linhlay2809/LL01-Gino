using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hint : MonoBehaviour
{
    public Animator anim;
    // Hiện chuỗi ký tự nhập vào lên Text
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            Time.timeScale = 0f;
            anim.SetBool("Show", true);
        }
    }    
    public void CloseHint()
    {
        Time.timeScale = 1f;
        anim.SetBool("Show", false);
        Destroy(gameObject);
    }

}
