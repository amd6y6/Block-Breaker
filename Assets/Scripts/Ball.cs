using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2d;

    Vector2 paddleBallVector;
    bool gameStarted = false;

	// Use this for initialization
	void Start () {
        paddleBallVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2d = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

	

    private void LaunchBall() {
        if (Input.GetMouseButtonDown(0)) {
            gameStarted = true;
            myRigidBody2d.velocity = new Vector2(xPush, yPush);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 alterVelocity = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (gameStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2d.velocity += alterVelocity;
        }
    }

    private void LockBallToPaddle() {
        //ball will be at paddles position plus the difference of the paddle and ball (paddleBallVector)
        Vector2 paddlePosition = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePosition + paddleBallVector;
    }
}
