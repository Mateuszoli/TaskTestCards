using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class CardSaveData 
{
    public int dataEffectIndex;

    public string nameToSave;
    public string descriptionToSave;

    public int imageIndex;
}

public class MainManager : MonoBehaviour
{
    [Header("Player Placeholder")]
    [SerializeField] private Text playerMana;
    [SerializeField] private Text playerHp;
    [SerializeField] private Text playerSpeed;

    [Header("Card Effects")]
    [SerializeField] private CardEffects[] dataEffects;
    private int dataEffectIndex;

    [Header("Names")]
    [SerializeField] private string[] names;
    [SerializeField] private string[] descriptions;

    [SerializeField] private Sprite[] images;
    private int imageIndex;

    CardData dataToDisplay;
    public static event Action<CardData> Display;

    public void GenerateCard()
    {
        dataToDisplay = new CardData();

        dataEffectIndex = UnityEngine.Random.Range(0, dataEffects.Length);
        dataToDisplay.CardEffect = dataEffects[dataEffectIndex];

        dataToDisplay.Name = names[UnityEngine.Random.Range(0, names.Length)];
        dataToDisplay.Description = descriptions[UnityEngine.Random.Range(0, names.Length)];

        imageIndex = UnityEngine.Random.Range(0, names.Length);
        dataToDisplay.CardImage = images[imageIndex];

        Display(dataToDisplay);
    }
    public void SaveCard()
    {
        BinaryFormatter BF = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + "Card" + ".dat");
        CardSaveData DataToSave = new CardSaveData();

        DataToSave.dataEffectIndex = dataEffectIndex;

        DataToSave.nameToSave = dataToDisplay.Name;
        DataToSave.descriptionToSave = dataToDisplay.Description;

        DataToSave.imageIndex = imageIndex;

        BF.Serialize(file, DataToSave);
        file.Close();
    }
    public void LoadCard()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "Card" + ".dat"))
        {
            BinaryFormatter BF = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + "Card" + ".dat", FileMode.Open);
            CardSaveData DataToLoad = BF.Deserialize(file) as CardSaveData;
            file.Close();

            dataToDisplay = new CardData();

            dataEffectIndex = DataToLoad.dataEffectIndex;
            dataToDisplay.CardEffect = dataEffects[dataEffectIndex];

            dataToDisplay.Name = DataToLoad.nameToSave;
            dataToDisplay.Description = DataToLoad.descriptionToSave;

            imageIndex = DataToLoad.imageIndex;
            dataToDisplay.CardImage = images[imageIndex];

            Display(dataToDisplay);
        }  
    }
    public void ExecuteCard(bool increase)
    {
        if(dataToDisplay != null)
        {
            if (increase)
            {
                IncreaseStats();
            }
            else
            {
                DecreaseStats();
            }
        }
    }
    private void IncreaseStats()
    {
        int auxInt;
        auxInt = int.Parse(playerHp.text);
        auxInt += dataToDisplay.CardEffect.affectHPValue;
        playerHp.text = auxInt.ToString();

        auxInt = int.Parse(playerMana.text);
        auxInt += dataToDisplay.CardEffect.affectManaValue;
        playerMana.text = auxInt.ToString();

        auxInt = int.Parse(playerSpeed.text);
        auxInt += dataToDisplay.CardEffect.attackValue;
        playerSpeed.text = auxInt.ToString();
    }
    private void DecreaseStats()
    {
        int auxInt;
        auxInt = int.Parse(playerHp.text);
        auxInt -= dataToDisplay.CardEffect.affectHPValue;
        playerHp.text = auxInt.ToString();

        auxInt = int.Parse(playerMana.text);
        auxInt -= dataToDisplay.CardEffect.affectManaValue;
        playerMana.text = auxInt.ToString();

        auxInt = int.Parse(playerSpeed.text);
        auxInt -= dataToDisplay.CardEffect.attackValue;
        playerSpeed.text = auxInt.ToString();
    }
}
