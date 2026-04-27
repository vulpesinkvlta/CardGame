namespace Core.Platform
{
    public interface ISaveService
    {
        void Save(string key, string json);
        string Load(string key);
        bool HasKey(string key);
    }
}
