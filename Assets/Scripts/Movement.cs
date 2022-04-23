using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public short typeOfPlayer, score;
    public float finish, forwardSpeed, sideSpeed;
    public GameObject gameOverPanel;
    public Text scoreText;
    public Material[] playerColor;
    float x = 0.5f;
    bool isDead = false;

    private void Start()
    {
        typeOfPlayer = (short)Random.Range(0, 3);
        GetComponent<MeshRenderer>().material = playerColor[typeOfPlayer];
    }

    private void Update()
    {
        if (!isDead)
        {
            if (transform.position.z == finish) GameOver();
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.localScale.y, finish), forwardSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x * 2, transform.localScale.y, transform.position.z), sideSpeed * Time.deltaTime);
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, transform.position.z - 8f);
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                x = Camera.main.ScreenToViewportPoint(touch.position).x;
            }
        }
    }

    public void EatFood(short typeOfFood)
    {
        if (typeOfPlayer == typeOfFood)
        {
            score++;
        }
        else
        {
            if (score == 0)
            {
                GameOver();
            }
            score--;
        }
        score = (short)Mathf.Clamp(score, 0, 10);
        if (score < 10) transform.localScale = new Vector3((score + 4f)/ 20, (score + 4f)/ 20, (score + 4f) / 20);
    }

    private void GameOver()
    {
        isDead = true;
        GetComponent<MeshRenderer>().enabled = false;
        gameOverPanel.SetActive(true);
        scoreText.text = "Your Score: " + score;
    }
}
