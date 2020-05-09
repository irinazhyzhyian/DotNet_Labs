namespace Lab2
{
    internal interface INameAndCopy
    {
        string Name { get; set; }
        object DeepCopy();

    }
}