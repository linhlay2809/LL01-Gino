using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool IsPaused = false;
    public Animator anim;
    private float animTime = 0.5f;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
                PauseGame();
        }
    }
    // Tat pauseUI len man hinh
    public void ResumeGame()
    {
        StartCoroutine(Resume());
        Time.timeScale = 1f;
        IsPaused = false;
    }
    public IEnumerator Resume()
    {
        anim.SetBool("Pause", false);
        yield return new WaitForSeconds(animTime);
    }
    // Hien pauseUI len man hinh
    public void PauseGame()
    {
        StartCoroutine(StartPause());
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public IEnumerator StartPause()
    {
        anim.SetBool("Pause", true);
        yield return new WaitForSeconds(0.3f);
    }

}
