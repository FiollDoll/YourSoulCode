using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonPlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject[] miniGames = new GameObject[0]; // цвета
    [SerializeField] private string objects; // Обьект, в котором игрок нааходится
    private colorGame _script;
    [SerializeField] private GameObject textErorr;
    private void Start()
    {
        _script = miniGames[0].GetComponent<colorGame>();
    }
    // Различные менюшки
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "colorGame")
        {
            objects = "colorGame";
        }
    }
    public void buttonActive()
    {
        if (objects == "colorGame")
        {
            if (!_script.gameDead)
            {
                _script.gameOn = true;
                miniGames[0].gameObject.SetActive(true);
            }
            else
            {
                StartCoroutine(Error());
            }
        }
    }
    private IEnumerator Error()
    {
        textErorr.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        textErorr.gameObject.SetActive(false);

    }
}
