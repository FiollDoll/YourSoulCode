using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMain : MonoBehaviour
{
    [Header("Pages")]
    [SerializeField] private GameObject pageToSkin;
    [SerializeField] private GameObject pageToPlayer;

    [Header("Skins")]
    [SerializeField] private string nameSkin;
    [SerializeField] private Text nameSkinText;
    [SerializeField] private int[] _skinCharacter = new int[2]; //0 - не имеется. Злой дух, чучело
    [SerializeField] private int[] _skinCharacter1 = new int[2]; //0 - не имеется. 
    
    [Header("Money")]
    public int money;
    public Text moneyText;
    public int diamond;
    public Text diamondText;
    [Header("Other")]
    private int TotalPageSkin;
    // Получение из скрипта
    private fragments _script;
    [SerializeField] private Text fragmentText;
    
    private void Start()
    {
        _script = GetComponent<fragments>();
        money = PlayerPrefs.GetInt("money");

        nameSkin = "Злой дух";
        for (int i = 0; i < 2; i++)
        {
            string strI = "skinCharacter" + i.ToString();
            string strI1 = "skinCharacter1" + i.ToString();
            _skinCharacter[i] = PlayerPrefs.GetInt(strI);
            _skinCharacter1[i] = PlayerPrefs.GetInt(strI1);
        }
    }

    // Включение страницы
    public void pageSkin()
    {
        pageToSkin.gameObject.SetActive(true);
        pageToPlayer.gameObject.SetActive(false);
    }
    public void pagePlayer()
    {
        pageToSkin.gameObject.SetActive(false);
        pageToPlayer.gameObject.SetActive(true);
    }

    public void pageUp()
    {
        TotalPageSkin++;
        skinChanger(TotalPageSkin);
    }
    public void pageDown()
    {
        TotalPageSkin--;
        skinChanger(TotalPageSkin);
    }

    // Информация о скине
    private void skinInfo(string name)
    {
        nameSkin = name;
    }
    private void skinChanger(int num) // Сделать смену спрайтов
    {
        if (num == 0)
        {
            skinInfo("Злой дух");
        }
       if (num == 1)
        {
            skinInfo("Чучело");
        }        
    }
    private void Update()
    {
        fragmentText.text = _script.fragmentOwn[TotalPageSkin].ToString();
        money = PlayerPrefs.GetInt("money");
        moneyText.text = money.ToString();
        diamondText.text = diamond.ToString();
        nameSkinText.text = nameSkin;
    }
}
