using System.Data;

namespace SalesSoftware.Dal.Interfaces;

public interface IBaseConnection : IDisposable
{
    public IDbConnection CreateConnection();
}
