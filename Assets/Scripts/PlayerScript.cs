using UnityEngine;
using Tobii.Gaming;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;

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
}
