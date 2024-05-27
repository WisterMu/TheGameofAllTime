using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class Labeller : MonoBehaviour
{
    TextMeshPro Label;
    public Vector2Int cords = new Vector2Int();
    gridManager GridManager;

    private void Awake()
    {
        GridManager = FindObjectOfType<gridManager>();
        Label = GetComponentInChildren<TextMeshPro>();

        displayCords();
    }

    private void Update()
    {
        displayCords();
        transform.name = cords.ToString();
    }

    private void displayCords()
    {
        cords.x = Mathf.RoundToInt(transform.position.x / GridManager.UnityGridSize);
        cords.y = Mathf.RoundToInt(transform.position.z / GridManager.UnityGridSize);

        Label.text = $"{cords.x} , {cords.y}";
    }
}
