using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    int currentTelescope = 0;
    PointScript PS;
    [SerializeField] List<GameObject> Telescopes;
    [SerializeField] int Cost;
    [SerializeField] GameObject spawnPos;
    GameObject currentGameObjectTelescope;
    [SerializeField] TextMeshProUGUI costTextField;
    [SerializeField] TextMeshProUGUI pointsTextField;
    PhotoScript photS;
    // Start is called before the first frame update
    void Start()
    {
        photS = FindObjectOfType<PhotoScript>().GetComponent<PhotoScript>();
        PS = FindObjectOfType<PointScript>().GetComponent<PointScript>();
        currentGameObjectTelescope = Instantiate(Telescopes[currentTelescope], spawnPos.transform.position, Quaternion.identity);
        photS.getRefrenceToCamera();
        costTextField.text = "Cost: " + Cost;
    }

    // Update is called once per frame
    void Update()
    {
        pointsTextField.text = "points: " + PS.points;
    }

    public void Upgrade()
    {
        if(PS.points >= Cost && currentTelescope != Telescopes.Count -1)
        {
            PS.points -= Cost;
            Cost = Cost * 2;
            Destroy(currentGameObjectTelescope);
            currentTelescope += 1;
            Debug.Log(currentTelescope+ "bought");
            currentGameObjectTelescope = Instantiate(Telescopes[currentTelescope], spawnPos.transform.position, Quaternion.identity);
            photS.getRefrenceToCamera();
            costTextField.text = "Cost: " + Cost;
        }
    }
}
