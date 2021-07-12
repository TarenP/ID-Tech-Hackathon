using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Playermovement : MonoBehaviour
{
    private bool running = true;
    public float speed = .1f;
    // Update is called once per frame
    void Update()
    {
        if (running == true)
        {
            float xDirection = Input.GetAxis("Horizontal");


            Vector3 movDir = new Vector3(0, 0.0f, xDirection);

            transform.position += movDir * speed;
        }
       

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Respawn")
        {
            
            StartCoroutine(waiter());
        }
        else if (other.gameObject.tag == "GameController"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            running = false;
        }


    }
    IEnumerator waiter()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.None;
        rb.useGravity = true;
        running = false;
        //Wait for 4 seconds
        yield return new WaitForSeconds(4);
        Debug.Log("Waiting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
