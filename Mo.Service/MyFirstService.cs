using System;
using System.Threading.Tasks;
using MagicOnion;
using MagicOnion.Server;
using Mo.Service.Interface;

namespace Mo.Service
{
    /// <summary>
    /// implement RPC service to Server Project.
    /// inherit ServiceBase<interface>, interface
    /// </summary>
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
    {
        // You can use async syntax directly.
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Logger.Debug($"Received:{x}, {y}");
            return await Task.FromResult(x + y);
        }
    }
}