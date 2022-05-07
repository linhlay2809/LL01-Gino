using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hint : MonoBehaviour
{
    public Animator anim;
    public GameObject pressEnter;
    public bool isSpace = false;
    // Hiện chuỗi ký tự nhập vào lên Text
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false)
        {
            anim.SetBool("Show", true);
            StartCoroutine(EnterDelay());
        }
    }
    protected void Update()
    {
        if (isSpace)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                anim.SetBool("Show", false);
                this.gameObject.SetActive(false);
            }
        }
    }
    IEnumerator EnterDelay()
    {
        yield return new WaitForSeconds(3f);
        pressEnter.SetActive(true);
        isSpace = true;
    }

    public void CloseHint()
    {
        Time.timeScale = 1f;
        anim.SetBool("Show", false);
        Destroy(gameObject);
    }

}
