using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    public GameObject Play;
    public GameObject pageUp;
    [Header("Money")]
    public int money;
    public Text moneyText;
    public int diamond;
    public Text diamondText;

    [Header("Stats")]
    public int speed;
    public int hp;
    public int Jumpp;
    void Start()
    {
        hp = PlayerPrefs.GetInt("hp");
        speed = PlayerPrefs.GetInt("speed");
        Jumpp = PlayerPrefs.GetInt("jumpp");
        money = PlayerPrefs.GetInt("money");
    }
    public void page()
    {
        pageUp.gameObject.SetActive(true);
    }
    void Update()
    {
        money = Play.GetComponent<Stats>().money; //Получение из другого скрипта
        moneyText.text = money.ToString();
        diamondText.text = diamond.ToString();
    }
}
