using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class award : MonoBehaviour
{
    //Панель
    [SerializeField] private GameObject _panelAward;
    [SerializeField] private Text[] awardText = new Text[2]; //Фрагмент, деньги
    [SerializeField] private int _fragmentTotal;
    [SerializeField] private string _fragment;
    [SerializeField] private int _fragmentInt;
    [SerializeField] private int _moneyGame;

    void awards(int num)
    {
        if (num == 0)
        {
            _fragment = "Злой дух";
        }
        else if (num == 1)
        {
            _fragment = "Чучело";
        }
    }
    public void awardGenerate()
    {
        _panelAward.gameObject.SetActive(true);
        _fragmentTotal = Random.Range(0, 2);
        _fragmentInt = Random.Range(0, 31);
        _moneyGame = Random.Range(0, 11);
        awards(_fragmentTotal);
        awardText[0].text =_fragment + " " + _fragmentInt.ToString() + "штук";
        StartCoroutine("DelPanel");
    }

        IEnumerator DelPanel()
    {
        yield return new WaitForSeconds(3);
        _panelAward.gameObject.SetActive(false);
}
