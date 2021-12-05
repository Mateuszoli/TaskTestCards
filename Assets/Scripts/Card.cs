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

    public void DisplayData(CardData dataToDisplay)
    {
        cardName.text = dataToDisplay.name;
        cardDescription.text = dataToDisplay.description;

        cardImage.sprite = dataToDisplay.cardImage;

        manaCost.text = dataToDisplay.cardEffect.affectManaValue.ToString();
        hp.text = dataToDisplay.cardEffect.affectHPValue.ToString();
        attack.text = dataToDisplay.cardEffect.attackValue.ToString();

    }
}
