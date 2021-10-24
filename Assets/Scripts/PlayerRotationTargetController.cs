
using UnityEngine;

public class PlayerRotationTargetController : MonoBehaviour
{
    public GameObject player;
    PlayerController playerController;

    private void Awake()
    {
        playerController = player.GetComponent<PlayerController>();
    }
    
    public void UpdateRotation()
    {
        transform.position = player.transform.position + new Vector3(playerController.movement.x, playerController.movement.y, 0);
    }
}
