using UnityEngine;
using System.Collections;

public class waveMovement : MonoBehaviour
{
    private bool hasRotated = false;
    static float speed = 0.3f;

    public Vector3 LeftStart;
    public Vector3 RightStart;
    public Vector3 UpStart;
    public Vector3 DownStart;

    Vector3 movement;

    public AudioClip waveSound;
    public new AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update ()
    {
        if(!hasRotated)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                audio.PlayOneShot(waveSound, 1.0F);
                //transform.position = new Vector3(1.5f, -7.0f, 0f);
                transform.position = UpStart;
                transform.Rotate(Vector3.back, 90, Space.Self);
                movement = new Vector3(0, speed, 0);
                hasRotated = true;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                audio.PlayOneShot(waveSound, 1.0F);
                //transform.position = new Vector3(1.5f, 7.0f, 0f);
                transform.position = DownStart;
                transform.Rotate(Vector3.back, 270, Space.Self);
                movement = new Vector3(0, -speed, 0);
                hasRotated = true;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                audio.PlayOneShot(waveSound, 1.0F);
                //transform.position = new Vector3(-11.5f, -1.0f, 0f);
                transform.position = RightStart;
                transform.Rotate(Vector3.back, 180, Space.Self);
                movement = new Vector3(speed, 0, 0);
                hasRotated = true;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                audio.PlayOneShot(waveSound, 1.0F);
                //transform.position = new Vector3(11.5f, -1.0f, 0f);
                transform.position = LeftStart;
                movement = new Vector3(-speed, 0, 0);
                hasRotated = true;
            }
        }

        //if (GetComponent<Renderer>().isVisible)
        if(transform.position.x <= LeftStart.x &&
            transform.position.x >= RightStart.x &&
            transform.position.y <= DownStart.y &&
            transform.position.y >= UpStart.y)
        {
            transform.position += movement;
            
        }
        else
        {
            transform.rotation = Quaternion.identity;
            hasRotated = false;
        }

    }
}
