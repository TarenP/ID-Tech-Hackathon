using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Gun gun;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        gun = gun.GetComponent<Gun>();
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + gun.scr;
    }
}
