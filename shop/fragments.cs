using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fragments : MonoBehaviour
{
    [SerializeField] private int skins; // Для изменения значения в инспекторе
    public int[] fragmentOwn = new int[2];
    public bool[] fragmentToSkin = new bool[2]; // Активирует кнопку активации скина

    // Получение информации в переменную
    private void fragmentInfo(int num, string fragmentsTotal)
    {
        fragmentOwn[num] = PlayerPrefs.GetInt(fragmentsTotal);
    }

    private void Start()
    {
        for (int i = 0; i < skins; i++)
        {
            string stringI = "fragmentOwn" + i.ToString();
            fragmentInfo(i, stringI);
            Debug.Log(stringI);
        }
    }

    private void Update()
    {
        for (int i = 0; i < skins; i++)
        {
            if (fragmentOwn[i] >= 100)
            {
                fragmentToSkin[i] = true;
                Debug.Log("True");
            }
        }


    }
}
