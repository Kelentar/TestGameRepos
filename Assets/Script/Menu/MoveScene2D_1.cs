using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene2D_1 : MonoBehaviour
{
    [SerializeField]
    public string newLevel;
    public BossBehavior hp;
    void Update()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        if (hp.currentHealth <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(newLevel);
        }
    }
}



