using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public enum Weapontype
    {
        Null,
        Item1,
        Item2
    }
    public Weapontype weapontype;
}
