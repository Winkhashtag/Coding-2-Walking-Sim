using UnityEngine;

public class OneTimeCollider : MonoBehaviour
{

    private bool hasInteracted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {

        if (!hasInteracted)
        {
            Debug.Log("first colliion");
            hasInteracted = true;
        }
    }
}
