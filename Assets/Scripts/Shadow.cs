using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public float shadowDistance;
    private Vector2 root;
    
    void LateUpdate()
    {
        if (!transform.parent.gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.SetActive(false);
        }
        root = transform.parent.position;
        
        transform.position = new Vector3(root.x, root.y - shadowDistance, 0);
    }
}
