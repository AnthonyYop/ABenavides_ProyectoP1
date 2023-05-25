using System.Net;

namespace Proyecto.UAPI
{
    public class Crud <T>
    {
        public T[] Select(string Url)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = api.DownloadString(Url);
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T[]>(json);
                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("F jsjsjsj (" + ex.Message + ")");
            }
        }
        public T SelectById(string Url, int id)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = api.DownloadString(Url + "/" + id);
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                    return data;
                } 
            }
            catch (Exception ex)
            {

                throw new Exception("F x2 jsjsjsj (" + ex.Message + ")");
            }
        }
        public void Update(string Url, int id, T data)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    api.UploadString(Url + "/" + id, "PUT", json);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("F x3 jsjsjsj (" + ex.Message + ")");
            }
        }
        public T Insert(string Url, T data)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    json = api.UploadString(Url, "POST", json);
                    data = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
                    return data;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("F x4 xd jsjsjsj (" + ex.Message + ")");
            }
        }
        public void Delete(string Url, int id)
        {
            try
            {
                using (var api = new WebClient())
                {
                    api.Headers.Add("Content-Type", "application/json");
                    api.UploadString(Url + "/" + id, "DELETE", "");
                }
            }
            catch (Exception ex)
            {

                throw new Exception("F de final xd jsjsjsj (" + ex.Message + ")");
            }
        }
    }
}