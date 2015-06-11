using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.ServiceModel.Channels;
using System.IO;

namespace PTZCameraTester
{
    class PelcoBinding
    {

        public static System.ServiceModel.Channels.Binding CreateCustomBinding()
        {
            var transport = new HttpTransportBindingElement();
            // disable http keepalive
            transport.KeepAliveEnabled = false;

            var encoding = new PelcoTextMessageBindingElement();

            return new CustomBinding(encoding, transport);
        }

        class XmlWriterNoDefaultNs : XmlTextWriter
        {

            public XmlWriterNoDefaultNs(StreamWriter sw) : base(sw) { }

            public override void WriteStartElement(string prefix, string localName, string ns)
            {
                if (ns.StartsWith("urn:schemas-pelco-com:service"))
                {
                    prefix = "u";
                }
                base.WriteStartElement(prefix, localName, ns);
            }
        }

        // see http://msdn2.microsoft.com/en-us/library/ms751486.aspx
        class PelcoTextMessageEncoder : MessageEncoder
        {
            public override string ContentType
            {
                get { return "text/xml; charset=utf-8"; }
            }

            public override string MediaType
            {
                get { return "text/xml"; }
            }

            public override bool IsContentTypeSupported(string contentType)
            {
                return base.IsContentTypeSupported(contentType.Replace("\"", ""));
            }

            public override MessageVersion MessageVersion
            {
                get { return MessageVersion.Soap11; }
            }

            public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
            {
                byte[] msgContents = new byte[buffer.Count];
                Array.Copy(buffer.Array, buffer.Offset, msgContents, 0, msgContents.Length);
                bufferManager.ReturnBuffer(buffer.Array);

                return ReadMessage(new MemoryStream(msgContents), int.MaxValue);
            }

            public override Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType)
            {
                return Message.CreateMessage(XmlReader.Create(stream), maxSizeOfHeaders, MessageVersion);
            }

            public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
            {
                MemoryStream stream = new MemoryStream();
                XmlWriter writer = new XmlWriterNoDefaultNs(new StreamWriter(stream, new UTF8Encoding(false)));
                message.WriteMessage(writer);
                writer.Flush(); // make sure out MemoryStream is updated

                byte[] messageBytes = stream.GetBuffer();
                int messageLength = (int)stream.Position;
                writer.Close();
                stream.Close();

                int totalLength = messageLength + messageOffset;
                byte[] totalBytes = bufferManager.TakeBuffer(totalLength);
                Array.Copy(messageBytes, 0, totalBytes, messageOffset, messageLength);

                ArraySegment<byte> byteArray = new ArraySegment<byte>(totalBytes, messageOffset, messageLength);
                return byteArray;
            }

            public override void WriteMessage(Message message, System.IO.Stream stream)
            {
                XmlWriter writer = new XmlWriterNoDefaultNs(new StreamWriter(stream, new UTF8Encoding(false)));
                message.WriteMessage(writer);
                writer.Close();
            }
        }

        class PelcoTextMessageEncoderFactory : MessageEncoderFactory
        {

            private MessageEncoder encoder = new PelcoTextMessageEncoder();

            public override MessageEncoder Encoder
            {
                get { return encoder; }
            }

            public override MessageVersion MessageVersion
            {
                get { return MessageVersion.Soap11; }
            }
        }

        class PelcoTextMessageBindingElement : MessageEncodingBindingElement
        {
            public override MessageEncoderFactory CreateMessageEncoderFactory()
            {
                return new PelcoTextMessageEncoderFactory();
            }

            public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
            {
                // this isn't in the example but seems to be necessary
                context.BindingParameters.Add(this);
                return context.BuildInnerChannelFactory<TChannel>();
            }

            public override MessageVersion MessageVersion
            {
                get
                {
                    return MessageVersion.Soap11;
                }
                set
                {
                    if (value != MessageVersion.Soap11)
                        throw new NotImplementedException();
                }
            }

            public override BindingElement Clone()
            {
                return new PelcoTextMessageBindingElement();
            }
        }
    }
}
