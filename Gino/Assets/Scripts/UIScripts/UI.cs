using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class UI : MonoBehaviour
{
    public Animator anim;
    public Animator guiAnim;
    GameMaster gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        guiAnim = GameObject.FindGameObjectWithTag("GUI").GetComponent<Animator>();
        anim = gameObject.GetComponent<Animator>();
    }
    // RestartGame khi click vao nut restart trên màn hình PauseUI
    public void RestartGame()
    {
        StartCoroutine(Restart(SceneManager.GetActiveScene().buildIndex));
        Time.timeScale = 1f;
    }
    IEnumerator Restart(int level)
    {
        guiAnim.SetBool("End", true);
        anim.SetBool("Restart", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
    
    // Quay về MainMenu khi click vao nut mainmenu trên màn hình PauseUI
    public void MainMenuGame()
    {
        StartCoroutine(MainMenu());
        Time.timeScale = 1f;
    }
    IEnumerator MainMenu()
    {
        guiAnim.SetBool("End", true);
        anim.SetBool("Menu", true);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu");
    }
    public void NextLevel()
    {
        StartCoroutine(NextLevelTime(SceneManager.GetActiveScene().buildIndex + 1));
        Time.timeScale = 1f;
    }
    IEnumerator NextLevelTime(int level)
    {
        guiAnim.SetBool("End", true);
        anim.SetBool("NextLevel", false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
    public void SaveData()
    {
        UnitData dt = new UnitData();
        dt.knife = gm.amountKnife;
        string json = JsonUtility.ToJson(dt);
        Debug.Log(json);
        File.WriteAllText(Application.dataPath + "/saveFile.json", json);
    }
}
