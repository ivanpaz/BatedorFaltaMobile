using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instancier : MonoBehaviour  
{
    public static Instancier metod;
    [SerializeField] Dictionary<string, InstanceType> mInstances = new Dictionary<string, InstanceType>();

    public void Awake()
    {
        if(metod == null)
        {
            metod = this;
            DontDestroyOnLoad(metod);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject Instantiate(GameObject instance, string type)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if(instanceType != null)
            {
                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject);
                        return gObject;
                    }
                    else
                    {
                        Debug.Log("Precisa desativar");
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    public GameObject Instantiate(GameObject instance, string type, Transform parent)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if (instanceType != null)
            {
                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject, parent);
                        return gObject;
                    }
                    else
                    {
                        Debug.Log("Precisa desativar");
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type, parent);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance, parent);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance, parent);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance , parent);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    public GameObject Instantiate(GameObject instance, string type, Vector3 pos)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if (instanceType != null)
            {
                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject, pos);
                        return gObject;
                    }
                    else
                    {
                        Debug.Log("Precisa desativar");
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type, pos);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance, pos);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance, pos);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance, pos);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    public GameObject Instantiate(GameObject instance, string type, Vector3 pos, Transform parent)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if (instanceType != null)
            {
                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject, pos, parent);
                        return gObject;
                    }
                    else
                    {
                        Debug.Log("Precisa desativar");
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type, pos, parent);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance, pos, parent);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance, pos, parent);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance, pos, parent);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    public GameObject Instantiate(GameObject instance, string type, int maxQuant)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if (instanceType != null)
            {
                //Seto a nova maxQuant
                instanceType.maxQuant = maxQuant;

                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject);
                        return gObject;
                    }
                    else
                    {
                        Debug.Log("Precisa desativar");
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type, maxQuant);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type, maxQuant);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type, maxQuant);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    public GameObject Instantiate(GameObject instance, string type, int maxQuant, Transform parent)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if (instanceType != null)
            {
                instanceType.maxQuant = maxQuant;

                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject, parent);
                        return gObject;
                    }
                    else
                    {
                        Debug.Log("Precisa desativar");
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type, maxQuant, parent);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance, parent);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type, maxQuant);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance, parent);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type, maxQuant);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance, parent);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    public GameObject Instantiate(GameObject instance, string type, int maxQuant, Vector3 pos)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if (instanceType != null)
            {
                instanceType.maxQuant = maxQuant;

                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject, pos);
                        return gObject;
                    }
                    else
                    {
                        Debug.Log("Precisa desativar");
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type, maxQuant, pos);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance, pos);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type, maxQuant);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance, pos);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type, maxQuant);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance, pos);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    public GameObject Instantiate(GameObject instance, string type, int maxQuant, Vector3 pos, Transform parent)
    {
        if (HasType(type))
        {
            //Pego a classe de instanciamento
            InstanceType instanceType = GetInstanceType(type);
            if (instanceType != null)
            {
                instanceType.maxQuant = maxQuant;
                
                if (reachMax(instanceType))
                {

                    if (CheckIfExistInstance(instance, instanceType.objects))
                    {
                        //O numero de objetos passou do limite
                        GameObject gObject = ActiveInstance(instanceType.objects);
                        ResetInstance(gObject, pos, parent);
                        return gObject;
                    }
                    else
                    {
                        DesativateWithList(instanceType);
                        return Instantiate(instance, type, maxQuant, pos, parent);
                    }
                }
                else
                {
                    GameObject gObject = InstantiateGameObject(instance, pos, parent);
                    instanceType.objects.Add(gObject);
                    return gObject;
                }
            }
            else
            {
                //Cria a classe de instanciamento
                instanceType = new InstanceType(type, maxQuant);
                instanceType.objects = new List<GameObject>();
                GameObject gObject = InstantiateGameObject(instance, pos, parent);
                instanceType.objects.Add(gObject);
                mInstances.Add(type, instanceType);
                return gObject;
            }
        }
        else
        {
            //Cria a classe de instanciamento
            InstanceType instanceType = new InstanceType(type, maxQuant);
            instanceType.objects = new List<GameObject>();
            GameObject gObject = InstantiateGameObject(instance, pos, parent);
            instanceType.objects.Add(gObject);
            mInstances.Add(type, instanceType);
            return gObject;
        }
    }

    //Existe o tipo de objeto
    bool HasType(string type)
    {
        if(mInstances == null)
        {
            return false;
        }

        return mInstances.ContainsKey(type);
    }

    //Pega a classe de instanciamento
    InstanceType GetInstanceType(string key)
    {
        InstanceType instanceType = null;
        if (mInstances.TryGetValue(key, out instanceType) == true)
        {
            return instanceType;
        }

        return instanceType;
    }

    //Verifica se atingiu ao maximo
    bool reachMax(InstanceType instanceType)
    {
        if (instanceType.objects != null)
        {
            if (instanceType.objects.Count >= instanceType.maxQuant)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //Checa se já existe uma instancia deste objeto
    bool CheckIfExistInstance(GameObject instance, List<GameObject> instances)
    {
        if(instances == null)
        {
            return false;
        }
        else
        {
            foreach (GameObject g in instances)
            {              
                if (g.activeSelf == false)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //Ativa e retorna o objeto ativado
    GameObject ActiveInstance(List<GameObject> instances)
    {
        foreach (GameObject g in instances)
        {
            if (g.activeSelf == false)
            {
                g.SetActive(true);
                return g;
            }
        }
        return null;
    }

    //Reseta o objetos
    void ResetInstance(GameObject obj)
    {
        //reseta
        obj.SetActive(false);
        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }
    void ResetInstance(GameObject obj, Transform parent)
    {
        obj.SetActive(false);
        obj.transform.parent = null;
        obj.transform.parent = parent;
        obj.transform.position = Vector3.zero;
        obj.SetActive(true);
    }
    void ResetInstance(GameObject obj, Vector3 pos)
    {
        obj.SetActive(false);
        obj.transform.position = pos;
        obj.SetActive(true);
    }
    void ResetInstance(GameObject obj, Vector3 pos, Transform parent)
    {
        obj.SetActive(false);
        obj.transform.parent = null;
        obj.transform.position = pos;
        obj.transform.parent = parent;
        obj.SetActive(true);
    }

    //Instanciamento
    GameObject InstantiateGameObject(GameObject instance) {
        GameObject obj = Instantiate(instance);
        return obj;
    }
    GameObject InstantiateGameObject(GameObject instance, Transform parent)
    {
        GameObject obj = Instantiate(instance);
        obj.transform.parent = parent;
        return obj;
    }
    GameObject InstantiateGameObject(GameObject instance, Vector3 pos)
    {
        GameObject obj = Instantiate(instance, pos, Quaternion.identity);
        return obj;
    }
    GameObject InstantiateGameObject(GameObject instance, Vector3 pos, Transform parent)
    {
        GameObject obj = Instantiate(instance, pos, Quaternion.identity);
        obj.transform.parent = parent;
        return obj;
    }

    //Desativate
    void DesativateWithList(InstanceType instanceType)
    {
        int listSize = instanceType.objects.Count -1;
        GameObject lastObject = instanceType.objects[listSize];
        lastObject.SetActive(false);
        instanceType.objects.RemoveAt(listSize);
        instanceType.objects.Insert(0, lastObject);
    }

    [System.Serializable]
    public class InstanceType
    {
        public string type;
        public int maxQuant = 5;
        public List<GameObject> objects;

        public InstanceType(){
        }

        public InstanceType(string type)
        {
            this.type = type;
        }

        public InstanceType(string type, int maxQuant) : this(type)
        {
            this.maxQuant = maxQuant;
        }

        public InstanceType(string type, int maxQuant, List<GameObject> objects) : this(type)
        {
            this.maxQuant = maxQuant;
            this.objects = objects;
        }
    }
}
