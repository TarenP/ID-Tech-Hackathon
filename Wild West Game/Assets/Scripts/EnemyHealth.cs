using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamage(float amount)
    {
        health -= amount;
        //Debug.Log(health);
        if (health <= 0f)
        {
            SceneManager.LoadScene(3);
        }
    }

}
