using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
   public Material enemyMaterial;
   public Color enemyColor;
   public string enemyTag;
   public float enemyMoveSpeed;
}
