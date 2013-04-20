using System;
using System.Runtime.Serialization;
using System.Xml;

namespace LunarBase.Library
{
    public class AuthenticationTokenSerializer : XmlObjectSerializer
    {
        string _userName;
        string _password;

        public AuthenticationTokenSerializer(string userName, string password)
        {
            _userName = userName;
            _password = password;
        }
        public override void WriteStartObject(XmlDictionaryWriter writer, Object graph)
        {
            //Not needed           
        }


        public override void WriteObjectContent(XmlDictionaryWriter writer, Object graph)
        {
            string authToken = string.Format("<UserId>00000000-0000-0000-0000-000000000000</UserId><UserName>{0}</UserName><Password>{1}</Password>", _userName, _password);

            writer.WriteRaw(authToken);
        }

        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            //Not needed
        }
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return true;
        }

        public override Object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return null; //not  needed 
        }
    }
}
