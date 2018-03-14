using System.IO;

namespace ManageSales.Services
{
    public interface ISaleServices
    {
        void SaveData(Stream stream);
    }
}
