using UnityEngine;
using System.Collections;

public class rotationAnimation : MonoBehaviour
{
    public float speedMultiplier = 10.0f;
    private bool checker = true;
    private int acc = 100;

    // Use this for initialization
    void Start ()
    {
	
	}

	// Update is called once per frame
	void Update ()
    {

        if(checker)
        {
            transform.Rotate(Vector3.forward, Time.deltaTime * speedMultiplier, Space.Self);
            acc--;

            if (acc == 0)
            {
                checker = false;
            }
        }
        else
        {
            transform.Rotate(Vector3.back, Time.deltaTime * speedMultiplier, Space.Self);
            acc++;

            if (acc == 200)
            {
                checker = true;
            }
        }
    }
    
}
