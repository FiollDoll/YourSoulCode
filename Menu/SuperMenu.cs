using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperMenu : MonoBehaviour
{
    private int _loading;
    [SerializeField] private Text _text;
    [SerializeField] private GameObject[] _objects = new GameObject[3]; //Текст, кнопка, "Загрузка" - текст
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine("StartLoading");
    }
    private void Update()
    {
        _text.text = _loading.ToString();
    }
    IEnumerator StartLoading()
    {
        while (_loading < 100)
        {
            yield return new WaitForSeconds(0.001f);
            _loading++;
        }
        if (_loading == 100)
        {
            _objects[0].gameObject.SetActive(false);
            _objects[2].gameObject.SetActive(false);
            _objects[1].gameObject.SetActive(true);

        }
    }
}
