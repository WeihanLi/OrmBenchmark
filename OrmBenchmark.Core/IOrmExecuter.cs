using System.Collections.Generic;

namespace OrmBenchmark.Core
{
    public interface IOrmExecuter
    {
        string Name { get; }

        void Init(string connectionString);

        IPost GetItemAsObject(int id);

        IList<IPost> GetAllItemsAsObject();

        void Finish();
    }
}
