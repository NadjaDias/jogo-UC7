using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Arma" , menuName = "Novo Item/ Arma")]
public class Arma : Item
{
    public bool ehMagia;
    public int dano;
    public int danoAdicional;
    // Start is called before the first frame update
    public override string Nome()
    {
        return nome;
    }
    public override string Descricao()
    {
        return descricao;
    }
    public override Sprite sprite()
    {
        return sprite;
    }
    public  override GameObject ItemPrefab()
    {
        return itemPrefab;
    }
    public bool ehMagico()
    {
        return ehMagico;
    }
    public int Dano()
    {
        return dano;
    }
    public int DanoAdicional()
    {
        return danoAdicional;
    }
        

}
