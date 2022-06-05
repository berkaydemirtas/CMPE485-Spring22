using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;



public class head_collision : MonoBehaviour
{

    [SerializeField]
    public TextMeshProUGUI game_end_score;
    [SerializeField]
    public Button restartButton;
    [SerializeField]
    public TextMeshProUGUI game_end_distance;

    [SerializeField]
    private Text fuelMeter;

    [SerializeField]
    private Text coinCounter;

    [SerializeField]
    private Text distanceCounter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("gfdgggggggggggggggggggggggggggggggggggggggggggggggm-------------------------------------");
        
        game_end_distance.gameObject.SetActive(true);
        game_end_score.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        coinCounter.gameObject.SetActive(false);
        distanceCounter.gameObject.SetActive(false);
        fuelMeter.gameObject.SetActive(false);
        
    }
}
