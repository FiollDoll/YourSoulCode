using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public GameObject Play;
    //Статы
    [Header("Stats")]
    public int speed;
    public int speedPrice;
    public int hp;
    public int hpPrice;
    public int money; //Деньги
    public int Jumpp; //Сила прыжка
    public int JumppPrice;

    
    public Text[] texts = new Text[6]; //hpText, hpPriceText, speedText, speedPriceText, JumpText, JumpPrice text


    void Start()
    {
        speed = Play.GetComponent<ShopMain>().speed; //Получение из другого скрипта
        money = Play.GetComponent<ShopMain>().money; //Получение из другого скрипта
        hp = Play.GetComponent<ShopMain>().hp; //Получение из другого скрипта
        Jumpp = Play.GetComponent<ShopMain>().Jumpp; //Получение из другого скрипта

    }
    public void ShopSpeed()
    {
        if (money >= speedPrice)
        {
            money -= speedPrice;
            speed += 1;
            PlayerPrefs.SetInt("money", money);
        }
    }
    public void ShopHp()
    {
        if (money >= hpPrice)
        {
            money -= hpPrice;
            hp += 1;
            PlayerPrefs.SetInt("money", money);
        }
    }
    public void ShopJump()
    {
        if (money >= JumppPrice)
        {
            money -= JumppPrice;
            Jumpp += 150;
            PlayerPrefs.SetInt("money", money);
        }

    }
    void Update()
    {
        PlayerPrefs.SetInt("hp", hp);
        PlayerPrefs.SetInt("speed", speed);
        PlayerPrefs.SetInt("Jumpp", Jumpp);

        if (hp == 3)
        {
            hpPrice = 10;
        }
        else if (hp == 4)
        {
            hpPrice = 20;
        }
        else if (hp == 5)
        {
            hpPrice = 30;
        }
        else if (hp == 6)
        {
            hpPrice = 40;
        }
        else if (hp == 7)
        {
            hpPrice = 40;
        }
        else if (hp == 8)
        {
            hpPrice = 50;
        }
        else if (hp == 9)
        {
            hpPrice = 55;
        }
        else if (hp == 10)
        {
            hpPrice = 65;
        }
        //Скорость
        if (speed == 5)
        {
            speedPrice = 20;
        }
        else if (speed == 6)
        {
            speedPrice = 30;
        }
        else if (speed == 7)
        {
            speedPrice = 40;
        }
        else if (speed == 8)
        {
            speedPrice = 50;
        }
        if (Jumpp == 1000)
        {
            JumppPrice = 25;
        }
        else if (Jumpp == 1100)
        {
            JumppPrice = 35;
        }
        else if (Jumpp == 1200)
        {
            JumppPrice = 45;
        }
        else if (Jumpp == 1300)
        {
            JumppPrice = 55;
        }
        texts[1].text = hpPrice.ToString();
        texts[3].text = speedPrice.ToString();
        texts[5].text = JumppPrice.ToString();

    }
}
