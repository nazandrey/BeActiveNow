using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : SingletonUndestroyable<SceneLoader>
{
    private int lastLevelNum = 1;

    public void LoadFirstLevel()
    {
        LoadScene("Level 1");
    }

    public void LoadChoiceMenu()
    {
        SceneManager.LoadScene("Choice Menu");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
}
