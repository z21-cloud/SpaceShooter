using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SpaceShooter.Pooling
{
    public class ObjectPooling<T> where T: MonoBehaviour
    {
        private T prefab;
        private List<T> allObjects;
        private Stack<T> available;
        private Transform parent;

        public ObjectPooling(T prefab, int initialSize = 10, Transform parent = null)
        {
            this.prefab = prefab;
            this.parent = parent;

            allObjects = new List<T>(initialSize);
            available = new Stack<T>(initialSize);

            for (int i = 0; i < initialSize; i++)
            {
                var obj = CreateNewObject();
                available.Push(obj);
            }
        }

        private T CreateNewObject()
        {
            var obj = GameObject.Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            allObjects.Add(obj);
            return obj;
        }

        public T Get()
        {
            T obj;

            if(available.Count > 0)
            {
                obj = available.Pop();
            }
            else
            {
                obj = CreateNewObject();
                available.Pop();
            }

            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            if (obj == null) return;
            obj.gameObject.SetActive(false);
            available.Push(obj);
        }

        public void Clear()
        {
            foreach (var obj in allObjects)
            {
                if(obj != null)
                {
                    GameObject.Destroy(obj.gameObject);
                }
            }

            available.Clear();
            allObjects.Clear();
        }
    }
}

