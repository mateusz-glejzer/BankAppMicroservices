namespace Graph;

public class Node
{
    public int Value { get; set; }

    public List<Connection> Connections = new ();
}