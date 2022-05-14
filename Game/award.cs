using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class award : MonoBehaviour
{
    //Панель
    [Header("Panel")]
    [SerializeField] private GameObject _panelAward;
    [SerializeField] private Text[] awardText = new Text[3]; //Фрагмент, деньги, опыт

    //Награды
    [Header("Fragments")]
    [SerializeField] private int[] _fragmentOwn = new int[2]; //Сколько уже есть
    [SerializeField] private int _fragmentTotal;
    [SerializeField] private string _fragment;
    [SerializeField] private int _fragmentInt;
    
    //Имеется скин или нет
    
    [Header("SkinOwn")]
    //Разные персонажи
    [SerializeField] private int[] _skinCharacter = new int[2]; //0 - не имеется. Злой дух, чучело
    [SerializeField] private int[] _skinCharacter1 = new int[2]; //0 - не имеется. 
    public int xp;
    public int moneyGame;

    public bool awardFinish;


    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            string strI = "skinCharacter" + i.ToString();
            string strI1 = "skinCharacter1" + i.ToString();
            _skinCharacter[i] = PlayerPrefs.GetInt(strI);
            _skinCharacter1[i] = PlayerPrefs.GetInt(strI1);
            Debug.Log(strI);
            Debug.Log(strI1);
        }
    }
    private void awards(int num)
    {
        if (num == 0 && _skinCharacter[num] != 1)
        {
            awardsInfo("Злой дух", "fragmentOwn0", 0);
        }
        else if (num == 1 && _skinCharacter[num] != 1)
        {
            awardsInfo("Чучело", "fragmentOwn1", 1);
        }
    }

    private void awardsInfo(string name, string fragmentOwnTotal, int num)
    {
        _fragment = name;
        _fragmentOwn[num] = PlayerPrefs.GetInt(fragmentOwnTotal);
        _fragmentOwn[num] = _fragmentOwn[num] + _fragmentInt;
        PlayerPrefs.SetInt(fragmentOwnTotal, _fragmentOwn[num]);  
        Debug.Log(_fragmentOwn[num]);
    }

    public void awardGenerate()
    {
        _panelAward.gameObject.SetActive(true);
        _fragmentTotal = Random.Range(0, 2); // Какой фрагмент
        _fragmentInt = Random.Range(0, 31);
        moneyGame = Random.Range(0, 11);
        xp = Random.Range(0, 101);

        awards(_fragmentTotal);
        awardText[0].text =_fragment + " " + _fragmentInt.ToString() + " штук";
        awardText[1].text = moneyGame.ToString();
        awardText[2].text = xp.ToString();
        awardFinish = true;
        StartCoroutine("DelPanel");
    }

    IEnumerator DelPanel()
    {
        yield return new WaitForSeconds(5);
        _panelAward.gameObject.SetActive(false);
    }
}
