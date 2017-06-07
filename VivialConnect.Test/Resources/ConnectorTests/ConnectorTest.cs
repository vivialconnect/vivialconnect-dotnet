using System.Collections.Generic;
using System.Linq;
using System.Net;

using NSubstitute;
using NUnit.Framework;
using VivialConnect.Http;
using VivialConnect.Resources.Connector;

namespace VivialConnect.Test.Resources.ConnectorTests
{
    [TestFixture]
    public class ConnectorTest : VcTest
    {
        public const int ConnectorId = 1;

        [Test]
        public void TestFindResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"connectors\":[{\"account_id\":10000,\"active\":true,\"callbacks\":[{\"date_created\":\"2017-05-25T22:07:48+00:00\",\"date_modified\":\"2017-05-25T22:07:48+00:00\",\"event_type\":\"incoming_fallback\",\"message_type\":\"text\",\"method\":\"POST\",\"url\":\"path/to/sms/fallback1\"},{\"date_created\":\"2017-05-26T01:25:00+00:00\",\"date_modified\":\"2017-05-26T01:25:00+00:00\",\"event_type\":\"incoming\",\"message_type\":\"voice\",\"method\":\"GET\",\"url\":\"path/to/sms/callback2\"},{\"date_created\":\"2017-05-30T17:31:48+00:00\",\"date_modified\":\"2017-05-30T17:31:48+00:00\",\"event_type\":\"incoming\",\"message_type\":\"text\",\"method\":\"GET\",\"url\":\"path/to/sms/callback2\"}],\"date_created\":\"2017-05-25T17:41:53+00:00\",\"date_modified\":\"2017-05-25T17:41:53+00:00\",\"id\":1,\"more_numbers\":false,\"name\":\"My1stconnector.\",\"phone_numbers\":[]}]}"
                                ));

            List<Connector> connectors = Connector.Find(client: client);
            Assert.NotNull(connectors);
        }

        [Test]
        public void TestFindSingleResponse()
        {
            Connector connector = FindSingleResponse();
            Assert.NotNull(connector);
        }

        [Test]
        public void TestCountResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"count\":1}"
                                ));

            int count = Connector.Count(client);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestSaveUpdateResponse()
        {
            Connector connector = FindSingleResponse();

            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"connector\":{\"account_id\":10000,\"active\":true,\"callbacks\":[{\"date_created\":\"2017-05-25T22:07:48+00:00\",\"date_modified\":\"2017-05-25T22:07:48+00:00\",\"event_type\":\"incoming_fallback\",\"message_type\":\"text\",\"method\":\"POST\",\"url\":\"path/to/sms/fallback1\"},{\"date_created\":\"2017-05-26T01:25:00+00:00\",\"date_modified\":\"2017-05-26T01:25:00+00:00\",\"event_type\":\"incoming\",\"message_type\":\"voice\",\"method\":\"GET\",\"url\":\"path/to/sms/callback2\"},{\"date_created\":\"2017-05-30T17:31:48+00:00\",\"date_modified\":\"2017-05-30T17:31:48+00:00\",\"event_type\":\"incoming\",\"message_type\":\"text\",\"method\":\"GET\",\"url\":\"path/to/sms/callback2\"}],\"date_created\":\"2017-05-25T17:41:53+00:00\",\"date_modified\":\"2017-05-25T17:41:53+00:00\",\"id\":1,\"more_numbers\":false,\"name\":\"My1stconnector.\",\"phone_numbers\":[{\"phone_number\":\"+13109991111\",\"phone_number_id\":7}]}}"
                                ));

            connector.Numbers.Add(new ConnectorNumber("+13109991111"));
            connector.Save(client);
            Assert.AreEqual(1, connector.Numbers.Count());
        }

        [Test]
        public void TestSaveNewResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.Created,
                                    "{\"connector\":{\"account_id\":10000,\"active\":true,\"callbacks\":[{\"date_created\":\"2017-06-06T05:17:10+00:00\",\"date_modified\":\"2017-06-06T05:17:10+00:00\",\"event_type\":\"incoming\",\"message_type\":\"text\",\"method\":\"POST\",\"url\":\"path/to/sms/callback1\"}],\"date_created\":\"2017-06-06T05:17:10+00:00\",\"date_modified\":\"2017-06-06T05:17:10+00:00\",\"id\":2,\"more_numbers\":false,\"name\":\"MyNewConnector\",\"phone_numbers\":[{\"phone_number\":\"+13109991111\",\"phone_number_id\":7}]}}"
                                ));

            Connector connector = new Connector();
            connector.Name = "My New Connector";
            connector.Callbacks.Add(new CallbackIncoming() { MessageType = MessageTypeEnum.Text, Url = "path/to/sms/callback1", Method = "POST" });
            connector.Numbers.Add(new ConnectorNumber("+13109991111"));
            connector.Save(client);
            Assert.AreEqual(false, connector.IsNew);
        }

        [Test]
        public void TestDeleteResponse()
        {
            Connector connector = FindSingleResponse();

            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.NoContent,
                                    null
                                ));

            bool results = connector.Delete(client);
            Assert.AreEqual(true, results);
        }

        public Connector FindSingleResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"connector\":{\"account_id\":10000,\"active\":true,\"callbacks\":[{\"date_created\":\"2017-05-25T22:07:48+00:00\",\"date_modified\":\"2017-05-25T22:07:48+00:00\",\"event_type\":\"incoming_fallback\",\"message_type\":\"text\",\"method\":\"POST\",\"url\":\"path/to/sms/fallback1\"},{\"date_created\":\"2017-05-26T01:25:00+00:00\",\"date_modified\":\"2017-05-26T01:25:00+00:00\",\"event_type\":\"incoming\",\"message_type\":\"voice\",\"method\":\"GET\",\"url\":\"path/to/sms/callback2\"},{\"date_created\":\"2017-05-30T17:31:48+00:00\",\"date_modified\":\"2017-05-30T17:31:48+00:00\",\"event_type\":\"incoming\",\"message_type\":\"text\",\"method\":\"GET\",\"url\":\"path/to/sms/callback2\"}],\"date_created\":\"2017-05-25T17:41:53+00:00\",\"date_modified\":\"2017-05-25T17:41:53+00:00\",\"id\":1,\"more_numbers\":false,\"name\":\"My1stconnector.\",\"phone_numbers\":[]}}"
                                ));

            return Connector.FindSingle(ConnectorId, client);
        }
    }
}
