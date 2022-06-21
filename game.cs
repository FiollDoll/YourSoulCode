using System.Collections;
using UnityEngine;

public class game : MonoBehaviour
{
    public int mode; //Текущий режим

    public void modeDef()
    {
        mode = 0;
        PlayerPrefs.SetInt("mode", mode);
    }
    public void modeEvents()
    {
        mode = 1;
        PlayerPrefs.SetInt("mode", mode);
    }
    void Start()
    {
        mode = PlayerPrefs.GetInt("mode");
    }
}
