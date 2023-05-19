using System;
using UnityEngine;

public abstract class Transformable
{
    public virtual Vector2 Position { get; private set; }
    
    public event Action Moved;
    public event Action Destroying;

    public Transformable(Vector2 position)
    {
        Position = position;
    }

    public void MoveTo(Vector2 position)
    {
        Position = position;
        Moved?.Invoke();
    }

    public void Destroy()
    {
        Destroying?.Invoke();
    }
}