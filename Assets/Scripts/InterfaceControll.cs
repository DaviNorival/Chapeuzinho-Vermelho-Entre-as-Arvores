using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InterfaceControll : MonoBehaviour
{
    public Slider SliderCollections;
    public int TotalCollections = 10;
    private Character scriptCharacter;

    // Start is called before the first frame update
    void Start()
    {
        SliderCollections.maxValue = TotalCollections;
        scriptCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
    }

    public void UpdateSliderCollections()
    {
        if (scriptCharacter != null)
        {
            SliderCollections.value = scriptCharacter.Collections;
        }
        else
        {
            Debug.LogWarning("Character not found!");
        }
    }
}