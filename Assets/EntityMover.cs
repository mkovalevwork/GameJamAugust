using System.Collections;
using UnityEngine;

public class EntityMover : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private IEnumerator MoveTo(Vector3 destination)
    {     
        float step = (speed / (transform.position - destination).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        while (t <= 1.0f)
        {
            t += step; // Goes from 0 to 1, incrementing by step each time
            transform.position = Vector3.Lerp(transform.position, destination, t); // Move objectToMove closer to b
            yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next frame
        }
        transform.position = destination;
    }
}