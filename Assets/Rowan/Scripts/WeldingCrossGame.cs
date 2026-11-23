using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class WeldingCrossGame : MonoBehaviour
{
    public GameObject VoltageOrb;
    public GameObject pVoltageOrb;
    public GameObject FlowOrb;
    public GameObject pFlowOrb;

    public float maxSpeed;
    public float minSpeed;
    public float oscY;
    public float oscX;
    public float advancingSpeed;
    public float currentX;
    [SerializeField] private float timeX = 0;
    [SerializeField] private float timeY = 0;
    [SerializeField] private bool inRange = false;
    [SerializeField] private bool perfectRange = false;
    [SerializeField] private float orbsDistance;
    [SerializeField] private float noscx = 0;
    [SerializeField] private float noscy = 0;
    [SerializeField] public float completion;
    [SerializeField] private float pity;
    private bool inPity = false;
    public float pityCap;
    public TextMeshProUGUI pityText;
    public GameObject cSegment1;
    public GameObject cSegment2;
    public GameObject cSegment3;

    // Sine Wave Formula: y = 3.4sin(2pix/m)
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // It's inverted because the speed is how long it takes to complete an oscilation, not a multiplier.
        oscY = Random.Range(maxSpeed, minSpeed);
        oscX = Random.Range(maxSpeed, minSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (completion >= 1)
        {
            cSegment1.GetComponent<SpriteRenderer>().color = Color.limeGreen;
            if (completion >= 2)
            {
                cSegment2.GetComponent<SpriteRenderer>().color = Color.limeGreen;
                if (completion >= 3)
                {
                    cSegment3.GetComponent<SpriteRenderer>().color = Color.limeGreen;
                }
            }
        }
        if (inPity)
        {
            pityText.text = "NOW";
        } else
        {
            pityText.text = "" + (pityCap - pity);
        }
        Oscilate(VoltageOrb);
        currentX += advancingSpeed * 1/50;
        orbsDistance = Mathf.Sqrt((VoltageOrb.transform.position.x - FlowOrb.transform.position.x) * (VoltageOrb.transform.position.x - FlowOrb.transform.position.x) + (VoltageOrb.transform.position.y - FlowOrb.transform.position.y) * (VoltageOrb.transform.position.y - FlowOrb.transform.position.y));
        if (orbsDistance < 0.75)
        {
            inRange = true;
            if (orbsDistance < 0.375f)
            {
                perfectRange = true;
            }
        } else
        {
            inRange = false;
            perfectRange = false;
        }

       // Timer
        timeX += 0.02f;
        timeY += 0.02f;
        if (timeX >= oscX)
        {
            timeX = 0;
            noscx++;
            if (inPity)
            {
                oscX = Random.Range(maxSpeed, minSpeed);
                inPity = false;
                timeX = (oscX * Mathf.Asin(FlowOrb.transform.position.x / 3.4f)) / (2 * Mathf.PI);
                noscx = 0;
            }
            if (noscx >2 && !inPity)
            {
                oscX = Random.Range(maxSpeed, minSpeed);
                inPity = false;
                timeX = (oscX * Mathf.Asin(FlowOrb.transform.position.x / 3.4f)) / (2 * Mathf.PI);
                noscx = 0;
                pity += 0.5f;
            }
            
        }
        if (timeY >= oscY)
        {
            timeY = 0;
            noscy++;
            if (inPity)
            {
                inPity = false;
                oscY = Random.Range(maxSpeed, minSpeed);
                timeY = (oscY * Mathf.Asin(VoltageOrb.transform.position.y / 3.4f)) / (2 * Mathf.PI);
                noscy = 0;
            }
            if (noscy >2 && !inPity)
            {
                inPity = false;
                oscY = Random.Range(maxSpeed, minSpeed);
                timeY = (oscY * Mathf.Asin(VoltageOrb.transform.position.y / 3.4f)) / (2 * Mathf.PI);
                noscy = 0;
                pity += 0.5f;
            }
            
        }
        if (pity >= pityCap)
        {
            PityTime();
        }
    }

    public void Oscilate(GameObject thing)
    {
        VoltageOrb.transform.position = new Vector3(0, 3.4f * Mathf.Sin(2 * Mathf.PI * timeY / oscY), 0);
        FlowOrb.transform.position = new Vector3(3.4f * Mathf.Sin(2 * Mathf.PI * timeX / oscX), 0, 0);
    }

    public void Calibrate()
    {
        if (inRange)
        {
            completion++;
            if (perfectRange)
            {
                completion++;
            }
        }
    }

    public void PityTime()
    {
        inPity = true;
        Debug.Log("What a Pity.");
        pity = 0;
        float tuVo = oscX - timeX;
        timeY = 0;
        oscY = tuVo;
    }
}
