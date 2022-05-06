using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoScene : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
    public void Shop()
    {
        SceneManager.LoadScene(2);
    }
    public void Option()
    {
        SceneManager.LoadScene(3);
    }
    public void Game()
    {
        SceneManager.LoadScene(4);
    }
}
