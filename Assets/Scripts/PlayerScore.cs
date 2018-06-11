using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerScore : MonoBehaviour
{
    /// Главное меню
    public Button play;
    public Button openShop;
    public Button powerUp;
    public Button speedUp;
    public Button closeShop;
    public Button resetGame;

    public Text pointsText;

    public GameObject shopPanel;
    /// 

    /// Снаряды
    public static float bulletSpeed = 10;
    public static float fireRate = 0.2f;

    public static int bulletPower = 1;
    ///
    
    /// Системные значения
    private static int powerLevel = 1;
    private static int speedLevel = 1;

    public static int[] shopCost;

    public static float speedCoef;
    public static float powerCoef;

    string powerCostText;
    string speedCostText;
    ///

    /// Очки
    public static int points;
    ///

    private void Start()
    {
        shopCost = new int[10] { 100, 500, 5000, 10000, 100000, 250000, 700000, 1300000, 2500000, 7000000};

        points = PlayerPrefs.GetInt("points", points);
        fireRate = PlayerPrefs.GetFloat("speed", fireRate);
        bulletPower = PlayerPrefs.GetInt("power", bulletPower);
        speedLevel = PlayerPrefs.GetInt("speedLevel", speedLevel);
        powerLevel = PlayerPrefs.GetInt("powerLevel", powerLevel);

        Debug.Log("Скорость выстрелов = " + fireRate);
        Debug.Log("Мощь выстрелов = " + bulletPower);
        Debug.Log("Уровень скорости = " + speedLevel);
        Debug.Log("Уровень мощности = " + powerLevel);


        pointsText.text ="Points: " + points.ToString();

        powerCoef = bulletPower;
        speedCoef = 1 + (0.4f * speedLevel);

        /// Листенеры кнопок
        play.onClick.AddListener(Play);
        openShop.onClick.AddListener(OpenShop);
        closeShop.onClick.AddListener(CloseShop);
        powerUp.onClick.AddListener(PowerUp);
        speedUp.onClick.AddListener(SpeedUp);
        resetGame.onClick.AddListener(ResetGame);
        ///
    }

    private void Update()
    {
        powerUp.GetComponentInChildren<Text>().text = "Power up for " + shopCost[powerLevel - 1] + " points";
        speedUp.GetComponentInChildren<Text>().text = "Speed up for " + shopCost[speedLevel - 1] + " points";
    }

    private void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        fireRate = 0.2f;
        bulletPower = 1;
        powerLevel = 1;
        speedLevel = 1;
        powerCoef = bulletPower;
        speedCoef = 1 + (0.1f * speedLevel);
        points = 0;
        pointsText.text = "Points: " + points.ToString();
        PlayerPrefs.SetInt("points", points);
        PlayerPrefs.SetInt("power", bulletPower);
        PlayerPrefs.SetInt("speedLevel", speedLevel);
        PlayerPrefs.SetInt("powerLevel", powerLevel);
        PlayerPrefs.SetFloat("speed", fireRate);
    }

    private void SpeedUp()
    {
        if (points > shopCost[speedLevel - 1])
        {
            points = points - shopCost[speedLevel - 1];
            fireRate = fireRate * 0.8f;
            speedLevel++;
            PlayerPrefs.SetInt("speedLevel", speedLevel);
            PlayerPrefs.SetFloat("speed", fireRate);
            Debug.Log("Скорость = " + fireRate);
            Debug.Log("Уровень Скорости = " + speedLevel);
            speedCoef = 1 + (0.1f * speedLevel);
            pointsText.text = "Points: " + points.ToString();
        }
        else
        {
            Debug.Log("Not enough points!");
        }
    }

    private void PowerUp()
    {
        if (points > shopCost[powerLevel - 1])
        {
            points = points - shopCost[powerLevel - 1];
            bulletPower = bulletPower * 2;
            powerLevel++;
            PlayerPrefs.SetInt("powerLevel", powerLevel);
            PlayerPrefs.SetInt("power", bulletPower);
            Debug.Log("Мощь = " + bulletPower);
            Debug.Log("Уровень мощи = " + powerLevel);
            powerCoef = bulletPower;
            pointsText.text = "Points: " + points.ToString();
        }
        else
        {
            Debug.Log("Not enough points!");
        }
    }

    private void OpenShop()
    {
        shopPanel.SetActive(true);
    }

    private void CloseShop()
    {
        shopPanel.SetActive(false);
    }

    private void Play()
    {
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Single);
    }

}
