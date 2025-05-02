using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText;
    public TMP_InputField namePlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestScoreText.text = "Best Score : " + MainManager.Instance.namePlayer + " " + MainManager.Instance.bestScore;
        namePlayer.text = MainManager.Instance.nameLastPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        MainManager.Instance.nameLastPlayer = namePlayer.text;
        MainManager.Instance.SaveDataPlayer();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        // original code to quit Unity player
        Application.Quit(); 
#endif
    }
}
