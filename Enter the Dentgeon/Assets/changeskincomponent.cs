using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeskincomponent : MonoBehaviour
{
    public Sprite[] skins;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = skins[CharacterSelectionScript.selectedCharacter];
    }

}
