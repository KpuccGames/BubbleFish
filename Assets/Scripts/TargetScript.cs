using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TargetScript : MonoBehaviour
{
    public int minHP;
    public int maxHP;
    public int hp;

    public string text;

    private void Start()
    {
        minHP = (int)(minHP * PlayerScore.powerCoef * PlayerScore.speedCoef * GameController.timeCoef);
        maxHP = (int)(maxHP * PlayerScore.powerCoef * PlayerScore.speedCoef * GameController.timeCoef);
        hp = Random.Range(minHP, maxHP);
        text = hp.ToString();
        gameObject.GetComponentInChildren<TextMesh>().text = text;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("points", PlayerScore.points);
            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
        if(other.tag == "Bullet")
        {
            hp = hp - PlayerScore.bulletPower;
            text = hp.ToString();
            PlayerScore.points = PlayerScore.points + PlayerScore.bulletPower;
            gameObject.GetComponentInChildren<TextMesh>().text = text;
            if (hp <= 0) Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }
}

/*На 10 уровне мощи и скорости количество жизней цели от 70к до 110к
 * На 1 уровне количество жизней от 15 до 40.
 * 
 * 
 * 
 * 
 */
