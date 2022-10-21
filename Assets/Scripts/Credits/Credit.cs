public class Credit{
    private readonly int _id;
    private readonly string _title;
    public string body;

    public Credit(int id, string title, string body){
        _id = id;
        _title = title;
        this.body = body;
    }

    public int ID => _id;
    public string Title => _title;
}