using System.Collections.Generic;

namespace OrmBenchmark.Core
{
    public interface IOrmExecuter
    {
        string Name { get; }

        void Init(string connectionStrong);

        IPost GetItemAsObject(int id);

        IList<IPost> GetAllItemsAsObject();

        void Finish();
    }
}