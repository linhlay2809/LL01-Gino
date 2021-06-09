using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool IsPaused = false;
    public Animator transition;
    private float transitionTime = 0.5f;
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
        transition.SetBool("Pause", false);
        yield return new WaitForSeconds(transitionTime);
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
        transition.SetBool("Pause", true);
        yield return new WaitForSeconds(0.3f);
    }
    // RestartGame khi click vao nut restart trên màn hình PauseUI
    public void RestartGame()
    {
        StartCoroutine(Restart(SceneManager.GetActiveScene().buildIndex));
        Time.timeScale = 1f;
    }
    public IEnumerator Restart(int level)
    {
        transition.SetBool("Restart", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
    // Quay về MainMenu khi click vao nut mainmenu trên màn hình PauseUI
    public void MainMenuGame()
    {
        StartCoroutine(Restart(SceneManager.GetActiveScene().buildIndex - 1));
        Time.timeScale = 1f;
    }
    public void MainMenuGame2()
    {
        StartCoroutine(Restart(SceneManager.GetActiveScene().buildIndex - 2));
        Time.timeScale = 1f;
    }

}
