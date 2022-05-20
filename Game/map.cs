using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class map : MonoBehaviour
{
    [Header("TotalWorld")]
    public int TotalWorld;
    
    [Header("Other")]
    private award _script;
    private bool negativEnd = true;

    public int moneyGame;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject camera;
    [SerializeField] private GameObject[] textLocation = new GameObject[2];
    [SerializeField] private GameObject _negativEffect;
    public bool negativ;
    
    [Header("Platform")]
    [SerializeField] private int PlatformTotal;
    [SerializeField] private GameObject[] Platform = new GameObject[22];
        
    [Header("Platform1")] 
    [SerializeField] private GameObject[] Platform1 = new GameObject[8];
    
    [Header("Platform2")] 
    [SerializeField] private GameObject[] Platform2 = new GameObject[2];
    
    [Header("Platform+")]
    [SerializeField] private GameObject[] Platforms = new GameObject[3]; // Продавец
    [SerializeField] private bool[] PlatformSpawned = new bool[3]; // Было или нет
    
    [Header("Spawners")]
    [SerializeField] private Transform Spawner;

    private void Start()
    {
        _script = GetComponent<award>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "NegativTeleport" && other.gameObject.name != "PortalEnd")
        {
            negativ = true;
            _negativEffect.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "NegativTeleport" && other.gameObject.name == "PortalEnd" && negativEnd == true)
        {
            _script.awardGenerate();
            negativ = false;
            _negativEffect.gameObject.SetActive(false);
            negativEnd = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        void SpawnPlatform(int platform, GameObject Go)
        {
            if (TotalWorld == 0)
            {
                Instantiate(Platform[platform], Spawner.position, Quaternion.identity);
            }
            else if (TotalWorld == 1)
            {
                Instantiate(Platform1[platform], Spawner.position, Quaternion.identity);
            }

            Go.gameObject.tag = "Platform";
        }
        if (other.gameObject.tag == "PlatformUp")
        {
            //Первая локация
            if (TotalWorld == 0)
            {
                //Смена тега
                GameObject Go = other.gameObject;

                PlatformTotal = Random.Range(0, 24);
                if (PlatformTotal == 0)
                {
                    SpawnPlatform(0, Go);
                }
                else if (PlatformTotal == 1)
                {
                    SpawnPlatform(1, Go);
                }
                else if (PlatformTotal == 2)
                {
                    SpawnPlatform(2, Go);
                }
                else if (PlatformTotal == 3)
                {
                    SpawnPlatform(3, Go);
                }
                else if (PlatformTotal == 4)
                {
                    SpawnPlatform(4, Go);
                }
                else if (PlatformTotal == 5)
                {
                    SpawnPlatform(5, Go);
                }
                else if (PlatformTotal == 6)
                {
                    SpawnPlatform(6, Go);
                }
                else if (PlatformTotal == 7)
                {
                    SpawnPlatform(7, Go);
                }
                else if (PlatformTotal == 8)
                {
                    SpawnPlatform(8, Go);
                }
                else if (PlatformTotal == 9)
                {
                    SpawnPlatform(9, Go);
                }
                else if (PlatformTotal == 10)
                {
                    SpawnPlatform(10, Go);
                }
                else if (PlatformTotal == 11)
                {
                    SpawnPlatform(11, Go);
                }
                else if (PlatformTotal == 12)
                {
                    SpawnPlatform(12, Go);
                }
                else if (PlatformTotal == 13)
                {
                    SpawnPlatform(13, Go);
                }
                else if (PlatformTotal == 14)
                {
                    SpawnPlatform(14, Go);
                }
                else if (PlatformTotal == 15)
                {
                    SpawnPlatform(15, Go);
                }
                else if (PlatformTotal == 16)
                {
                    SpawnPlatform(16, Go);
                }
                else if (PlatformTotal == 17)
                {
                    SpawnPlatform(17, Go);
                }
                else if (PlatformTotal == 18)
                {
                    SpawnPlatform(18, Go);
                }
                else if (PlatformTotal == 19)
                {
                    SpawnPlatform(19, Go);
                }
                else if (PlatformTotal == 20)
                {
                    SpawnPlatform(20, Go);
                }
                else if (PlatformTotal == 21)
                {
                    SpawnPlatform(21, Go);
                }
                else if (PlatformTotal == 22)
                {
                    SpawnPlatform(22, Go);
                }
                //Супер
                else if (PlatformTotal == 23)
                {
                    if (PlatformSpawned[0] == false)
                    {
                        PlatformSpawned[0] = true;
                        Instantiate(Platforms[0], Spawner.position, Quaternion.identity);
                        Go.gameObject.tag = "Platform";
                    }
                    else
                    {
                        PlatformTotal = Random.Range(0, 24);
                    }
                }
                else
                {
                    PlatformTotal = Random.Range(0, 24);
                }
            }
            else if (TotalWorld == 1)
            {
                //Смена тега
                GameObject Go = other.gameObject;

                PlatformTotal = Random.Range(0, 8);
                Debug.Log("True");
                if (PlatformTotal == 0)
                {
                    SpawnPlatform(0, Go);
                }
                else if (PlatformTotal == 1)
                {
                    SpawnPlatform(1, Go);
                }
                else if (PlatformTotal == 2)
                {
                    SpawnPlatform(2, Go);
                }
                else if (PlatformTotal == 3)
                {
                    SpawnPlatform(3, Go);
                }
                else if (PlatformTotal == 4)
                {
                    SpawnPlatform(4, Go);
                }
                else if (PlatformTotal == 5)
                {
                    SpawnPlatform(5, Go);
                }
                else if (PlatformTotal == 6)
                {
                    SpawnPlatform(6, Go);
                }
                else if (PlatformTotal == 7)
                {
                    SpawnPlatform(7, Go);
                }
                else
                {
                    PlatformTotal = Random.Range(0, 8);
                }
            }
            else if (TotalWorld == 2)
            {
                //Смена тега
                GameObject Go = other.gameObject;

                PlatformTotal = Random.Range(0, 2);
                Debug.Log("True");
                if (PlatformTotal == 0)
                {
                    Instantiate(Platform2[0], Spawner.position, Quaternion.identity);
                    Go.gameObject.tag = "Platform";
                }
                else if (PlatformTotal == 1)
                {
                    Instantiate(Platform2[0], Spawner.position, Quaternion.identity);
                    Go.gameObject.tag = "Platform";
                }
                else
                {
                    PlatformTotal = Random.Range(0, 2);
                }
            }
        }
    }
    private void Update()
    {
        moneyGame = Player.GetComponent<Player>().moneyGame; //Получение из другого скрипта
        //Вкл/выкл текста
        if (moneyGame == 1)
        {
            textLocation[0].gameObject.SetActive(true);
        }
        else if (moneyGame == 3)
        {
            textLocation[0].gameObject.SetActive(false);
        }
        //Смена локация
        else if (moneyGame == 19)
        {
            TotalWorld = 1;
        }
        else if (moneyGame == 20)
        {
            textLocation[1].gameObject.SetActive(true);
            camera.GetComponent<Camera>().backgroundColor = new Color32(94, 60, 71, 1);
        }
        else if (moneyGame == 22)
        {
        //Вкл/выкл текста
            textLocation[1].gameObject.SetActive(false);
        }
        else if (moneyGame == 40)
        {
            TotalWorld = 2;
        }
    }
}