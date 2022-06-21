using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class colorGame : MonoBehaviour
{
    [Header("Main")]
    public bool gameOn;
    public bool gameDead;
    [SerializeField] private string _colorStr;
    [SerializeField] private string[] _colorFake = new string[1];
    [SerializeField] private string _colorText; // Текст игрока
    [SerializeField] private float time = 30;
    [SerializeField] private int points;
    
    [Header("Objects")]
    [SerializeField] private Button buttonExit;
    [SerializeField] private GameObject _player; // Для скрипта
    [SerializeField] private InputField _inputPlayer;
    [SerializeField] private Text _textForPlayer;
    [SerializeField] private Text _textPoints;
    [SerializeField] private GameObject _panelAward;
    [SerializeField] private GameObject menu;
    // Награды
    [SerializeField] private Text awardText;

    // Скрипт
    private Player _script;
    
    private void Start()
    {
        GeneratorAnswers();
        _script = _player.GetComponent<Player>();
    }

    public void ExitGame()
    {
        menu.gameObject.SetActive(false);
        gameDead = true;
    }
    public void CloseAwardPanel()
    {
        _panelAward.gameObject.SetActive(false);
    }
    private void GameOver()
    {
        points = points * 2;
        // awardText.text = "Ваши монеты: " + points;
        _script.moneyGame = _script.moneyGame + points;      
        _panelAward.gameObject.SetActive(true);
        gameOn = false;
        buttonExit.interactable = true;
    }
    private void GeneratorAnswers()
    {
        int RandomNum = Random.Range(0, 6);
        if (RandomNum == 0)
        {
            _colorStr = "красный";
            _textForPlayer.GetComponent<Text>().color = new Color(100, 0, 0);
        }
        else if (RandomNum == 1)
        {
            _colorStr = "синий";
            _textForPlayer.GetComponent<Text>().color = new Color(0, 0, 100);
        }
        else
        {
            // изменить
            GeneratorAnswers();
        }
    }
    public void textTrue() // Активация ответа
    {
        _colorText = _inputPlayer.textComponent.text; // Назначение
        _inputPlayer.text = "";
        if (_colorStr.ToLower() == _colorText.ToLower())
        {
            points++;
            _colorText = "";
            GeneratorAnswers();
        }
        else
        {
            GameOver();
        }
    }
    private void Update()
    {
        if (gameOn)
        {
            int RandomStr = Random.Range(0, 6);
            time = time - Time.deltaTime;
            if (time <= 0)
            {
                GameOver();
            }
            _textForPlayer.text = _colorFake[RandomStr];
            _textPoints.text = time.ToString();            
        }
    }
}
