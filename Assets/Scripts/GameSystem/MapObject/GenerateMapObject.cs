using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class GenerateMapObject : MonoBehaviour
    {
        public enum RoadPosition
        {
            North,
            East,
            South,
            West
        }
        public enum MapObjectType
        {
            Wall,
            Door,
            Collectible
        }

        [SerializeField]
        private List<Transform> _spawnPositions;

        [Header("Door")]
        [SerializeField]
        private GameObject _doorPrefab;
        [Header("Collectible")]
        [SerializeField]
        private float _offset = 2f;
        [SerializeField]
        private GameObject _collectiblePrefab;
        [Header("Wall")]
        [SerializeField]
        private float _rotation = 90f;
        [SerializeField]
        private GameObject _wallPrefab;

        private List<GameObject> _objects;

        // Start is called before the first frame update
        void Start()
        {
            Generate();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SetPositionList (in GameObject[] positionTab)
        {
            foreach(GameObject obj in positionTab)
            {
                _spawnPositions.Add(obj.transform);
            }
        }

        private GameObject InstantiateMapObject(MapObjectType type, Transform spawnTransform)
        {
            Debug.Log("Instantiante " + type.ToString() + " object");
            if (type == MapObjectType.Collectible || type == MapObjectType.Door)
            {
                RoadPosition roadPos = (RoadPosition)Random.Range(0, 5);
                Vector3 finalPosition = spawnTransform.position;
                if (roadPos == RoadPosition.North)
                {
                    finalPosition += spawnTransform.up * _offset;
                }
                else if (roadPos == RoadPosition.East)
                {
                    finalPosition += spawnTransform.right * _offset;
                }
                else if (roadPos == RoadPosition.South)
                {
                    finalPosition += -spawnTransform.up * _offset;
                }
                else if (roadPos == RoadPosition.West)
                {
                    finalPosition += -spawnTransform.right * _offset;
                }
                return Instantiate(_collectiblePrefab, finalPosition, spawnTransform.rotation);
            }
            else if (type == MapObjectType.Wall)
            {
                RoadPosition roadPos = (RoadPosition)Random.Range(0, 5);
                Quaternion finalRotation = spawnTransform.rotation;
                finalRotation *= Quaternion.Euler(0f,0f, _rotation * (int)roadPos);
                return Instantiate(_wallPrefab, spawnTransform.position, finalRotation);
            }
            //else if (type == MapObjectType.Door)
            //{
            //   return Instantiate(_doorPrefab, spawnTransform.position, spawnTransform.rotation);
            //}
            return null;
        }
        public void Generate(bool isFirstLap = false)
        {
            _objects = new List<GameObject>();
            for (int i=isFirstLap?1:0;i<_spawnPositions.Count;i++)
            {
                _objects.Add(InstantiateMapObject((MapObjectType)Random.Range(0, 3), _spawnPositions[i]));
            }
        }

        public void Regenerate()
        {
            for (int i = 0; i < _objects.Count; i++)
            {
                if (_objects[i] != null )
                {
                    GameObject.Destroy(_objects[i]);
                }
            }
            _objects.Clear();
            Generate();
        }
    }
}
