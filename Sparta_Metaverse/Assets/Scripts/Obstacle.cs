using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    GameManager_2 gameManager;
    public float highPosY = 1f;
    public float lowPosY = -1f;

    public float holeSizeMin = 10f;
    public float holeSizeMax = 20f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 5f;

    private void Start()
    {
        gameManager = GameManager_2.Instance;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Shark player = collision.GetComponent<Shark>();
        if (player != null)
        {
            Debug.Log("점수 오름");
            gameManager.AddScore(1);
        }
    }
    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2;

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize-1f);
        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);
        transform.position = placePosition;
        return placePosition;
    }
}
