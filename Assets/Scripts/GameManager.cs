using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    public bool gameStarted = false;

    public GameObject tapText;
    public TextMeshProUGUI scoreText;

    public int score = 0;

    public GameObject shopButton;
    public GameObject statsButton;
    public GameObject rankingButton;
    public GameObject gameStatsController;


    private void Start()
    {
        gameStatsController.GetComponent<GameStatsController>().LoadStats();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapText.SetActive(false);

        }
        UpdateSpawnRate();
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        GameObject.Find("Stats").GetComponent<Stats>().gold++;

        scoreText.text = score.ToString();
    }

    private void UpdateSpawnRate()
    {
        switch (score)
        {
            case 20:
            case 40:
            case 60:
            case 80:
            case 100:
                StartSpawning();
                score++;
                break;
            default:
                break;
        }
    }
}
