using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InstanceByArea : MonoBehaviour
{

    
    [SerializeField] GameObject itenPrefab;
    [SerializeField] string itenInstanceType = "Itens";
    [HideInInspector] public List<Areas> itenAreas = new List<Areas>(); //Areas do gol
    [SerializeField] int areaLines, areaColuns;
    [SerializeField] int minItens, maxItens;
    public float width, height, margin;
    

    //Lista de itens instanciados
    internal List<GameObject> ItenInstances = new List<GameObject>();        //Instancias criadas
    //Lista de area
    List<int> areasIDs;

    #if UNITY_EDITOR
    private void OnValidate()
    {
        if(areaLines <= 0){
            Debug.Log("Precisa ter pelo menos UMA linha");
            areaLines = 1;
        }

        if(areaColuns <= 0){
            Debug.Log("Precisa ter pelo menos UMA coluna");
            areaColuns = 1;
        }

        int result = (areaLines * areaColuns);
        if(maxItens > result)
        {
            Debug.Log("MaxItens atingiu valor maximo do maximo de areas");
            maxItens = result;
        }

        if(minItens > maxItens){
            Debug.Log("MinItens passou do calor de max Itens");
            minItens = maxItens;
        }
    }
    #endif
    
    internal virtual void Start()
    {
        if(itenAreas.Count <= 0){
            CreateAreasAndSave();
        }
    }

    //Cria as areas do gol
    public void CreateAreasAndSave (){
        itenAreas = CreateAreas();
    }
      
    //Cria os Itens da forma que foi programado
    public void Create()
    {
        if(itenAreas.Count <= 0){
            CreateAreasAndSave();
            print("Gol não cortado");
        }

        DesativateItens();
        int ItensInThisRound = ReturnNumberOfItens();
        areasIDs = ReturnItensIDs(ItensInThisRound);

        for (int i = 0; i < ItensInThisRound; i++)
        {
            Vector3 position = GetVectorPositionByArea(itenAreas[areasIDs[i]], margin);
            AddInstances(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
            //ItenInstances.Add(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
        }
    }
    //Cria os Itens da forma que foi programado (min, max)
    public void Create(int min, int max)
    {

        this.minItens = min < 8? min : 0;
        this.maxItens = max < 9? max : 9;

        print("Criando desafios");
        if(itenAreas.Count <= 0){
            CreateAreasAndSave();
            print("Gol não cortado");
        }

        DesativateItens();
        int ItensInThisRound = ReturnNumberOfItens();
        areasIDs = ReturnItensIDs(ItensInThisRound);

        for (int i = 0; i < ItensInThisRound; i++)
        {
            Vector3 position = GetVectorPositionByArea(itenAreas[areasIDs[i]], margin);
            AddInstances(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
            //ItenInstances.Add(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
        }
    }
    //Cria os Itens com numero definido
    public void Create(int Itens)
    {
        if(itenAreas.Count <= 0){
            CreateAreasAndSave();
        }

        DesativateItens();
        int ItensInThisRound = Itens;
        areasIDs = ReturnItensIDs(ItensInThisRound);

        for (int i = 0; i < ItensInThisRound; i++)
        {
            Vector3 position = GetVectorPositionByArea(itenAreas[areasIDs[i]], margin);
            AddInstances(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
            //ItenInstances.Add(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
        }
    }
    //Cria os Itens desativando ou não os antigos
    public void Create(bool desativate)
    {
        
        if(itenAreas.Count <= 0){
            CreateAreasAndSave();
        }
        int instanceNumber = 0;
        if(desativate){
            DesativateItens();
        }else{
            instanceNumber = getActualAtiveItens();
        }

        int ItensInThisRound = ReturnNumberOfItens();
        areasIDs = ReturnItensIDs(ItensInThisRound);

        if(ItensInThisRound < instanceNumber)
            ItensInThisRound = instanceNumber;

        for (int i = instanceNumber; i < ItensInThisRound; i++)
        {
            Vector3 position = GetVectorPositionByArea(itenAreas[areasIDs[i]], margin);
            AddInstances(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
            //ItenInstances.Add(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
        }
    }
    //Cria os Itens desativando ou não os antigos (min, max)
    public void Create(bool desativate, int min, int max)
    {

        this.minItens = min < 8? min : 0;
        this.maxItens = max < 9? max : 9;

        if(itenAreas.Count <= 0){
            CreateAreasAndSave();
        }
        int instanceNumber = 0;
        if(desativate){
            DesativateItens();
        }else{
            instanceNumber = getActualAtiveItens();
        }

        int ItensInThisRound = ReturnNumberOfItens();
        areasIDs = ReturnItensIDs(ItensInThisRound);

        if(ItensInThisRound < instanceNumber)
            ItensInThisRound = instanceNumber;

        for (int i = instanceNumber; i < ItensInThisRound; i++)
        {
            Vector3 position = GetVectorPositionByArea(itenAreas[areasIDs[i]], margin);
            AddInstances(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
            //ItenInstances.Add(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
        }
    }
    //Cria os Itens desativando ou não os antigos com numero definido
    public void Create(int Itens, bool desativate)
    {
        if(itenAreas.Count <= 0){
            CreateAreasAndSave();
        }

        int instanceNumber = 0;
        if(desativate){
            DesativateItens();
        }else{
            instanceNumber = getActualAtiveItens();
        }

        int ItensInThisRound = Itens;
        areasIDs = ReturnItensIDs(ItensInThisRound);

        if(ItensInThisRound < instanceNumber)
            ItensInThisRound = instanceNumber;

        for (int i = instanceNumber; i < ItensInThisRound; i++)
        {
            Vector3 position = GetVectorPositionByArea(itenAreas[areasIDs[i]], margin);
            AddInstances(Instancier.metod.Instantiate(itenPrefab, itenInstanceType, maxItens, position, transform));
        }
    }


    internal virtual void AddInstances (GameObject gameObject){
        ItenInstances.Add(gameObject);
    }
    
    //Retorna quantos Itens estão ativos agora
    public int getActualAtiveItens (){
        int instances = 0;
        foreach(GameObject g in ItenInstances){
            if(g.activeSelf){
                instances ++;
            }
        }
        return instances;
    }
    //Desativa todos os chalenges
    bool DesativateItens()
    {
        foreach(GameObject g in ItenInstances)
        {
            g.SetActive(false);
        }
        return true;
    }
    //Retorna numero id random para seleção de areas
    List<int> ReturnItensIDs(int maxIDs)
    {
        List<int> ids = new List<int>();

        for(int i = 0; i < maxIDs;)
        {
            int result = (areaLines * areaColuns);
            int id =  Random.Range(0, result);
            if (!ids.Contains(id))
            {
                ids.Add(id);
                i++;
            }
        }

        return ids;
    }
    //Retorna o numero de objetos dessa rodada
    int ReturnNumberOfItens()
    {
        return Random.Range(this.minItens, this.maxItens);
    }
    //Retorna o numero de objetos
    int ReturnNumberOfItens(int min, int max)
    {
        return Random.Range(min, max);
    }
    //Corta as areas do gol
    List<Areas> CreateAreas()
    {
        Debug.Log("Criado");

        float dividedWith   =   width / areaColuns;
        float dividedHeight =   height / areaLines;
        Vector3 position = transform.position;

        List<Areas> nAreas = new List<Areas>();
        for (int i = 0; i < areaColuns; i++)
        {
            float nWith = dividedWith * i;
            for (int y = 0; y < areaLines; y++)
            {
                float nHeight = dividedHeight * y;
                nAreas.Add(new Areas((nWith  + position.x) - width * 0.5f, (nHeight + position.y) - height * 0.5f, dividedWith, dividedHeight));
            }
        }

        return nAreas;
    }
    //Pega uma lista de vetores para cada area
    List<Vector3> GetVectorPositionByArea(List<Areas> areas)
    {
        List<Vector3> pos = new List<Vector3>();
        
        foreach(Areas area in areas)
        {
            pos.Add(GetVectorPosition(area.x, area.y, area.x2, area.y2));
        }
        return pos;
    }
    //Pega uma posição com base em uma area
    Vector3 GetVectorPositionByArea(Areas area)
    {
        return GetVectorPosition(area.x, area.y, area.x2, area.y2);
    }
    //Pega uma posição com base em uma area com margem
    Vector3 GetVectorPositionByArea(Areas area, float margin)
    {
        return GetVectorPosition(area.x, area.y, area.x2, area.y2, margin);
    }
    //Pega uma posição aleatoria das areas
    Vector3 GetVectorPosition(float x, float y, float x2, float y2)
    {
        float xx = Random.Range(x, x2);
        float yy = Random.Range(y, y2);
        return new Vector3(xx, yy, transform.position.z);
    }
    //Pega uma posição aleatoria das areas com margem
    Vector3 GetVectorPosition(float x, float y, float x2, float y2, float margin)
    {

        float marginx = margin;
        float marginy = margin;

        if(y == y2){
            marginy = 0;
        }

        if(x == x2){
            marginx = 0;
        }

        float clampx1 = Mathf.Clamp(x + marginx, x, (x + x2) / 2);
        float clampx2 = Mathf.Clamp(x2 - marginx, (x + x2) / 2, x2);
        float clampy1 = Mathf.Clamp(y + marginy, y, (y + y2) / 2);
        float clampy2 = Mathf.Clamp(y2 - marginy, (y + y2) / 2, y2);

        float xx = Random.Range(clampx1, clampx2);
        float yy = Random.Range(clampy1, clampy2);
        
        return new Vector3(xx, yy, transform.position.z);
    }
    //excluir em update
    List<Vector3> GetRandomListItens(int quanty, List<Vector3> list)
    {
        List<Vector3> randomItens = new List<Vector3>();
        for (int i = 0; i < quanty;)
        {
            Vector3 nPos = list[Random.Range(0, list.Count)];
            if (randomItens.Contains(nPos))
            {
                randomItens.Add(nPos);
                i++;
            }
        }
        return randomItens;
    }

    //Classe das areas de gol
    [System.Serializable]
    public class Areas
    {
        
        public float x, y, x2, y2, width, height;

        public Areas(float x, float y, float width, float height)
        {
            this.x = x;
            this.y = y;
            this.x2 = x + width;
            this.y2 = y + height;
            this.width = width;
            this.height = height;
        }

    }
}
