using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float speed = 3f;

    [SerializeField] private Vector2 limits = new Vector2(-4.5f, 4.5f);

    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //Personally think using a reference on the inspector is better as this can cause problems if the name of objects is changed
        ball = GameObject.Find("Ball");
    }

    private void Update()
    {
        if(ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y);
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }

}
