using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Game: MonoBehaviour
{
    public static Game Instance;
    GameObject enemyTanks;
    GameObject playerTank;
    public int enemyCount {
        get => enemyTanks.transform.childCount;
    }

    public int enemyCountStart;
    
    void Awake()
    {
        if (Instance != null && Instance != this) {
            Debug.Log("Multiple game managers found.");
            Destroy(this);
        } else {
            Instance = this;
        }

        enemyTanks = GameObject.Find("EnemyTanks");
        enemyCountStart = enemyCount;
        playerTank = GameObject.Find("PlayerTank");
    }

    void Start()
    {
        AssessEnemyCount();
        AssessPlayerDamage();

    }

    void Update()
    {
        
    }

    public void AssessEnemyCount() {
        StartCoroutine(CheckRemainingTanks());
    }

    public void AssessPlayerDamage() {
        int playerHP = playerTank.GetComponent<PlayerTankMovement>().HP;
        if (playerHP <= 0) {
            ScoreSaver.score = enemyCountStart-enemyCount;

            SceneManager.LoadScene("LoseScreen");
        } else {
            UI.Instance.UpdateHPText(playerHP);
        }
    }

    IEnumerator CheckRemainingTanks() {
        //wait 1 frame because GameObject.Destroy() doesn't execute immediately
        yield return null;

        if (enemyCount == 0) {
            SceneManager.LoadScene("WinScreen");
        } else {
            UI.Instance.UpdateTanksKilledText(enemyCountStart-enemyCount);
        }
    }
}
