using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 100f;
    public Text hp;
    public bool dead = false;

    public GameObject player;
    public void TakeDamage(float amount)
    {
        health -= amount;
        hp.text = "Health: " + health;
        //Debug.Log(health);
        if (health <= 0f)
        {
            dead = true;
            StartCoroutine(Death());
            
        }
    }
    public void Update()
    {
        if (dead == true)
        {
            player.transform.Rotate(Vector3.left * 100 * Time.deltaTime);
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        dead = false;
        SceneManager.LoadScene(2);
    }

}
