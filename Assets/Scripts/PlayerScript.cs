using UnityEngine;
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
    public ParticleSystem splashParticleSystem;
    public ParticleSystem endGameParticleSystem;

    private int candiesAmount;
    private int collectedCandiesAmount;
    private AudioSource audioSource;
    private bool isEndGame;

    void Start()
    {
        candiesAmount = GameObject.FindGameObjectsWithTag("Candie").Length;
        audioSource = GetComponent<AudioSource>();
        UpdateStatusText();
    }

    // Update is called once per frame
    void Update()
    {
        if (isEndGame)
        {
            return;
        }

        var gazePoint = TobiiAPI.GetGazePoint();
        var ray = camera.ScreenPointToRay(gazePoint.Screen);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Candie")
        {
            audioSource.PlayOneShot(eatAudioClip);
            collectedCandiesAmount++;
            UpdateStatusText();

            splashParticleSystem.Play();
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Ghost")
        {
            audioSource.PlayOneShot(endGameAudioClip);
            endGameText.text = "You are dead!";
            Invoke("Restart", 3);

            isEndGame = true;
            endGameParticleSystem.Play();
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