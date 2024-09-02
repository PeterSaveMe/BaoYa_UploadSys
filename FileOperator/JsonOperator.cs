namespace BaoYa_UploadSystem.FileOperator
{
    using Newtonsoft.Json;
    using System;
    using System.IO;

    public static class JsonHelper
    {
        /// <summary>
        /// 序列化对象为 JSON 字符串。
        /// </summary>
        /// <typeparam name="T">要序列化的对象类型。</typeparam>
        /// <param name="obj">要序列化的对象。</param>
        /// <param name="indented">是否格式化输出 JSON 字符串。</param>
        /// <returns>序列化后的 JSON 字符串。</returns>
        public static string Serialize<T>(T obj, bool indented = false)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            Formatting formatting = indented ? Formatting.Indented : Formatting.None;

            return JsonConvert.SerializeObject(obj, formatting, settings);
        }

        /// <summary>
        /// 反序列化 JSON 字符串为对象。
        /// </summary>
        /// <typeparam name="T">要反序列化的对象类型。</typeparam>
        /// <param name="json">JSON 字符串。</param>
        /// <returns>反序列化后的对象。</returns>
        public static T Deserialize<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                throw new ArgumentException("json 字符串不能为空或 null");
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将对象序列化为 JSON 并保存到文件。
        /// </summary>
        /// <typeparam name="T">要序列化的对象类型。</typeparam>
        /// <param name="obj">要序列化的对象。</param>
        /// <param name="filePath">文件路径。</param>
        /// <param name="indented">是否格式化输出 JSON 字符串。</param>
        public static void SerializeToFile<T>(T obj, string filePath, bool indented = false)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (!Directory.Exists(fileInfo.DirectoryName))
                Directory.CreateDirectory(fileInfo.DirectoryName);
            string json = Serialize(obj, indented);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// 从文件中反序列化 JSON 为对象。
        /// </summary>
        /// <typeparam name="T">要反序列化的对象类型。</typeparam>
        /// <param name="filePath">文件路径。</param>
        /// <returns>反序列化后的对象。</returns>
        public static T DeserializeFromFile<T>(string filePath) where T : new()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("文件未找到", filePath);
            }

            string json = File.ReadAllText(filePath);
            return Deserialize<T>(json);
        }
    }
}