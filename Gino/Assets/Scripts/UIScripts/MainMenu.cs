using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public float transitionTime = 1f;

    private void Start()
    {
    }
    // Dung de chuyen scene vao playgame
    public void PlayGame()
    {
        StartCoroutine(NextMenu(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public IEnumerator NextMenu(int levelIndex)
    {
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
        yield return new WaitForSeconds(0.3f);
        
    }


}
