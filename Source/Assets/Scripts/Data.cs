using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{

    static private int rows = 3;
    static private int columns = 4;

    public GameObject redPearl;
    public GameObject greenPearl;
    public GameObject purplePearl;

    private List<GameObject> movables;

    public GameObject winText;

    private bool win;

    public float delay;

    public AudioClip winSound;
    public new AudioSource audio;

    private bool soundPlayed;

    // Use this for initialization
    void Start()
    {

        movables = new List<GameObject>();

        audio = GetComponent<AudioSource>();

        // Add movable objects to list
        movables.Add(redPearl);
        movables.Add(greenPearl);
        movables.Add(purplePearl);

        win = false;

        delay = 0.2f;

        soundPlayed = false;

    }

    // Update is called once per frame
    void Update()
    {

        // Win condition
        if(redPearl.transform.position == (new Vector3(1.0f, 0f, 0f)) &&
            greenPearl.transform.position == (new Vector3(3.0f, -1.0f, 0f)) &&
            purplePearl.transform.position == (new Vector3(1.0f, -2.0f, 0f)))
        {
            if (!soundPlayed)
            {
                audio.PlayOneShot(winSound, 1.5F);
                soundPlayed = true;
            }
            win = true;
            winText.SetActive(true);
        }

        // Click R to restart
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (!win)
        {            

            // Wave left
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {

                // Start from the left most column
                for (int c = 0; c <= columns; c++)
                {

                    // Find objects in this column
                    foreach (GameObject movable in movables)
                    {

                        if (movable.transform.position.x == c)
                        {

                            // If it's not on the edge and nothing in its way move it
                            if (movable.transform.position.x != 0 &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != redPearl.transform.position &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != greenPearl.transform.position &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != purplePearl.transform.position &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(2.0f, -1.0f, 0f)))
                            {

                                // Move object
                                Vector3 movement = new Vector3(-1.0f, 0, 0);
                                movable.transform.position += movement;
                                //StartCoroutine(MoveAfterDelay(movable, new Vector3(-1.0f, 0, 0)));

                            }

                        }

                    }

                }

            }
            // Wave right
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                // Start from the right most column
                for (int c = columns; c >= 0; c--)
                {

                    // Find objects in this column
                    foreach (GameObject movable in movables)
                    {

                        if (movable.transform.position.x == c)
                        {

                            // If it's not on the edge and nothing in its way move it
                            if (movable.transform.position.x != 3 &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != redPearl.transform.position &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != greenPearl.transform.position &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != purplePearl.transform.position &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(2.0f, -1.0f, 0f)))
                            {

                                // Move object
                                Vector3 movement = new Vector3(1.0f, 0, 0);
                                movable.transform.position += movement;
                                //StartCoroutine(MoveAfterDelay(movable, new Vector3(1.0f, 0, 0)));

                            }

                        }

                    }

                }

            }
            // Wave up
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                // Start from the top most column
                for (int r = 0; r >= -rows; r--)
                {

                    // Find objects in this column
                    foreach (GameObject movable in movables)
                    {

                        if (movable.transform.position.y == r)
                        {

                            // If it's not on the edge and nothing in its way move it
                            if (movable.transform.position.y != 0 &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != redPearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != greenPearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != purplePearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(2.0f, -1.0f, 0f)))
                            {

                                // Move object
                                Vector3 movement = new Vector3(0f, 1.0f, 0f);
                                movable.transform.position += movement;
                                //StartCoroutine(MoveAfterDelay(movable, new Vector3(0f, 1.0f, 0f)));

                            }

                        }

                    }

                }

            }
            // Wave down
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                // Start from the bottom most column
                for (int r = -rows; r <= 0; r++)
                {

                    // Find objects in this column
                    foreach (GameObject movable in movables)
                    {

                        if (movable.transform.position.y == r)
                        {

                            // If it's not on the edge and nothing in its way move it
                            if (movable.transform.position.y != -2 &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != redPearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != greenPearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != purplePearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(2.0f, -1.0f, 0f)))
                            {

                                // Move object
                                Vector3 movement = new Vector3(0f, -1.0f, 0f);
                                movable.transform.position += movement;
                                //StartCoroutine(MoveAfterDelay(movable, new Vector3(0f, -1.0f, 0f)));

                            }

                        }

                    }

                }

            }
        }

    }

    IEnumerator MoveAfterDelay(GameObject movable, Vector3 direction)
    {
        yield return new WaitForSeconds(delay);

        // Move object
        movable.transform.position += direction;

    }

}
