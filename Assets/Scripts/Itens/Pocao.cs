using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Pocao" , menuName = "Novo Item/ Poção")]
public class Pocao : Item
{
    public TipoPocao tipo;
    public enum TipoPocao { Cura, Magia, Defesa, Poder }
    public int tamanho;
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
    public TipoPocao Tipo()
    {
        return tipo;
    }
    public int Tamanho()
    {
        return tamanho; 
    }
}
