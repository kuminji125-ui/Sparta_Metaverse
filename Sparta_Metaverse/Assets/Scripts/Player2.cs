using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2 : MonoBehaviour
{
    public GameObject pet;
    public GameObject bear;

    private const string Pet_Key = "PetKey";

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        ReconnectPetToPlayer();
    }
    private void ReconnectPetToPlayer()
    {
        PetFollow petFollow = FindObjectOfType<PetFollow>();
        if (petFollow != null)
        {
            petFollow.target = this.transform;
            petFollow.transform.position = transform.position;
            petFollow.transform.SetParent(null);
        }
    }
    private void Start()
    {
        LoadPet();
    }
    private void LoadPet()
    {
        if (GameObject.FindObjectOfType<PetFollow>() != null)
        {
            return;
        }
        string petName = PlayerPrefs.GetString(Pet_Key, "None");
        GameObject petToSummon = null;
        if(petName == "Sushi")
        {
            petToSummon = pet;
        }else if(petName == "Bear")
        {
            petToSummon = bear;
        }
        if(petToSummon != null)
        {
            SummonPet(petToSummon);
        }
    }

    public void SummonPet(GameObject pet)
    {
        PetFollow existingPet = FindObjectOfType<PetFollow>();
        if(existingPet != null)
        {
            Destroy(existingPet.gameObject);
        }
        if(pet != null)
        {
            GameObject newPet = Instantiate(pet, transform.position, Quaternion.identity);
            DontDestroyOnLoad(newPet);
            PetFollow petFollow = newPet.GetComponent<PetFollow>();
            if(petFollow != null)
            {
                petFollow.target = transform;
            }
        }
    }

    public void BuyPetSushi()
    {
        SummonPet(pet);//½º½Ã
        PlayerPrefs.SetString(Pet_Key, "Sushi");
        PlayerPrefs.Save();
    }
    public void BuyPetBear()
    {
        SummonPet(bear);//°õ
        PlayerPrefs.SetString(Pet_Key, "Bear");
        PlayerPrefs.Save();
    }


}
