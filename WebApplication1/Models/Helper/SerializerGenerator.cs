using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.PersonalTrainersModels;

namespace WebApplication1.Models.Helper
{
    public class SerializerGenerator
    {
        public D SerializeObject<T,D>(ref T Input,ref D output)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(Input);
                output = (D)(object)JsonConvert.DeserializeObject<PersonalTrainers>(jsonString);
                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
