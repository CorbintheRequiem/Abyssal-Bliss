using Unity.VisualScripting;
using UnityEngine;

public class EntireGridTest : MonoBehaviour
{
    public GameObject FirstSquare;
    [SerializeField] private GameObject activeSquare;
    public float timer;
    public float timercap = 0.2f;
    private bool right = true;
    public bool down = true;
    public bool Backwards;
    public GameObject FinalSquare;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!Backwards)
        {
            down = true;
            activeSquare = FirstSquare;
        } else
        {
            down = false;
            activeSquare = FinalSquare;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 0.02f;
        if (timer >= timercap)
        {
            timer = 0;
            Debug.Log("Fired");
            if (right)
            {
                if (activeSquare.GetComponent<GridGame>().rBorder != null)
                {
                    activeSquare = activeSquare.GetComponent<GridGame>().rBorder;
                } else
                {
                    right = false;
                    if (down)
                    {
                        activeSquare = activeSquare.GetComponent<GridGame>().dBorder;
                    } else
                    {
                        activeSquare = activeSquare.GetComponent<GridGame>().uBorder;
                    }
                    
                }
                
            } else
            {
                if (activeSquare.GetComponent<GridGame>().lBorder != null)
                {
                    activeSquare = activeSquare.GetComponent<GridGame>().lBorder;
                } else
                {
                    right = true;
                    if (down)
                    {
                        activeSquare = activeSquare.GetComponent<GridGame>().dBorder;
                    }
                    else
                    {
                        activeSquare = activeSquare.GetComponent<GridGame>().uBorder;
                    }
                }
            }
        }
        activeSquare.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
        if (activeSquare.GetComponent<GridGame>().uBorder != null)
        {
            activeSquare.GetComponent<GridGame>().uBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = true;
        }

        if (activeSquare.GetComponent<GridGame>().dBorder != null)
        {
            activeSquare.GetComponent<GridGame>().dBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = true;
        }

        if (activeSquare.GetComponent<GridGame>().lBorder != null)
        {
            activeSquare.GetComponent<GridGame>().lBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = true;
        }
        if (activeSquare.GetComponent<GridGame>().rBorder != null)
        {
            activeSquare.GetComponent<GridGame>().rBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = true;
        }

    }
}
