using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Chave", menuName = "Novo Item/ Chave")]
public class Chave : Item
{
    public int numeroChave;

    public override string Nome()
    {
        return nome;
    }
    public override string Descricao()
    {
        return descricao;
    }
    /*public override Sprite sprite()
    {
        return sprite;
    }*/
    public override GameObject ItemPrefab()
    {
        return itemPrefab;
    }
    public int NumeroChave()
    {
        return numeroChave;
    }
}