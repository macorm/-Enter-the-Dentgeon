using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nouvel Item", menuName = "Inventaire/Item")]
public class Item : ScriptableObject
{
    new public string name = "Nouvel Item";
    public string description = "Effets de l'item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
    //modifie la vie
    public int maxHealthIncrease = 0;
    public float heal = 0;
    //modifie le mouvement
    public bool allowsFlight = false;
    public float speedMultiplier = 0;
    public float sizeMultiplier = 0;
    //modifie les armes a feu
    public float bulletSpeedMultiplier = 0;
    public float bulletSizeMultiplier = 0;
    public float bulletDamageMultiplier = 0;
    public float fireRateMultiplier = 0;
    

}

