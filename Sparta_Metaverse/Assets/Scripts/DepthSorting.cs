using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthSorting : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public int baseSortingOffset = 3000; // ±âº» order°ª

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        float currentY = transform.position.y;
        int sortingOrder = Mathf.RoundToInt(currentY * -100f);

        spriteRenderer.sortingOrder = sortingOrder + baseSortingOffset;
    }
}
