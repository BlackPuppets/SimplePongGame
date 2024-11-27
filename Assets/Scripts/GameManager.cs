using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerPaddle;
    [SerializeField] private Transform enemyPaddle;

    [SerializeField] private GameObject screenEndGame;

    [SerializeField] private TextMeshProUGUI textPointsPlayer;
    [SerializeField] private TextMeshProUGUI textPointsEnemy;
    [SerializeField] private TextMeshProUGUI textEndGame;

    [SerializeField] private BallController ballController;

    [SerializeField] private int winPoints = 3;

    private int _playerScore;
    [DefaultValue(0)]
    [SerializeField] 
    private int playerScore 
    { 
        get { return _playerScore; }
        set 
        {
            _playerScore = value;
            textPointsPlayer.text = _playerScore.ToString();
        } 
    }

    private int _enemyScore;
    [DefaultValue(0)]
    [SerializeField]
    private int enemyScore
    {
        get { return _enemyScore; }
        set
        {
            _enemyScore = value;
            textPointsEnemy.text = _enemyScore.ToString();
        }
    }

    void Start()
    {
        ResetGame();
    }

    public void ResetGame()
    {
        playerPaddle.position = new Vector3(-7f, 0f, 0f);
        enemyPaddle.position = new Vector3(7f, 0f, 0f);
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;
    }

    public void ScorePlayer(int score)
    {
        playerScore += score;
        CheckWin();
    }

    public void ScoreEnemy(int score)
    {
        enemyScore += score;
        CheckWin();
    }

    private void CheckWin()
    {
        if(enemyScore >= winPoints || playerScore >= winPoints)
        {
            //ResetGame();
            EndGame();
        }
    }

    private void EndGame()
    {
        screenEndGame.SetActive(true);
        string winner = SaveController.instance.GetName(playerScore > enemyScore);
        textEndGame.text = "Victory " + winner;
        SaveController.instance.SaveWinner(winner);
        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
