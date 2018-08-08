using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidth = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameStatus theGameStatus;
    Ball theBall;



	// Use this for initialization
	void Start () {
        theGameStatus = FindObjectOfType<GameStatus>();
        theBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        float mousePosition = Input.mousePosition.x / Screen.width * screenWidth;
        Vector2 paddlePosition = new Vector2(mousePosition, transform.position.y);
        paddlePosition.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePosition;
	}

    private float GetXPos(){
        if(theGameStatus.IsAutoPlayEnabled()){
            return theBall.transform.position.x;
        }
        else {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }
    }
}
