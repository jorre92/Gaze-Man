﻿using UnityEngine;
using Tobii.Gaming;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;
    public Text candiesStatusText;
    public Text endGameText;
    public AudioClip eatAudioClip;
    public AudioClip endGameAudioClip;

    private int candiesAmount;
    private int collectedCandiesAmount;
    private AudioSource audioSource;

    void Start()
    {
        candiesAmount = GameObject.FindGameObjectsWithTag("Candie").Length;
        audioSource = GetComponent<AudioSource>();
        UpdateStatusText();
    }

    // Update is called once per frame
    void Update()
    {
        var gazePoint = TobiiAPI.GetGazePoint();
        var ray = camera.ScreenPointToRay(gazePoint.Screen);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    void OnCollisionEnter()
    {
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Candie")
        {
            audioSource.PlayOneShot(eatAudioClip);
            collectedCandiesAmount++;
            UpdateStatusText();
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Ghost")
        {
            audioSource.PlayOneShot(endGameAudioClip);
            endGameText.text = "You are dead!";
            Invoke("Restart", 3);
        }
    }

    private void UpdateStatusText()
    {
        candiesStatusText.text = collectedCandiesAmount + " / " + candiesAmount;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
