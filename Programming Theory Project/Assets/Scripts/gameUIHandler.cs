using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameUIHandler : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOver;
    public GameObject gameWinner;
    public TextMeshProUGUI scoreOver;
    public TextMeshProUGUI scoreWinner;
    public float interval = 0.5f;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        TestEndGame();
        FireEnemy();
        TestRestart();
        UpdateScore();
    }

    // ABSTRACTION
    void TestRestart()
    {
        if (Time.timeScale == 0 && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            MainManager.Instance.score = 0;
        }
    }

    // ABSTRACTION
    void FireEnemy()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int nbEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
            int randomIndex = Random.Range(0, nbEnemy);
            GameObject selectedItem = GameObject.FindGameObjectsWithTag("Enemy")[randomIndex];
            selectedItem.GetComponent<Enemy>().Fire();
            timer = interval;
        }
    }

    // ABSTRACTION
    void TestEndGame()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            EndGame(gameWinner, scoreWinner);
        }
        else if (GameObject.FindGameObjectsWithTag("Player").Length <= 0)
        {
            EndGame(gameOver, scoreOver);
        }
    }

    // ABSTRACTION
    void EndGame(GameObject titleEndGame, TextMeshProUGUI scoreTxt)
    {
        Time.timeScale = 0;
        titleEndGame.SetActive(true);
        scoreTxt.text = "Score : " + MainManager.Instance.nameLastPlayer + " : " + MainManager.Instance.score;
        MainManager.Instance.SaveDataPlayer();
    }

    // ABSTRACTION
    void UpdateScore()
    {
        scoreText.text = MainManager.Instance.nameLastPlayer + " : " + MainManager.Instance.score;
    }

    
}
