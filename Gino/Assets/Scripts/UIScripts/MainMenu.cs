using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Animator guiAnim;
    public float transitionTime = 1f;
    public AudioSource audioS;
    public float musicVolume;
    private void Start()
    {
        guiAnim = GameObject.FindGameObjectWithTag("GUI").GetComponent<Animator>();
    }
    private void Update()
    {
        audioS.volume = musicVolume;
    }
    // Dung de chuyen scene vao playgame
    public void PlayGame()
    {
        StartCoroutine(NextMenu(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public IEnumerator NextMenu(int levelIndex)
    {
        guiAnim.SetBool("End", true);
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

    // Dung de thoat khoi game
    public void QuitGame()
    {
        StartCoroutine(QuitMenu());
        Application.Quit();
    }
    public IEnumerator QuitMenu()
    {
        guiAnim.SetBool("End", true);
        yield return new WaitForSeconds(0.3f);
        
    }
    public void Volume(float volume)
    {
        musicVolume = volume;
    }

}
