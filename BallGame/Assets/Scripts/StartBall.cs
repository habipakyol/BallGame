using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBall : MonoBehaviour
{


    private RectTransform rectTransform;
    private Vector2 direction;
    private float speed;


    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        speed = Random.Range(500, 1000); // Topun rastgele bir hýzý olacak
        direction = new Vector2(Random.Range(-2f, 2f), Random.Range(-2f, 2f)).normalized; // Rastgele bir yön belirleyin ve normalleþtirin

    }
    void Update()
    {
        Vector2 currentPosition = rectTransform.anchoredPosition;
        Vector2 newPosition = currentPosition + direction * speed * Time.deltaTime;
        rectTransform.anchoredPosition = newPosition;

        if (newPosition.x > Screen.width / 2 || newPosition.x < -Screen.width / 2)
        {
            direction.x = -direction.x;
        }

        if (newPosition.y > Screen.height / 2 || newPosition.y < -Screen.height / 2)
        {
            direction.y = -direction.y;
        }
    }
}


