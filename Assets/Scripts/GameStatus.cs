using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 73;
    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;


    // Use this for initialization

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start () {
        scoreText.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}
    public void  AddToScore(){
        currentScore = currentScore + pointsPerBlock;
        scoreText.text = currentScore.ToString();

    }
    public void ResetGame(){
        Destroy(gameObject);

    }

    public bool IsAutoPlayEnabled(){
        return isAutoPlayEnabled;
    }
}
