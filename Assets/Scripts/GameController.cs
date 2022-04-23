using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] foodPrefabs;
    public Material[] foodColor;

    void Start()
    {
        for (int z = 10; z < 100; z++)
        {
            GameObject curFood = Instantiate(foodPrefabs[Random.Range(0, 2)], new Vector3(1, 0.2f, z), Quaternion.identity);
            float xScale = 0;
            while (xScale == 0)
            {
                xScale = Random.Range(-1, 2);
            }
            curFood.transform.localScale = new Vector3(xScale, curFood.transform.localScale.y, curFood.transform.localScale.z);
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
}
