using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Text cardName;
    [SerializeField] private Text cardDescription;

    [SerializeField] private Image cardImage;

    [SerializeField] private Text manaCost;
    [SerializeField] private Text hp;
    [SerializeField] private Text attack;

    public void Start()
    {
        MainManager.Display += DisplayData;
    }
    private void DisplayData(CardData dataToDisplay)
    {
        
        cardName.text = dataToDisplay.Name;
        cardDescription.text = dataToDisplay.Description;

        cardImage.sprite = dataToDisplay.CardImage;

        manaCost.text = dataToDisplay.CardEffect.affectManaValue.ToString();
        hp.text = dataToDisplay.CardEffect.affectHPValue.ToString();
        attack.text = dataToDisplay.CardEffect.attackValue.ToString();

    }
}
