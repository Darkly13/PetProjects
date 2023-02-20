using UnityEngine;
using System.Collections.Generic;

public class FieldCellsPool
{
    private FieldCell _prefab;
    private Transform _container;
    private List<FieldCell> _pool;

    public FieldCellsPool(FieldCell prefab, Transform container, int count)
    {
        _prefab = prefab;
        _container = container;

        CreatePool(count);
    }

    public FieldCell GetElement()
    {
        if (HasFreeElement(out FieldCell elemet))
            return elemet;
        else
            return CreateObject();
    }

    private void CreatePool(int count)
    {
        _pool = new List<FieldCell>();
        for(int i = 0; i<count; i++)
        {
            CreateObject();
        }
    }

    private FieldCell CreateObject()
    {
        FieldCell createdObject = Object.Instantiate(_prefab, _container);
        createdObject.gameObject.SetActive(false);
        _pool.Add(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out FieldCell element)
    {
        foreach(var cell in _pool)
        {
            if (!cell.gameObject.activeInHierarchy)
            {
                element = cell;
                return true;
            }
        }

        element = null;
        return false;
    }
}
