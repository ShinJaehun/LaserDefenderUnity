using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] float sceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;

    void Awake() 
    {
        // scoreKeeper = FindObjectOfType<ScoreKeeper>();
        // 원래 이 코드가 맞는데 LoadGame()에서 scoreKeeper를 찾을 수 없어서
        // null exception이 계속 발생했음. 그래서 여기서 지우고
        // LoadGame()할 때마다 호출하는 식으로 수정함.
    }

    public void LoadGame()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    

        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
