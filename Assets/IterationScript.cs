using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterationScript : MonoBehaviour
{
    public Transform relativeIterationTransform;
    public PrimitiveType iterationPrimitive;
    private Transform iterationContainer;
    private Transform lastIteration;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Iterate()
    {
        if (lastIteration == null)
        {
            iterationContainer = new GameObject().transform;
            iterationContainer.gameObject.name = "Iterations";
            iterationContainer.parent = transform;
            lastIteration = transform;
        }

        var sphere = GameObject.CreatePrimitive(iterationPrimitive).transform;
        sphere.parent = lastIteration;
        sphere.localPosition = relativeIterationTransform.position - transform.position;
        sphere.localRotation = relativeIterationTransform.rotation * Quaternion.Inverse(transform.rotation);
        sphere.localScale = relativeIterationTransform.localScale;
        sphere.parent = iterationContainer;
        lastIteration = sphere;
    }

    public void ResetIterations()
    {
        if(Application.isPlaying) Destroy(iterationContainer.gameObject);
        else DestroyImmediate(iterationContainer.gameObject);
    }

    public void Mirror(Vector3 scale)
    {
        var mirrored = Instantiate(iterationContainer);
        mirrored.localScale = scale;
        mirrored.parent = iterationContainer;
    }
}
