using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardEffects : ScriptableObject
{
    [Header("Values")]
    public int affectManaValue;
    public int affectHPValue;
    public int attackValue; //affect player's speed 
}
