using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HUData", menuName = "Datos/HUData")]
public class HUData : ScriptableObject
{
    public List<HU> listaHUs = new List<HU>();
}