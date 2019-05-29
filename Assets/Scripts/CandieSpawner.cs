using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandieSpawner : MonoBehaviour
{
    public GameObject prefab = null;

    private float minValue = -25.0f;
    private float maxValue = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        TrySpawningCandie(minValue, maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TrySpawningCandie(float min, float max)
    {
        float steppingSize = 2.0f;
        for ( float i = min; i < max; i += steppingSize)
        {
            for ( float j = min; j < max; j += steppingSize)
            {
                Vector3 position = new Vector3(i, 1, j);
                Collider[] objects = Physics.OverlapSphere(position, 0.25f);

                if (objects.Length == 0)
                {
                    if (prefab != null)
                    {
                        Instantiate(prefab, position, prefab.transform.rotation);
                    }
                    
                }
            }
        }
    }
}
