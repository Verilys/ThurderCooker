public class Singleton<T> where T : class, new()
{
    private static T instance;

    // 对外提供获取单例实例的方法
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    // 将构造函数设为私有，防止从外部实例化
    private Singleton() { }
}
