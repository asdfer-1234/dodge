
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public int scorePerSpawn;

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy Destroy Range"))
        {
            Destroy(gameObject);
        }
    }
}
