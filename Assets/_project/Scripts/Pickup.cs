using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //premessa ho disattivato alla fine lo sprite render dell'arma equippata perchè non ho tempo di gestire tutte le casistiche/animazioni magari lo farò in futuro


    [SerializeField] private Weapon _weaponPrefab;
    


    private void Awake()
    {
        //impostiamo isTrigger per non sbatterci contro, successo nel mio ultimo esercizio con i powerUp :S
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //il Player deve avere il Tag Player
        if (other.CompareTag("Player"))
        {
            EquipWeapon(other.transform);
        }
    }

    private void EquipWeapon(Transform player)
    {
        //sostituiamo l'arma se presente distruggendola
        Weapon oldWeapon = player.GetComponentInChildren<Weapon>();
        if (oldWeapon != null)
        {
            Destroy(oldWeapon.gameObject);
        }

        // creiamo la nuova
        if (_weaponPrefab != null)
        {
            //gestiamo dove mettere l'arma (mano)
            Transform weaponHandTransform = player.Find("WeaponHand");

            if (weaponHandTransform == null)
            {
                Debug.LogWarning("Oggetto 'WeaponHands' non trovato come figlio del Player. L'arma verrà attaccata al Player.");
                weaponHandTransform = player;
            }

            Weapon newWeaponInstance = Instantiate(_weaponPrefab);
            newWeaponInstance.transform.SetParent(weaponHandTransform);

            
            if (newWeaponInstance.Grip != null)
            {
                
                newWeaponInstance.transform.localPosition = -newWeaponInstance.Grip.localPosition;
                newWeaponInstance.transform.localRotation = Quaternion.identity;
            }
            else
            {
               //se manca il Grip la settiamo come possibile
                newWeaponInstance.transform.localPosition = Vector3.zero;
                newWeaponInstance.transform.localRotation = Quaternion.identity;
            }
        }

        
        Destroy(gameObject);
    }
}
