using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    // Start is called before the first frame update
    public static float scoreValue = 0;
    Text points;

    void Start()
    {
        points = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "MPH: " + scoreValue;
    }
}
