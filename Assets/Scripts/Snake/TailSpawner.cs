using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailSpawner : MonoBehaviour
{
    [SerializeField] private Segment _segmentTamplate;

    public List<Segment> Generate(int count)
    {
        var tail = new List<Segment>();
        
        for (int i = 0; i < count; i++)
            tail.Add(Instantiate(_segmentTamplate, transform));

        return tail;
    }
}
