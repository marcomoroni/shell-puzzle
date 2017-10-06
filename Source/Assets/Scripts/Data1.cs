using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data1 : MonoBehaviour {

    static private int rows = 5;
    static private int columns = 5;

    public GameObject pearl;
    public GameObject seaOrchin;
    public GameObject longShell;

    private List<GameObject> movables;

    public GameObject winText;

    private bool win;

    public float delay;

    public AudioClip winSound;
    public new AudioSource audio;

    private bool soundPlayed;

    // Use this for initialization
    void Start () {

        movables = new List<GameObject>();

        audio = GetComponent<AudioSource>();

        // Add movable objects to list
        movables.Add(pearl);
        movables.Add(seaOrchin);
        movables.Add(longShell);

        win = false;

        delay = 0.2f;

        soundPlayed = false;

    }
	
	// Update is called once per frame
	void Update () {

        // Win condition
        if (pearl.transform.position == (new Vector3(4.0f, -4.0f, 0f)))
        {
            if(!soundPlayed)
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
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != pearl.transform.position &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != seaOrchin.transform.position &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != longShell.transform.position &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != longShell.transform.position + (new Vector3(1.0f, 0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(1.0f, 0.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(1.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(1.0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(2.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(3.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(4.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(-1.0f, 0.0f, 0.0f)) != (new Vector3(3.0f, 0f, 0f)))
                            {

                                // Move object
                                Vector3 movement = new Vector3(-1.0f, 0, 0);
                                movable.transform.position += movement;
                                //StartCoroutine(MoveAfterDelay(movable, "left"));

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

                        if ((movable.transform.position.x == c) || (movable.transform.position.x == c + 1.0f && movable == longShell))
                        {

                            // If it's not on the edge and nothing in its way move it
                            if (movable.transform.position.x != 4 &&
                                /*(movable.transform.position.x < 3 && movable == longShell) &&*/
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != pearl.transform.position &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != seaOrchin.transform.position &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != longShell.transform.position &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(1.0f, 0.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(1.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(1.0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(2.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(3.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(4.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(1.0f, 0.0f, 0.0f)) != (new Vector3(3.0f, 0f, 0f)))
                            {

                                // Move object
                                Vector3 movement = new Vector3(1.0f, 0, 0);
                                if (movable == longShell && movable.transform.position.x == 3)
                                {

                                }
                                else if(movable == longShell && movable.transform.position.y == -1)
                                {

                                }
                                else if(movable == longShell &&
                                    (movable.transform.position + (new Vector3(2.0f, 0.0f, 0.0f)) == pearl.transform.position ||
                                    movable.transform.position + (new Vector3(2.0f, 0.0f, 0.0f)) == seaOrchin.transform.position))
                                {

                                }
                                else
                                {
                                    movable.transform.position += movement;
                                }
                                //StartCoroutine(MoveAfterDelay(movable, "right"));

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

                    // Find objects in this row
                    foreach (GameObject movable in movables)
                    {

                        if (movable.transform.position.y == r)
                        {

                            // If it's not on the edge and nothing in its way move it
                            if (movable.transform.position.y != 0 &&
                                /*(movable.transform.position.x < 3 && movable == longShell) &&*/
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != pearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != seaOrchin.transform.position &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != longShell.transform.position &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != longShell.transform.position + (new Vector3(1.0f, 0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(1.0f, 0.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(1.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(1.0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(2.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(3.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(4.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, 1.0f, 0.0f)) != (new Vector3(3.0f, 0f, 0f)))
                            {

                                // Move object
                                if ((movable == longShell && movable.transform.position.y == -1) ||
                                    (movable == longShell && movable.transform.position == (new Vector3(3f, -2f, 0f))))
                                {

                                }
                                else if (movable == longShell &&
                                    (movable.transform.position + (new Vector3(1.0f, 1.0f, 0.0f)) == pearl.transform.position ||
                                     movable.transform.position + (new Vector3(1.0f, 1.0f, 0.0f)) == seaOrchin.transform.position))
                                {

                                }
                                else
                                {
                                    Vector3 movement = new Vector3(0f, 1.0f, 0f);
                                    movable.transform.position += movement;
                                }
                                //StartCoroutine(MoveAfterDelay(movable, "up"));

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

                    // Find objects in this row
                    foreach (GameObject movable in movables)
                    {

                        if (movable.transform.position.y == r)
                        {

                            // If it's not on the edge and nothing in its way move it
                            if (movable.transform.position.y != -4 &&
                                /*(movable.transform.position.x < 3 && movable == longShell) &&*/
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != pearl.transform.position &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != seaOrchin.transform.position &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != longShell.transform.position &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != longShell.transform.position + (new Vector3(1.0f, 0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(1.0f, 0.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(1.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(1.0f, -3.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(2.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(3.0f, -4.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(4.0f, -1.0f, 0f)) &&
                                movable.transform.position + (new Vector3(0f, -1.0f, 0.0f)) != (new Vector3(3.0f, 0f, 0f)))
                            {

                                // Move object
                                if (movable == longShell &&
                                    (movable.transform.position + (new Vector3(1.0f, -1.0f, 0.0f)) == pearl.transform.position ||
                                     movable.transform.position + (new Vector3(1.0f, -1.0f, 0.0f)) == seaOrchin.transform.position))
                                {

                                }
                                else
                                {
                                    Vector3 movement = new Vector3(0f, -1.0f, 0f);
                                    movable.transform.position += movement;
                                }
                                //StartCoroutine(MoveAfterDelay(movable, "down"));

                            }

                        }

                    }

                }

            }
        }

    }

    IEnumerator MoveAfterDelay(GameObject movable, string direction)
    {
        yield return new WaitForSeconds(delay);

        // Move object
        if (direction == "left")
        {
            Vector3 movement = new Vector3(-1.0f, 0, 0);
            movable.transform.position += movement;
        }
        else if (direction == "right")
        {
            Vector3 movement = new Vector3(1.0f, 0, 0);
            if (movable == longShell && movable.transform.position.x == 3)
            {

            }
            else if (movable == longShell && movable.transform.position.y == -1)
            {

            }
            else if (movable == longShell &&
                (movable.transform.position + (new Vector3(2.0f, 0.0f, 0.0f)) == pearl.transform.position ||
                movable.transform.position + (new Vector3(2.0f, 0.0f, 0.0f)) == seaOrchin.transform.position))
            {

            }
            else
            {
                movable.transform.position += movement;
            }
        }
        else if (direction == "up")
        {
            if ((movable == longShell && movable.transform.position.y == -1) ||
                                    (movable == longShell && movable.transform.position == (new Vector3(3f, -2f, 0f))))
            {

            }
            else if (movable == longShell &&
                (movable.transform.position + (new Vector3(1.0f, 1.0f, 0.0f)) == pearl.transform.position ||
                 movable.transform.position + (new Vector3(1.0f, 1.0f, 0.0f)) == seaOrchin.transform.position))
            {

            }
            else
            {
                Vector3 movement = new Vector3(0f, 1.0f, 0f);
                movable.transform.position += movement;
            }
        }
        else if (direction == "down")
        {
            if (movable == longShell &&
                                    (movable.transform.position + (new Vector3(1.0f, -1.0f, 0.0f)) == pearl.transform.position ||
                                     movable.transform.position + (new Vector3(1.0f, -1.0f, 0.0f)) == seaOrchin.transform.position))
            {

            }
            else
            {
                Vector3 movement = new Vector3(0f, -1.0f, 0f);
                movable.transform.position += movement;
            }
        }

    }

}
