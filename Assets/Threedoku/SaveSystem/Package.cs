[System.Serializable]
public struct Package <T>
{
    public int Index0;
    public int Index1;
    public T Element;

    public Package(int index0, int index1, T element)
    {
        Index0 = index0;
        Index1 = index1;
        Element = element;
    }
}
