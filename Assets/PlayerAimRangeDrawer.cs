using System;
using UnityEngine;

public class PlayerAimRangeDrawer : MonoBehaviour
{
    [SerializeField] private int _segments = 64;
    [SerializeField] private float _lineWidth = 0.1f;
    
    private LineRenderer _lineRenderer;
    private float _radius = 1f;

    public void Construct(float radius)
    {
        _radius = radius;
    }

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        _lineRenderer.useWorldSpace = false;
        _lineRenderer.startWidth = _lineWidth;
        _lineRenderer.endWidth = _lineWidth;
    }

    private void FixedUpdate()
    {
        DrawCircle();
    }


    private void DrawCircle()
    {
        _lineRenderer.positionCount = _segments + 1;
        float angle = 2f * Mathf.PI / _segments;
        for (int i = 0; i <= _segments; i++)
        {
            float x = Mathf.Sin(angle * i) * _radius;
            float y = Mathf.Cos(angle * i) * _radius;
            _lineRenderer.SetPosition(i, new Vector3(x, y, 0f));
        }
    }
}
