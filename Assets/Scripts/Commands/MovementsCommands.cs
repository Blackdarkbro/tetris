using UnityEngine;

public class MovementCommands 
{
    public void MoveRight(GameObject gameObject)
    {
        gameObject.transform.position += Vector3.right;
    }

    public void MoveLeft(GameObject gameObject)
    {
        gameObject.transform.position += Vector3.left;
    }
    
    public void MoveDown(GameObject gameObject)
    {
         gameObject.transform.position += Vector3.down;
    }

    public void StopMove(GameObject gameObject)
    {
        gameObject.transform.position += Vector3.up;
    }

    public void Rotate(GameObject gameObject)
    {
         gameObject.transform.Rotate(new Vector3(0, 0, 90));
    }

    public void Drop(GameObject gameObject)
    {
        
    }
}