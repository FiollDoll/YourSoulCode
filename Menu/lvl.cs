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
        xp = PlayerPrefs.GetInt("xp");
        totalLvl = PlayerPrefs.GetInt("lvl");
    }

    // Update is called once per frame
    private void Update()
    {
        xpUp();
    }
}
