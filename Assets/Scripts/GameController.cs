using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    ///UI
    public Text points;
    /// 
    /// 
    /// Враги
    public float startWait;
    public float spawnWait;
    public static float timeCoef;
    public static float time;

    public List<GameObject> waves;
    public GameObject wave;

    private Vector3 spawnPos;
    ///

	void Start ()
    {
        spawnPos = new Vector3(0, 0, 8);
        StartCoroutine("SpawnWaves");
        Debug.Log("Waves.Count = " + waves.Count);
	}

    private void Update()
    {
        time = Time.timeSinceLevelLoad;
        timeCoef = 1 + time * 0.005f;
        points.text = "Points: "+PlayerScore.points.ToString();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            int num = Random.Range(0, waves.Count);
            Debug.Log(num);
            wave = waves[num];
            Instantiate(wave, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }

}
