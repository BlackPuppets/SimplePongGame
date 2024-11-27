using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleController : MonoBehaviour
{
    [SerializeField] private float speed = 6f;
    [SerializeField] private bool isPlayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float moveInput;
    private Vector3 newPosition;
    private string controllerTypeName = "Vertical";

    private void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SaveController.instance.colorPlayer;
        else
        {
            spriteRenderer.color = SaveController.instance.colorEnemy;
            controllerTypeName = "Vertical2";
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis(controllerTypeName);
        newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        transform.position = newPosition;
    }
}
