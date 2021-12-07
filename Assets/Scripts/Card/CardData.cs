using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData : ScriptableObject
{
    private new string name;
    private string description;

    private Sprite cardImage;

    private CardEffects cardEffect;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Description
    {
        get { return description; }
        set { description = value; }
    }
    public Sprite CardImage
    {
        get { return cardImage; }
        set { cardImage = value; }
    }
    public CardEffects CardEffect
    {
        get { return cardEffect; }
        set { cardEffect = value; }
    }

}
