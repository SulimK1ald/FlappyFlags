using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartLvl : MonoBehaviour
{
    [SerializeField] private Image _youImage, _youImage2, _youImage3, _youImage4;
    //Color c = GetComponent<Image>().color; 
    public bool LostProgress = false;

    public void ProgButton()
    {
            if (PlayerPrefs.GetInt("unlockLevel") <= 1)
            {   
                var color2 = _youImage2.color;
                color2.a = 0.7f;
                _youImage2.color = color2;

                var color3 = _youImage3.color;
                color3.a = 0.7f;
                _youImage3.color = color3;

                var color4 = _youImage4.color;
                color4.a = 0.7f;
                _youImage4.color = color4;
            }

            if (PlayerPrefs.GetInt("unlockLevel") == 2)
            {
                var color3 = _youImage3.color;
                color3.a = 0.7f;
                _youImage3.color = color3;

                var color4 = _youImage4.color;
                color4.a = 0.7f;
                _youImage4.color = color4;
            }

            if (PlayerPrefs.GetInt("unlockLevel") == 3)
            {
                var color4 = _youImage4.color;
                color4.a = 0.7f;
                _youImage4.color = color4;
            }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "StartGameScene" || LostProgress == true)
        {

            if (PlayerPrefs.GetInt("unlockLevel") > 0)
            {
                var color = _youImage.color;
                color.a = 1f;
                _youImage.color = color;
            }

            if (PlayerPrefs.GetInt("unlockLevel") >= 2)
            {
                var color = _youImage2.color;
                color.a = 1f;
                _youImage2.color = color;
            }

            if (PlayerPrefs.GetInt("unlockLevel") >= 3)
            {
                var color = _youImage3.color;
                color.a = 1f;
                _youImage3.color = color;
            }

            if (PlayerPrefs.GetInt("unlockLevel") >= 4)
            {
                var color = _youImage4.color;
                color.a = 1f;
                _youImage4.color = color;
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void level1()
    {
        SceneManager.LoadScene(1);
    }

    public void level2()
    {
        if (PlayerPrefs.GetInt("unlockLevel") >= 2)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void level3()
    {
        if (PlayerPrefs.GetInt("unlockLevel") >= 3)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void ExtremeLevel()
    {
        if (PlayerPrefs.GetInt("unlockLevel") >= 4)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("StartGameScene");
    }
    public void lostProgress()
    {
    
       PlayerPrefs.SetInt("unlockLevel", 1);
       PlayerPrefs.Save();
    
    }

    public void myGames()
    {
        Application.OpenURL("https://yandex.ru/games/search?utm_source=game_header_logo&query=K1aldGames");
    }
}
