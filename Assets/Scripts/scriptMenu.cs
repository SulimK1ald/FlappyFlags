using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{

    public GameObject unblockText;
    private GameObject unblockManager;
    public bool unblock = false;
    public int unlockLevel;

    private void Start()
    {
        unblockManager = GameObject.Find("Player");
        unblockText.SetActive(false);

        loadLevels();
        Unlocker();
    }

    public void Unlocker()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            unlockLevel = 2;
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            unlockLevel = 3;
        }

        if (SceneManager.GetActiveScene().name == "Level3")
        {
            unlockLevel = 4;
        }

        if (SceneManager.GetActiveScene().name == "ExtremeLevel")
        {
            unlockLevel = 4;
        }
    }

    public void MainMenu1lvl()
    {
        if (unblockManager.GetComponent<Score>().score >= 20f)
        {
            unblock = true;
        }
        if (unblock == true)
        {
            PlayerPrefs.SetInt("unlockLevel", unlockLevel);
            saveLevels();
            SceneManager.LoadScene("StartGameScene");
        }
        if (unblock == false)
        {
            unblockText.SetActive(true);
            StartCoroutine(TextTime());
        }
    }

    public void MainMenu4lvl()
    {
        if (unblockManager.GetComponent<Score>().score >= 20f)
        {
            unblock = true;
        }
        if (unblock == true)
        {
            saveLevels();
            SceneManager.LoadScene("StartGameScene");
        }
        if (unblock == false)
        {
            unblockText.SetActive(true);
            StartCoroutine(TextTime());
        }
    }

    public void saveLevels()
    {
        PlayerPrefs.SetInt("unlockLevel", unlockLevel);
        PlayerPrefs.Save();
    }

    public void loadLevels()
    {
        unlockLevel = PlayerPrefs.GetInt("unlockLevel");
    }

    public void lastScene()
    {
        if (unblockManager.GetComponent<Score>().score >= 10f)
        {
            unblock = true;
        }
        if (unblock == true)
        {
            SceneManager.LoadScene("lastScene");
            saveLevels();
        }
        if (unblock == false)
        {
            unblockText.SetActive(true);
            StartCoroutine(TextTime());
        }
    }

    IEnumerator TextTime()
    {
        yield return new WaitForSeconds(2f);
        unblockText.SetActive(false);
        StopCoroutine(TextTime());
    }
}
