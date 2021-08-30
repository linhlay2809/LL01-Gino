using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public Animator anim;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TheEnd();
    }
    public void TheEnd()
    {
        anim.SetBool("End", true);
        StartCoroutine(DelayEnd());
    }
    IEnumerator DelayEnd()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
