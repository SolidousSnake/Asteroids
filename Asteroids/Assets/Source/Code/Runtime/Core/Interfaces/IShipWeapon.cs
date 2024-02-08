using Cysharp.Threading.Tasks;

namespace Code.Runtime.Infrastructure.Interfaces
{
    public interface IShipWeapon
    {
        public UniTaskVoid Use();
    }
}
