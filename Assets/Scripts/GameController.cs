using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    ///UI
    public Text points;
    /// 
     
    /// Враги и баффы
    public float startWait;
    public float spawnWait;

    public static float timeCoef;
    public static float time;

    public List<GameObject> waves;
    public List<GameObject> buffsList;

    public GameObject wave;
    public GameObject buff;

    private Vector3 spawnPos;
    private Vector3 spawnBuff;
    ///

	void Start ()
    {
        spawnPos = new Vector3(0, 0, 8);
        StartCoroutine("SpawnWaves");
        StartCoroutine("SpawnBuff");
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
            wave = waves[num];
            Instantiate(wave, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    IEnumerator SpawnBuff()
    {
        yield return new WaitForSeconds(startWait + spawnWait/3);
        while (true)
        {
            int num = Random.Range(0, buffsList.Count);
            float x = Random.Range(-2, 2);
            spawnBuff = new Vector3(x, 0, 8);
            buff = buffsList[num];
            GameObject buffy = Instantiate(buff, spawnBuff, Quaternion.identity);
            buffy.transform.Rotate(new Vector3(0,180,0));
            yield return new WaitForSeconds(spawnWait*3);
        }
    }
}
