using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 startingVelocity = new Vector2(5f, 5f);
    [SerializeField] private float speedUp = 1.1f;

    [SerializeField] private GameManager gameManager;
        
    private const string WALL_TAG = "Wall";
    private const string PLAYER_WALL_TAG = "WallPlayer";
    private const string ENEMY_WALL_TAG = "WallEnemy";
    private const string PLAYER_TAG = "Player";
    private const string ENEMY_TAG = "Enemy";

    //Foi mencionado no vídoe que utilizar o Start faria com que não tivessemos um controlador da ordem dos eventos, porem utilizar Awake faz com que tenhamos esse controle
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        if(rb2D == null) { rb2D = GetComponent<Rigidbody2D>(); }
        rb2D.velocity = startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(WALL_TAG))
        {
            Vector2 newVelocity = rb2D.velocity;

            newVelocity.y = -newVelocity.y;
            rb2D.velocity = newVelocity;
        }
        else if(collision.gameObject.CompareTag(PLAYER_TAG) || collision.gameObject.CompareTag(ENEMY_TAG))
        {
            rb2D.velocity = new Vector2(-rb2D.velocity.x, rb2D.velocity.y);
            rb2D.velocity *= speedUp;
        }
        else if (collision.gameObject.CompareTag(PLAYER_WALL_TAG))
        {
            gameManager.ScorePlayer(1);
            ResetBall();
        }
        else if (collision.gameObject.CompareTag(ENEMY_WALL_TAG))
        {
            gameManager.ScoreEnemy(1);
            ResetBall();
        }
    }
}
