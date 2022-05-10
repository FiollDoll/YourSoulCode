using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class award : MonoBehaviour
{
    //Панель
    [Header("Panel")]
    [SerializeField] private GameObject _panelAward;
    [SerializeField] private Text[] awardText = new Text[2]; //Фрагмент, деньги

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
    [SerializeField] private int[] _skinCharacter1 = new int[2]; //0 - не имеется. Злой дух, чучело


    public int moneyGame;

    public bool awardFinish;
    void awards(int num)
    {
        if (num == 0 && _skinCharacter[num] != 1)
        {
            _fragment = "Злой дух";
            _fragmentOwn[num] = PlayerPrefs.GetInt("fragmentOwn");
            _fragmentOwn[num] = _fragmentOwn[num] + _fragmentInt;
            PlayerPrefs.SetInt("fragmentOwn", _fragmentOwn[num]);
        }
        else if (num == 1 && _skinCharacter[num] != 1)
        {
            _fragment = "Чучело";
            _fragmentOwn[num] = PlayerPrefs.GetInt("fragmentOwn1");
            _fragmentOwn[num] = _fragmentOwn[num] + _fragmentInt;
            PlayerPrefs.SetInt("fragmentOwn1", _fragmentOwn[num]);
        }
    }
    public void awardGenerate()
    {
        _panelAward.gameObject.SetActive(true);
        _fragmentTotal = Random.Range(0, 2);
        _fragmentInt = Random.Range(0, 31);
        moneyGame = Random.Range(0, 11);
        awards(_fragmentTotal);
        awardText[0].text =_fragment + " " + _fragmentInt.ToString() + " штук";
        awardText[1].text = moneyGame.ToString();
        awardFinish = true;
        StartCoroutine("DelPanel");
    }

    IEnumerator DelPanel()
    {
        yield return new WaitForSeconds(5);
        _panelAward.gameObject.SetActive(false);
    }
}
