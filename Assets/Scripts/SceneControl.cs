using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneControl : MonoBehaviour
{
    public void NextScene0()
    {
        SceneManager.LoadScene(1);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(2);
    
    }

    public void NextScene1()
    {
        SceneManager.LoadScene(3);
    }

    public void NextScene2()
    {
        SceneManager.LoadScene(4);
    }
}