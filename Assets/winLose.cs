using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winLose : MonoBehaviour
{
    [SerializeField] private GameObject win;
    [SerializeField] private GameObject lose;
    [SerializeField] private float timerDuration = 60f; // Длительность таймера в секундах
    [SerializeField] private Image timerBar;
    private float timer;
    private Scene scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        timer = timerDuration;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        UpdateTimer();
        if (timer <= 4)
        {
            lose.SetActive(true);
            if (timer <= 0)
            {
                SceneManager.LoadScene(scene.buildIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("zone"))
        {
            win.SetActive(true);
        }
    }

    private void UpdateTimer()
    {
        float timerProgress = timer / timerDuration;
        timerBar.fillAmount= timerProgress;
    }
}
