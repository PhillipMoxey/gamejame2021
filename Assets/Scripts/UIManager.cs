using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TextMeshProUGUI totalAmmo;
    public TextMeshProUGUI ammoCount;
    public TextMeshProUGUI roundNumber;
 
    public Image carrotImage;
    public Image coalImage;
    public Image snowballImage;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There is more than 1 UI Manager in the scene");
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
