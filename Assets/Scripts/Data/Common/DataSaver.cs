using System.IO;
using System.Text;

namespace PFS.Data.Common.dataSaver
{
    public class DataSaver
    {
        public void JsonStringSave(string filePath, string jsonString)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            byte[] data = new byte[jsonString.Length];

            data = Encoding.UTF8.GetBytes(jsonString);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }
    }
}
