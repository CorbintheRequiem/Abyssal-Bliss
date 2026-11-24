using System.Linq.Expressions;
using UnityEditor.Tilemaps;
using UnityEngine;

public class BorderChecker : MonoBehaviour
{
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject ten;
    public GameObject eleven;
    public GameObject twelve;
    public GameObject thirteen;
    public GameObject fourteen;
    public GameObject fifteen;
    public GameObject sixteen;
    public GameObject[] tilesList;
    public int TileToCheck;
    public bool top;
    public bool bottom;
    public bool left;
    public bool right;
    public float timer = 0;
    public bool searching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] tiles = {null, one, two, three, four, five, six, seven, eight, nine, ten, eleven, twelve, thirteen, fourteen, fifteen, sixteen};
        tilesList = tiles;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (searching)
        {
            timer += 0.02f;
            if (timer >= 0.25)
            {
                timer = 0;
                TileToCheck++;
                if (TileToCheck > 16)
                {
                    TileToCheck = 1;
                    if (bottom)
                    {
                        bottom = false;
                        top = true;
                    }
                    else if (top)
                    {
                        top = false;
                        left = true;
                    }
                    else if (left)
                    {
                        left = false;
                        right = true;
                    }
                    else if (right)
                    {
                        right = false;
                        bottom = true;
                    }
                }
            }
        }
    }
    void Update()
    {
        if (searching)
        {
        for (int i = 1; i < 17; i++)
        {
            tilesList[i].transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = true;
        }
        if (tilesList[TileToCheck] != null && TileToCheck > 0 && TileToCheck < 17)
        {
            if (bottom)
            {
                tilesList[TileToCheck].transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                if (tilesList[TileToCheck].GetComponent<GridGame>().dBorder != null)
                {
                    tilesList[TileToCheck].GetComponent<GridGame>().dBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            if (top)
            {
                tilesList[TileToCheck].transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                if (tilesList[TileToCheck].GetComponent<GridGame>().uBorder != null)
                {
                    tilesList[TileToCheck].GetComponent<GridGame>().uBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            if (left)
            {
                tilesList[TileToCheck].transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                if (tilesList[TileToCheck].GetComponent<GridGame>().lBorder != null)
                {
                    tilesList[TileToCheck].GetComponent<GridGame>().lBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                }
            }
            if (right)
            {
                tilesList[TileToCheck].transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                if (tilesList[TileToCheck].GetComponent<GridGame>().rBorder != null)
                {
                    tilesList[TileToCheck].GetComponent<GridGame>().rBorder.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
                }
            }
        }
        }

    }
}
