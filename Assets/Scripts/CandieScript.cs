using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandieScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Spawned");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 30, 45) * Time.deltaTime);
    }
}
