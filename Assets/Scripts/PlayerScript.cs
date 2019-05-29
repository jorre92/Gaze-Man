using UnityEngine;
using Tobii.Gaming;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;
    public Text candiesStatusText;

    private int candiesAmount;
    private int collectedCandiesAmount;

    void Start()
    {
        candiesAmount = GameObject.FindGameObjectsWithTag("Candie").Length;
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
            collectedCandiesAmount++;
            UpdateStatusText();
            Destroy(collider.gameObject);
        }
    }

    private void UpdateStatusText()
    {
        candiesStatusText.text = collectedCandiesAmount + " / " + candiesAmount;
    }
}
