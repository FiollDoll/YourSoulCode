using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuMaun : MonoBehaviour
{
    public int FirstGame; //Первый запуск
    public GameObject[] objects = new GameObject[3]; //Профиль сет, награды за уровень, прочее
    public string Name;
    public InputField ProfileInput;
    public Slider OpSlider;
    //Статы
    public int[] stats = new int[5]; //скорость, хп, монеты, прыжок, опыт, уровень

    public Text[] texts = new Text[2]; //Уровень, Имя

    void Start()
    {
        FirstGame = PlayerPrefs.GetInt("FirstGame");
        Name = PlayerPrefs.GetString("Name");
        stats[1] = PlayerPrefs.GetInt("hp");
        stats[0] = PlayerPrefs.GetInt("speed");
        stats[2] = PlayerPrefs.GetInt("money");
        stats[3] = PlayerPrefs.GetInt("jumpp");
        stats[4] = PlayerPrefs.GetInt("op");
        stats[5] = PlayerPrefs.GetInt("lvl");
    }

    public void RewardMenuOpen()
    {
        objects[1].gameObject.SetActive(true);
    }
    public void RewardMenuClose()
    {
        objects[1].gameObject.SetActive(false);
    }
    public void ProfileSetMenu()
    {
        objects[0].gameObject.SetActive(true);
    }
    public void OtherMenuOpen()
    {
        objects[2].gameObject.SetActive(true);
    }
    public void OtherClose()
    {
        objects[2].gameObject.SetActive(false);
    }
    public void ProfileSetName()
    {
        Name = ProfileInput.textComponent.text; //Назначение
        if (Name == "" || Name == " " || Name == "  ") //Если поле пустое
        {
            Name = "Игрок";
        }
        PlayerPrefs.SetString("Name", Name);
        objects[0].gameObject.SetActive(false);
    }
    public void ProfileSetName1() //Кнопка дефолт
    {
        Name = "Игрок";
        PlayerPrefs.SetString("Name", Name);
        objects[0].gameObject.SetActive(false);
    }
    void Update()
    {
        if (FirstGame == 0)
        {
            stats[3] = 1000;
            PlayerPrefs.SetInt("jumpp", stats[3]);
            stats[0] = 6;
            PlayerPrefs.SetInt("speed", stats[0]);
            stats[1] = 3;
            PlayerPrefs.SetInt("hp", stats[1]);
            stats[5] = 1;
            PlayerPrefs.SetInt("lvl", stats[5]);
            FirstGame = 1;
            PlayerPrefs.SetInt("FirstGame", FirstGame);
            objects[0].gameObject.SetActive(true);
        }

        OpSlider.value = stats[4]; //Число опыта на слайдере
        texts[0].text = stats[5].ToString();
        texts[1].text = Name;

    }
}
