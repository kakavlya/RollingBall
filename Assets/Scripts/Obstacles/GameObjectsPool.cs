using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    public void Initialize()
    {
        this._camera = Camera.main;

        for(int i =0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(_template, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    public void DisableObjectAbroadTheScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, 0.5f));
        foreach (var item in _pool)
        {
            if (item.activeSelf)
            {
                if (item.transform.position.x < disablePoint.x)
                {
                    item.SetActive(false);
                }
                    
            }
        }
    }

    public bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);
        return result != null;
    }

    public void ResetPool()
    {
        foreach(var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
