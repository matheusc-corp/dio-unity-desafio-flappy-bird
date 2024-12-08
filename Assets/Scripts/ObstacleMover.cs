using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameManager gameManager = GameManager.Instance;

        if(gameManager.IsGameOver()){
            return;
        }

        // Move obstacle
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x, 0, 0);

        // Destroy obstacle
        if(transform.position.x <= -GameManager.Instance.obstacleOffsetX){
            Destroy(gameObject);
        }
        
    }
}
