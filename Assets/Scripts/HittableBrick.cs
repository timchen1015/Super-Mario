using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HittableBrick : MonoBehaviour
{
    [SerializeField] private UnityEvent Hit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Mario" && (collision.transform.position.y) + 1.5 < transform.position.y)
        {
            Hit.Invoke();
        }
    }
}
