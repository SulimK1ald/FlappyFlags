using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public scriptMenu scriptMenu;

    public Rigidbody2D rb;
    public GameObject deadPanel;
    public GameObject howStart;

    public GameObject RespawnText;

    public float jumpForce;
    public bool canClick;
    public bool canHit;
    public bool alive;
    public Vector2 spawnPlace;
    private AudioSource audioSource;

    public float countdown = 100f;
    public static float currentCount = 100f;
    public Text timerText;
    public int lives = 0;
    public Text liveText;

    public Score _score;

    void Start()
    {
        _score = FindObjectOfType<Score>();
        lives = 0;
        loadLives();
        audioSource = GetComponent<AudioSource>();
        audioSource.enabled = false;

        timerText.text = countdown.ToString();

        rb = GetComponent<Rigidbody2D>();
        deadPanel.SetActive(false);
        RespawnText.SetActive(false);
        howStart.SetActive(true);
        Time.timeScale = 0f;
        alive = true;
        canClick = true;
        canHit = true;
        spawnPlace = transform.position;
        countdown = currentCount;

        scriptMenu.Unlocker();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            audioSource.enabled = true;
            rb.velocity = Vector2.up * jumpForce;
            audioSource.Play();
            Time.timeScale = 1f;
            StartCoroutine(startTextOff());
        }

        if (GetComponent<Player>().gameObject.GetComponent<CircleCollider2D>().enabled == false)
        {
            if (gameObject.transform.position.y <= -15f || gameObject.transform.position.y >= 7f ||
                  gameObject.transform.position.x >= 12f || gameObject.transform.position.x <= -12f)
            {
                alive = false;
                if (alive == false)
                {
                    Time.timeScale = 0.5f;
                    deadPanel.SetActive(true);
                    canClick = false;
                }
            }
        }

        if (countdown > 0 && lives != 5)
        {
            countdown -= Time.deltaTime;
            currentCount = countdown;
            timerText.text = Mathf.Round(countdown).ToString();
        }

        else if (countdown <= 0)
        {
            lives++;
            saveLives();
            countdown = 100;
        }

        if (lives > 5)
        {
            lives = 5;
            saveLives();
        }
        
        else if (lives == 0)
        {
            saveLives();
        } 
        
        liveText.text = lives.ToString();

    }
    public void saveLives()
    {
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.Save();
    }
    public void loadLives()
    {
        lives = PlayerPrefs.GetInt("Lives");
    }

    IEnumerator startTextOff()
    {
        yield return new WaitForSeconds(0.5f);
        howStart.SetActive(false);
        StopCoroutine(startTextOff());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            alive = false;
            if (alive == false && canHit == true)
            {
                _score.canPickScore = false;
                Time.timeScale = 0.5f;
                deadPanel.SetActive(true);
                canClick = false;
            }
        }
    }

    public void Respawn()
    {
        if (lives >= 1)
        {
            lives--;
            saveLives();
            alive = true;
            canClick = true;
            if (alive == true)
            {
                deadPanel.SetActive(false);
                transform.position = spawnPlace;
                canHit = false;
                GetComponent<Player>().gameObject.GetComponent<CircleCollider2D>().enabled = false;
                StartCoroutine(Invulnerability());
                rb.velocity = Vector2.up * jumpForce;

                Time.timeScale = 0f;
            }
        }
        else
        {
            RespawnText.SetActive(true);
            StartCoroutine(textTime());
        }
    }

    IEnumerator textTime()
    {
        yield return new WaitForSeconds(2f);
        RespawnText.SetActive(false);
        StopCoroutine(textTime());
    }

    IEnumerator Invulnerability()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Player>().gameObject.GetComponent<CircleCollider2D>().enabled = true;
        _score.canPickScore = true;
        canHit = true;
        StopCoroutine(Invulnerability());
    }

}
