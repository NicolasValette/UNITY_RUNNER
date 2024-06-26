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

        [Header("Object generated")]
        [Tooltip("Select object to generate along the spline")]
        [SerializeField]
        private bool _door;
        [SerializeField]
        private bool _collectible;
        [SerializeField]
        private bool _wall;
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
        private List<MapObjectType> _selectedObject;
        

        // Start is called before the first frame update
        void Start()
        {
            BuildSelectedObjectList();
            Generate();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void BuildSelectedObjectList()
        {
            _selectedObject = new List<MapObjectType>();
            if (_door)
                _selectedObject.Add(MapObjectType.Door);
            if (_wall)
                _selectedObject.Add(MapObjectType.Wall);
            if (_collectible)
                _selectedObject.Add(MapObjectType.Collectible);
        }
        public void SetPositionList (in GameObject[] positionTab)
        {
            foreach(GameObject obj in positionTab)
            {
                _spawnPositions.Add(obj.transform);
            }
        }

        private GameObject InstantiateMapObject(MapObjectType type, Transform spawnTransform, bool verbose = false)
        {
            if (verbose)
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
        private MapObjectType ChooseMapObjectType()
        {
            int indice = Random.Range(0, _selectedObject.Count);
            return _selectedObject[indice];
        }
        public void Generate(bool isFirstLap = false)
        {
            _objects = new List<GameObject>();
            for (int i=isFirstLap?1:0;i<_spawnPositions.Count;i++)
            {
                _objects.Add(InstantiateMapObject(ChooseMapObjectType(), _spawnPositions[i]));
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
