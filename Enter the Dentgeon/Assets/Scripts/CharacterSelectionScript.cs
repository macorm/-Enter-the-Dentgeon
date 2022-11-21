using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectionScript : MonoBehaviour
{
    public GameObject[] Characters;
     static public int selectedCharacter = 0;
    // Start is called before the first frame update
    public void NextCharacter()
    {
        Characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % Characters.Length;
        Characters[selectedCharacter].SetActive(true);
    }
    public void previousCharacter()
    {
        Characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter < 0)
        {
            selectedCharacter += Characters.Length;
        }
        Characters[selectedCharacter].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
