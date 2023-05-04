using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerObject : MonoBehaviour
{
    public void OnCollisionEnter(Collision h)
    {
        if (h.gameObject.CompareTag("Untagged") || h.gameObject.CompareTag("Obstacle"))
        {
            h.gameObject.SetActive(false);
        }
    }
}
