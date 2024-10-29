using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public string nome;
    public string descricao;
    public Sprite sprite;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    public virtual string Nome()
    {
        return nome;
    }
    public virtual string Descricao()
    {
        return descricao;
    }
    /*public virtual Sprite sprite()
    {
        return sprite;
    }*/
    public virtual GameObject ItemPrefab()
    {
        return itemPrefab;
    }
}
