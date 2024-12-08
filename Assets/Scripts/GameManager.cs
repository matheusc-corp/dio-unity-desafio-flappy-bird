using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [FormerlySerializedAs("prefabs")] // Utiliado para quando for atualizar o nome de uma variavel mantendo a referencia do nome antigo
    public List<GameObject> obstaclePrefabs;
    public float obstacleInterval = 1;
    public Vector2 obstacleOffsetY = new Vector2(0, 0);
    public float obstacleOffsetX = 0;
    public float obstacleSpeed = 10;

    [HideInInspector]
    public int score;

    private bool isGameOver = false;

    void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this);
        }
        else{
            Instance = this;
        }
    }

    public bool isGameActive(){
        return !isGameOver;
    }

    public bool IsGameOver(){
        return isGameOver;
    }

    public void EndGame(){
        isGameOver = true;
        Debug.Log($"Game Over... \n Your score was {score}");

        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay){

        // Esperar pelo tempo informado (delay)
        yield return new WaitForSeconds(delay);

        // Recarregar a cena
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene please!!!");
    }
}
