using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperMenu : MonoBehaviour
{
    private int loading;
    public Text text;
    public GameObject[] objects = new GameObject[3]; //Текст, кнопка, "Загрузка" - текст
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartLoading");
    }
    void Update()
    {
        text.text = loading.ToString();
    }
    IEnumerator StartLoading()
    {
        while (loading < 100)
        {
            yield return new WaitForSeconds(0.001f);
            loading++;
        }
        if (loading == 100)
        {
            objects[0].gameObject.SetActive(false);
            objects[2].gameObject.SetActive(false);
            objects[1].gameObject.SetActive(true);

        }
    }
}
