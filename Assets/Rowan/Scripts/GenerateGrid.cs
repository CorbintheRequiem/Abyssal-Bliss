using System.Collections;
using UnityEngine;

[System.Serializable]
public struct PipeArray2D
{
    public PipeArray[] pipeArrays;

    public PipeArray2D(PipeArray[] pipes)
    {
        this.pipeArrays = new PipeArray[pipes.Length];

        for (int i = 0; i < pipes.Length; ++i)
        {
            this.pipeArrays[i] = pipes[i];
        }
    }

    public PipeArray2D(GameObject[][] pipes)
    {
        this.pipeArrays = new PipeArray[pipes.Length];

        for (int i = 0; i < pipes.Length; ++i)
        {
            this.pipeArrays[i].pipes = pipes[i];
        }
    }
}

[System.Serializable]
public struct PipeArray
{
    public GameObject[] pipes;
}

public class GenerateGrid : MonoBehaviour
{
    public int pipes;
    private float pipeLength;
    // The Current Pipe Length of the Mid-Generation Pipe
    private float currentpl;
    private BorderChecker bc;
    private GridGame gg;
    private EntireGridTest egt;
    [SerializeField] private GameObject startingCorner;
    [SerializeField] private GameObject ss; // Starting Square
    public GameObject Grid1;
    public GameObject Grid2;
    public GameObject Grid3;
    public GameObject Grid4;
    public GameObject[] grids;
    private GameObject[] pipe1;
    private GameObject[] pipe2;
    private GameObject[] pipe3;
    private GameObject[] pipe4;
    private GameObject[] pipe5;
    private GameObject[] pipe6;
    private GameObject[] pipe7;
    private GameObject[] pipe8;
    private GameObject[] pipe9;
    private GameObject[] pipe10;
    public PipeArray2D allPipes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject[] gridlist = { null, Grid1, Grid2, Grid3, Grid4 };
        GameObject[][] pipeList = { null, pipe1, pipe2, pipe3, pipe4, pipe5, pipe6, pipe7, pipe8, pipe9, pipe10 };
        allPipes = new(pipeList);
        grids = gridlist;
        StartCoroutine(wait(0.05f));
    }

    // Update is called once per frame
    void Update()
    {
        if (ss != null)
        {
            ss.transform.Find("Square (1)").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    // Generates a random spawn point and begins the pipe
    public void RandomStart()
    {
        startingCorner = grids[Random.Range(1, 5)];
        ss = startingCorner.GetComponent<BorderChecker>().tilesList[Random.Range(1, 17)];
    }
    // Branch off
    public void Snake()
    {

    }
    // Check to See if All Neighboring Squares Have at Least One Open Neighbor
    public void Check()
    {

    }
    // Wait
    public IEnumerator wait(float seconds)
    {
        Debug.Log("started");
        yield return new WaitForSeconds(seconds);
        Debug.Log("Ended");
        RandomStart();
    }

}
