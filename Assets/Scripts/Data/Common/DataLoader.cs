using System.IO;
using System.Text;

namespace PFS.Data.Common.dataLoader
{
    public class DataLoader
    {
        public string GetJsonString(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] data = new byte[fs.Length];

            fs.Read(data, 0, data.Length);
            fs.Close();

            string jsonData = Encoding.UTF8.GetString(data);

            return jsonData;
        }
    }
}
