using UnityEngine;

namespace DefaultNamespace.EnemyScriptableObjectPracticeSave
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "EnemySo", order = 0)]
    public class EnemySo : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private EnemyType _enemyType;
        [SerializeField] private Vector2 _position;
        [SerializeField] private Sprite _sprite;

        public string GetId()
        {
            return _id;
        }

        public EnemyType GetEnemyType()
        {
            return _enemyType;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public Sprite GetSprite()
        {
            return _sprite;
        }
    }

    public enum EnemyType
    {
        Melee,
        Ranged,
        Mage
    }
}