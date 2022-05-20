using System.Collections;
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
    [SerializeField] private GameObject _menu;
    public GameObject Prossesing;
    
    // Статы
    [Header("Stats")]
    public int[] mainStats = new int[3]; // хп, скорость, сила прыжка
    // Сделать список
    private int money; // Деньги
    public int moneyGame; // Деньги внутри уровня
    public int moneyTotal; // Очки. Конечная сумма для прибавления к монетам
    [SerializeField] private int _fakeMoney;
    [SerializeField] private Text _moneyTextTotal;
    public bool moneyTrue = true; // Получение
    [SerializeField] private Text _moneyText;
    
    [Header("Xp")]
    public int xpGame; //Получение в игре
    [SerializeField] private int _xp;
    [SerializeField] private Text _xpText;

    [Header("Audio")]
    [SerializeField] private GameObject audioManager;
    [SerializeField] private AudioClip audioMoney;
    [SerializeField] private AudioSource audio;
    [Header("Other")]
    public bool newLive;
    //Скрипты
    private playerInfo _script; // PlayerInfo. Статы
    private map _script1;
    private award _script2;
    private walk _script3;
    private UIEffects _script4;
    [SerializeField] private bool _negativ;



    private void Start()
    {
        _script = GetComponent<playerInfo>();
        _script1 = GetComponent<map>();
        _script2 = GetComponent<award>();
        _script3 = GetComponent<walk>();
        _script4 = GetComponent<UIEffects>();

        _timeLine.gameObject.SetActive(true);
        _timeRemaning = 7;
        // Статы
        character = PlayerPrefs.GetInt("character");
        money = PlayerPrefs.GetInt("money");
        _xp = PlayerPrefs.GetInt("xp");
        _script.CharacterTotal(character);
        mainStats[0] = _script.speed;
        mainStats[1] = _script.hp;
        mainStats[2] = _script.jumpp;
        // Аниматик
        _anim = GetComponent<Animator>();
        _animMHp = _MHp.GetComponent<Animator>();
        audio = audioManager.GetComponent<AudioSource>();
    }
    public void Jump()
    {
        _rb.AddForce(new Vector2(0, mainStats[2] * 16));
        //anim.SetBool("Jump", true);
        StartCoroutine("StopJump");
    }

    public void MenuOpen()
    {
        _rb.isKinematic = true;
        _menu.gameObject.SetActive(true);
        _timeRemaning = 20;
    }
    
    public void MenuClose()
    {
        _rb.isKinematic = false;
        _timeRemaning = 7;
       _menu.gameObject.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Изменение хп
        if (other.gameObject.tag == "EnemyKiller")
        {
            mainStats[1]--;
            _script4.textShow(0);
            _animMHp.SetBool("Mhp", true);
            StartCoroutine("StopMHp");
        }
        else if (other.gameObject.tag == "PlatformUp")
        {
            audio.PlayOneShot(audioMoney);
            moneyGame++;
        }
        // Дебаф-платформы
        else if (other.gameObject.name == "platformDebaff")
        {
            mainStats[0] -= 1;
        }
        else if (other.gameObject.name == "platformDebaff1")
        {
            mainStats[0] -= 2;
        }
        else if (other.gameObject.name == "platformDebaff2")
        {
            mainStats[0] -= 3;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "platformDebaff" || other.gameObject.name == "platformDebaff1" || other.gameObject.name == "platformDebaff2")
        {
            mainStats[0] = _script.speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BonusSpeed")
        {
            mainStats[0] += 1;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "BonusJump") //Изменено было
        {
            mainStats[1]++;
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "BonusHp")
        {
            mainStats[1]++;
            _script4.textShow(1);
            other.gameObject.SetActive(false);
        }

    }
    private void FixedUpdate()
    {
        //Убрать
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, mainStats[2] * 4));
        }
        //Движение
        _moveInput = _joystick.Horizontal;
        _rb.velocity = new Vector2(_moveInput * mainStats[0], 0);
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
    private void Update()
    {
        _negativ = _script1.negativ;
        _onGround = _script3.onGround;
        if (_onGround == false)
        {
            mainStats[2] = 0;
            //anim.SetBool("Jump", true);
            if (_timeRemaning > 0)
            {
                _timeRemaning -= Time.deltaTime;
            }
            else if (_timeRemaning < 0)
            {
                mainStats[1] = 0;
            }
        }
        else
        {
            //anim.SetBool("Jump", false);
            mainStats[2] = _script.jumpp;
            _timeRemaning = 7;
        }
        newLive = _play.GetComponent<ad>().newLive; // Получение из другого скрипта
        if (mainStats[1] <= 0) //Смерть
        {
            _defeatMenu.gameObject.SetActive(true);
            mainStats[0] = 0;
            mainStats[2] = 0;
            //GE.intensity = 0;
            mainStats[1] = _play.GetComponent<ad>().hp; // Получение из другого скрипта
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
                mainStats[0] = _script.speed;
                mainStats[2] = _script.jumpp;
                mainStats[1] = _script.hp;
            }

        }
        if (_script2.awardFinish == true)
        {
           _script2.awardFinish = false;
           moneyGame += _script2.moneyGame;
        }
        // Текста
       _moneyText.text = moneyGame.ToString();
       _moneyTextTotal.text = moneyTotal.ToString();
       _xpText.text = xpGame.ToString();

        if (_negativ == true)
        {
            _fakeMoney = Random.Range(0, 10000);
            _moneyText.text = _fakeMoney.ToString();
        }
    }
    // Выключение панели урона
    private IEnumerator StopMHp()
    {
        yield return new WaitForSeconds(0.3f);
        _animMHp.SetBool("Mhp", false);
    }
    // Назначение денег
    private IEnumerator StopMoney()
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
        xpGame = xpGame + moneyTotal * 10 + _script2.xp;
        _xp = _xp + xpGame;
        PlayerPrefs.SetInt("xp", _xp);
    }

    private IEnumerator StopJump()
    {
        yield return new WaitForSeconds(0.2f);
        _anim.SetBool("Jump", false);
    }

}
