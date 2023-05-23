using UnityEngine;

namespace DebugFeatures
{
    public class PhysicsDebug
    {
        public static void DrawDebug(Vector2 worldPos, float radius, float seconds)
        {
            Debug.DrawRay(worldPos, radius * Vector2.up, Color.red, seconds);
            Debug.DrawRay(worldPos, radius * Vector2.down, Color.red, seconds);
            Debug.DrawRay(worldPos, radius * Vector2.left, Color.red, seconds);
            Debug.DrawRay(worldPos, radius * Vector2.right, Color.red, seconds);
        }
        
        public static void DrawBox(Vector2 worldPos, float sizeX, float sizeY, float seconds)
        {
            Debug.DrawLine(new Vector2(worldPos.x - sizeX/2, worldPos.y -sizeY/2)
                , new Vector2(worldPos.x + sizeX/2, worldPos.y - sizeY/2), Color.red, seconds);
            
            Debug.DrawLine(new Vector2(worldPos.x - sizeX/2, worldPos.y +sizeY/2)
                , new Vector2(worldPos.x + sizeX/2, worldPos.y + sizeY/2), Color.red, seconds);
            
            Debug.DrawLine(new Vector2(worldPos.x - sizeX/2, worldPos.y -sizeY/2)
                , new Vector2(worldPos.x - sizeX/2, worldPos.y + sizeY/2), Color.red, seconds);
            
            Debug.DrawLine(new Vector2(worldPos.x + sizeX/2, worldPos.y - sizeY/2)
                , new Vector2(worldPos.x + sizeX/2, worldPos.y + sizeY/2), Color.red, seconds);
        }
    }
}