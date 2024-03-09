using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBricks : MonoBehaviour
{
    [SerializeField] private GameObject _object;
    public void spawn()
    {
        Vector3 temp = new Vector3(0f, 0f, 0);
        transform.position += temp;
        var BrokenBricks = Instantiate(_object, transform.position, Quaternion.identity);
        Destroy(BrokenBricks, 0.5f);
    }
}
