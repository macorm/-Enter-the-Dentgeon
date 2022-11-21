using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pickup : MonoBehaviour
{
    public Item item;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickupItem(collision);
        }
        void PickupItem(Collider2D player)
        {
            //afficher quel item a ete ramassé
            Debug.Log(item.name + " picked up");
            
            //prendre le script du joueur a modifier
            PlayerComponent stats = player.GetComponent<PlayerComponent>();
            
            //appliquer tout les changements qu'un item peut appliquer
            //appliquer changements vie
            HeartComponent.maxHealth += item.maxHealthIncrease;
            HeartComponent.health += item.heal;
            
            //appliquer changements mouvement
            stats.movementSpeed += stats.movementSpeed * item.speedMultiplier;
            player.transform.localScale += player.transform.localScale * item.sizeMultiplier;
            //appliquer changements bullets
            BulletComponent.damage += BulletComponent.damage * item.bulletDamageMultiplier;
            BulletComponent.speed += BulletComponent.speed * item.bulletSpeedMultiplier;
            //BulletComponent.scale = item.bulletSizeMultiplier;

            //ajouter l'item a l'inventaire du joueur
            if (item.name != "Rince bouche")
            {
                stats.inventaire.Add(item);
                FindObjectOfType<audioManager>().Play("PowerUp");
            }
            else
            {
                FindObjectOfType<audioManager>().Play("PickUp");
            }
            //retirer l'item du jeu
            Destroy(gameObject);
        }
    }
}
