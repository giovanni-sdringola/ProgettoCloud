using ModelliComuni;
using System.ServiceModel;
using System.Xml.Serialization;

namespace SoapConverter.Business_Logics
{
    [ServiceContract]
    public interface ISoapService
    {

        [OperationContract]

        public string MeteoDelGiorno(string data);
    }
    public class SoapService : ISoapService
    {
        public string MeteoDelGiorno(string data)
        {
            Giorno giorno = ServiziComuni.ServiziComuni.DaiGiorno(data).Result;


            var soapSerializer = new XmlSerializer(giorno.GetType());

            using var stringWriter = new StringWriter();

            soapSerializer.Serialize(stringWriter, giorno);

            return stringWriter.ToString();

        }

    }
}
