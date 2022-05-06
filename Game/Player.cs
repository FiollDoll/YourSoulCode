using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [Header("PlayerSprite")]
    [SerializeField] private SpriteRenderer _playerBody; // Для вращения

    [Header("PlayerMain")]
    public int character;
    [SerializeField] private bool _onGround; // На земле или нет
    [SerializeField] private float _timeRemaning; // Проверка
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject _play;
    [Header("Animation")]
    private Animator _anim;
    private Animator _animMHp;
    
    [SerializeField] private GameObject _MHp;
    // Джостик
    [Header("Joystick")]
    [SerializeField]  private Joystick _joystick;
    private float _moveInput;
    
    [Header("UI")]
    [SerializeField] private GameObject _defeatMenu;
    [SerializeField] private GameObject _timeLine;
    public GameObject Prossesing;
    // Статы
    [Header("Stats")]
    [SerializeField] private int[] _mainStats = new int[3]; // хп, скорость, сила прыжка
    [SerializeField] private int _fakeHp;
    [SerializeField] private Text _hpText;
    // Сделать список
    private int money; // Деньги
    public int moneyGame; // Деньги внутри уровня
    public int moneyTotal; // Очки. Конечная сумма для прибавления к монетам
    [SerializeField] private int _fakeMoney;
    [SerializeField] private Text _moneyTextTotal;
    public bool moneyTrue = true; // Получение
    [SerializeField] private Text _moneyText;

    [Header("Other")]
    public bool newLive;
    private playerInfo _script; // PlayerInfo. Статы
    private map _script1;
    [SerializeField] private bool _negativ;

    [Header("Guys")]
    // Переделать
    public int RandomNum;
    public GameObject GuyMenu;
    public GameObject buttonGuy;
    public GameObject text;
    public GameObject text1;
    public GameObject text2;

    void Start()
    {
        _script = GetComponent<playerInfo>();
        _script1 = GetComponent<map>();
        _timeLine.gameObject.SetActive(true);
        _timeRemaning = 7;
        // Статы
        character = PlayerPrefs.GetInt("character");
        money = PlayerPrefs.GetInt("money");
        _script.CharacterTotal(character);
        _mainStats[0] = _script.speed;
        _mainStats[1] = _script.hp;
        _mainStats[2] = _script.jumpp;
        // Аниматик
        _anim = GetComponent<Animator>();
        _animMHp = _MHp.GetComponent<Animator>();
    }
    public void Jump()
    {
        _rb.AddForce(new Vector2(0, _mainStats[2] * 16));
        //anim.SetBool("Jump", true);
        StartCoroutine("StopJump");
    }
    void textChange(bool textActive, bool textActive1, bool textActive2)
    {
        text.gameObject.SetActive(textActive);
        text1.gameObject.SetActive(textActive1);
        text2.gameObject.SetActive(textActive2);
    }
    void menuOpen(bool menu, bool button)
    {
        GuyMenu.gameObject.SetActive(menu);
        buttonGuy.gameObject.SetActive(button);
    }
    public void OpenBadGuyMenu()
    {
        menuOpen(true, false);
    }
    //Первый дух
    public void BadGuyPlay()
    {
        RandomNum = Random.Range(0, 2);
        if (RandomNum == 0)
        {
            _mainStats[0] += 1;
            textChange(true, false, false);
        }
        else if (RandomNum == 1)
        {
            _mainStats[1]--;
            _animMHp.SetBool("MHp", true);
            StartCoroutine("StopMHp");
            textChange(false, true, false);
        }
        else
        {
            _mainStats[1]++;
            textChange(false, false, true);
        }
    }
    public void CloseBadGuyMenu()
    {
        menuOpen(false, true);
    }
    //Продолжение
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Изменение хп
        if (other.gameObject.tag == "EnemyKiller")
        {
            _mainStats[1]--;
            _animMHp.SetBool("MHp", true);
            StartCoroutine("StopMHp");
        }
        if (other.gameObject.tag == "PlatformUp")
        {
            moneyGame++;
            Debug.Log("Ya helicopter");
        }
        if (other.gameObject.name == "platformDebaff")
        {
            _mainStats[0] -= 1;
        }
        if (other.gameObject.name == "platformDebaff1")
        {
            _mainStats[0] -= 2;
        }
        if (other.gameObject.name == "platformDebaff2")
        {
            _mainStats[0] -= 3;
        }
        _onGround = true;
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "platformDebaff" || other.gameObject.name == "platformDebaff1" || other.gameObject.name == "platformDebaff2")
        {
            _mainStats[0] = _script.speed;
        }
        _onGround = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BonusSpeed")
        {
            _mainStats[0] += 1;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "BonusJump") //Изменено было
        {
            _mainStats[1]++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "BonusHp")
        {
            _mainStats[1]++;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "GlitchGuy" && other.gameObject.name == "GuyBad")
        {
            buttonGuy.gameObject.SetActive(true);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "GlitchGuy" && other.gameObject.name == "GuyBad")
        {
            buttonGuy.gameObject.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        //Убрать
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, _mainStats[2] * 5));
        }
        //Движение
        _moveInput = _joystick.Horizontal;
        _rb.velocity = new Vector2(_moveInput * _mainStats[0], 0);
        if (_moveInput < 0)
        {
            _playerBody.flipX = false;
        }
        if (_moveInput > 0)
        {
            _playerBody.flipX = true;
        }
        if (_rb.velocity != Vector2.zero)
        {
            //_anim.SetBool("Run", true);
        }
        else
        {
            //_anim.SetBool("Run", false);
        }
    }
    void Update()
    {
        _negativ = _script1.negativ;
        if (_onGround == false)
        {
            _mainStats[2] = 0;
            //anim.SetBool("Jump", true);
            if (_timeRemaning > 0)
            {
                _timeRemaning -= Time.deltaTime;
            }
            else if (_timeRemaning < 0)
            {
                _mainStats[1] = 0;
            }
        }
        else
        {
            //anim.SetBool("Jump", false);
            _mainStats[2] = _script.jumpp;
            _timeRemaning = 7;
        }
        newLive = _play.GetComponent<ad>().newLive; //Получение из другого скрипта
        if (_mainStats[1] <= 0) //Смерть
        {
            _defeatMenu.gameObject.SetActive(true);
            _mainStats[0] = 0;
            _mainStats[2] = 0;
            //GE.intensity = 0;
            _mainStats[1] = _play.GetComponent<ad>().hp; //Получение из другого скрипта
            if (moneyTrue == true)
            {
                StartCoroutine("StopMoney");
            }
        }
        else
        {
            moneyTrue = true;
            _defeatMenu.gameObject.SetActive(false);
            if (newLive == true)
            {
                _mainStats[0] = _script.speed;
                _mainStats[2] = _script.jumpp;
                _mainStats[1] = _script.hp;
            }

        }
        _hpText.text = _mainStats[1].ToString();
       _moneyText.text = moneyGame.ToString();
        _moneyTextTotal.text = moneyTotal.ToString();
        if (_negativ == true)
        {
            _fakeHp = Random.Range(0, 10000);
            _fakeMoney = Random.Range(0, 10000);
            _hpText.text = _fakeHp.ToString();
            _moneyText.text = _fakeMoney.ToString();
        }
    }
    IEnumerator StopMHp()
    {
        yield return new WaitForSeconds(0.3f);
        _animMHp.SetBool("MHp", false);
    }
    IEnumerator StopMoney()
    {
        moneyTrue = false;
        while(moneyTotal < moneyGame)
        {
            yield return new WaitForSeconds(0.001f);
            moneyTotal++;
        }
        money += moneyTotal;
        PlayerPrefs.SetInt("money", money);
        yield return new WaitForSeconds(1);
    }
    IEnumerator StopJump()
    {
        yield return new WaitForSeconds(0.2f);
        _anim.SetBool("Jump", false);
    }

}
