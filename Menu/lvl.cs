using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl : MonoBehaviour
{
    public int totalLvl; // Уровень
    public int xp; // Опыт
    // Start is called before the first frame update
    private void xpUp()
    {
        if (xp >= 1000)
        {
            totalLvl++;
            xp = 0;
            PlayerPrefs.SetInt("lvl", totalLvl);
            PlayerPrefs.SetInt("xp", xp);
        }
    }
    private void Start()
    {
        totalLvl = PlayerPrefs.GetInt("lvl");
        xp = PlayerPrefs.GetInt("xp");
    }

    // Update is called once per frame
    private void Update()
    {
        xpUp();
    }
}