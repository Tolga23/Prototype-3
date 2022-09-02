using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMove : MonoBehaviour
{
    public float speed = 20;
    
    private PlayerController PlayerControllerScript;
    void Start()
    {
        PlayerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    void Update()
    {
        if(PlayerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        // Destroy Obstacles
        if (transform.position.x < -10 && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }

    }
}
