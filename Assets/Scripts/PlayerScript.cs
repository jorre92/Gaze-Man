using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var gazePoint = TobiiAPI.GetGazePoint();
        Debug.Log("hi " + gazePoint.Screen);
        //var ray = camera.ScreenPositionToRay(gazePoint.Screen);

        //if (Physics.Raycast(ray, out hit))
        {
            // do stuff.
        }
    }
}
