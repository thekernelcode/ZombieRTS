using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawner : MonoBehaviour
{
    public Transform playerPrefab;

    public Transform spawnPoint;

    public float timeBetweenReinforcements = 5f;
    private float countdown = 3f;

    public Text waveCountdownText;

    private int waveNumber = 1;  // TEST UNTIL REINFORCEMENT MECHANIC IS WORKED OUT

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());  // INSTEAD OF CALLING FUNCTION WE USE THIS TO CALL IENUMERATOR
            countdown = timeBetweenReinforcements;
        }

        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();

    }

    IEnumerator SpawnWave()  // IENUMERATOR INSTEAD OF VOID ALLOWS THE 'WAITFORSECONDS' COMMAND
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnReinforcement();
            yield return new WaitForSeconds(0.5f);
        }

        waveNumber++;
    }

    void SpawnReinforcement()
    {
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
