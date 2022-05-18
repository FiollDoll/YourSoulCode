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
    [SerializeField] private Text[] moneyTextToBuy = new Text[2];
    [SerializeField] private Text moneyTextToBuyHave;
    [SerializeField] private int price;

    [Header("Other")]
    private int TotalPageSkin;
    // Получение из скрипта
    private fragments _script;
    [SerializeField] private Text fragmentText;
    [SerializeField] private Text fragmentTextToBuy;
    [SerializeField] private GameObject panelBuy;
    [SerializeField] private GameObject player; //Спрайт игрока
    [SerializeField] private Sprite[] spritesSkin = new Sprite[1];
    
    private void Start()
    {
        _script = GetComponent<fragments>();
        money = PlayerPrefs.GetInt("money");

        skinChanger(0);
        for (int i = 0; i < 2; i++)
        {
            string strI = "skinCharacter" + i.ToString();
            string strI1 = "skinCharacter1" + i.ToString();
            _skinCharacter[i] = PlayerPrefs.GetInt(strI);
            _skinCharacter1[i] = PlayerPrefs.GetInt(strI1);
        }
    }



//Скины
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

    //Следующая и предыдующая страница
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

    //Открытие менюшки и закрытие
    public void panelBuyOn()
    {
        panelBuy.gameObject.SetActive(true);
    }
    public void panelBuyOff()
    {
        panelBuy.gameObject.SetActive(false);
    }

    // Информация о скине
    private void skinInfo(string name, int moneyPrice)
    {
        nameSkin = name;
        price = moneyPrice;
    }
    private void skinChanger(int num) // Сделать смену спрайтов
    {
        if (num == 0)
        {
            player.GetComponent<Image>().sprite = spritesSkin[0];
            skinInfo("Злой дух", 200);
        }
       if (num == 1)
        {
            player.GetComponent<Image>().sprite = spritesSkin[1];
            skinInfo("Чучело", 300);
        }        
    }
    private void Update()
    {
        fragmentText.text = _script.fragmentOwn[TotalPageSkin].ToString();
        fragmentTextToBuy.text = _script.fragmentOwn[TotalPageSkin].ToString();
        nameSkinText.text = nameSkin;

        money = PlayerPrefs.GetInt("money");
        moneyText.text = money.ToString();
        moneyTextToBuyHave.text = money.ToString();
        moneyTextToBuy[0].text = price.ToString();
        moneyTextToBuy[1].text = price.ToString();
        
    }
}
