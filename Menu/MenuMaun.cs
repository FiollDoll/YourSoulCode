using UnityEngine;
using UnityEngine.UI;

public class MenuMaun : MonoBehaviour
{
    [Header("Main")]
    private int _FirstGame; // Первый запуск
    // Другое
    [SerializeField] private GameObject[] _objects = new GameObject[3]; // Профиль сет, награды за уровень, прочее
    [SerializeField] private string _Name;
    [SerializeField] private InputField _ProfileInput;
    [SerializeField] private Slider _XpSlider;
    // Статы
    [SerializeField] private int[] _stats = new int[5]; // скорость, хп, монеты, прыжок, опыт, уровень

    [SerializeField] private Text[] _texts = new Text[2]; // Уровень, Имя
    [Header("Other")]
    [SerializeField] private GameObject playButtons;
    private bool playMenuOn;
    // Скрипт
    private lvl _script;

    private void Start()
    {
        _script = GetComponent<lvl>();
        _FirstGame = PlayerPrefs.GetInt("FirstGame");
        _Name = PlayerPrefs.GetString("Name");
        _stats[1] = PlayerPrefs.GetInt("hp");
        _stats[0] = PlayerPrefs.GetInt("speed");
        _stats[2] = PlayerPrefs.GetInt("money");
        _stats[3] = PlayerPrefs.GetInt("jumpp");
    }
    public void PlayMenuOpen()
    {
        if (!playMenuOn)
        {
            playButtons.gameObject.SetActive(true);
            playMenuOn = true;
        }
        else
        {
            playButtons.gameObject.SetActive(false);
            playMenuOn = false;
        }
    }
    public void RewardMenuOpen()
    {
        _objects[1].gameObject.SetActive(true);
    }
    public void RewardMenuClose()
    {
        _objects[1].gameObject.SetActive(false);
    }
    public void ProfileSetMenu()
    {
        _objects[0].gameObject.SetActive(true);
    }
    public void OtherMenuOpen()
    {
       _objects[2].gameObject.SetActive(true);
    }
    public void OtherClose()
    {
        _objects[2].gameObject.SetActive(false);
    }
    public void ProfileSetName()
    {
        _Name = _ProfileInput.textComponent.text; // Назначение
        if (_Name == "" || _Name == " " || _Name == "  ") // Если поле пустое
        {
            _Name = "Player";
        }
        PlayerPrefs.SetString("Name", _Name);
        _objects[0].gameObject.SetActive(false);
    }

    public void ProfileSetName1() // Кнопка дефолт
    {
        _Name = "Player";
        PlayerPrefs.SetString("Name", _Name);
        _objects[0].gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_FirstGame == 0)
        {
            _stats[5] = 1;
            PlayerPrefs.SetInt("lvl", _stats[5]);
            _stats[3] = 1000;
            PlayerPrefs.SetInt("jumpp", _stats[3]);
            _stats[0] = 6;
            PlayerPrefs.SetInt("speed", _stats[0]);
            _stats[1] = 3;
            PlayerPrefs.SetInt("hp", _stats[1]);
            

            _FirstGame = 1;
            PlayerPrefs.SetInt("FirstGame", _FirstGame);
            _objects[0].gameObject.SetActive(true);
        }
        else
        {
            _stats[4] = _script.xp;
            _stats[5] = _script.totalLvl;
        }
        _XpSlider.value = _stats[4]; // Число опыта на слайдере
        _texts[0].text = _stats[5].ToString();
        _texts[1].text = _Name;

    }
}
