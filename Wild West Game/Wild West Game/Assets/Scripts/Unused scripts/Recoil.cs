using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public Vector3 upRecoil;
    Vector3 originalRotation;
    public bool addRecoil = false;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = transform.localEulerAngles;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (addRecoil == true)
        {
            StartCoroutine(Main());
        }
    }
    IEnumerator Main()
    {
        AddRecoil();
        yield return new WaitForSeconds(0.7f);
        StopRecoil();
    }
    private void AddRecoil()
    {
        transform.localEulerAngles += upRecoil;
    }

    private void StopRecoil()
    {
        transform.localEulerAngles = originalRotation;
      
    }
}
