using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Character List", menuName = "ScriptableObjects/CharacterList")]
public class CharacterList : ScriptableObject
{
    [SerializeField] private Character[] characterList;

    public Character[] CharList => characterList;
}
