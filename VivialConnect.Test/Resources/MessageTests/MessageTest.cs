using System.Collections.Generic;
using System.Net;

using NSubstitute;
using NUnit.Framework;
using VivialConnect.Http;
using VivialConnect.Resources.Message;

namespace VivialConnect.Test.Resources.MessageTests
{
    [TestFixture]
    public class MessageTest : VcTest
    {
        public const int MessageId = 1;
        public const int AttachmentId = 1;

        [Test]
        public void TestFindResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"messages\":[{\"account_id\":10000,\"body\":\"Hello.\",\"connector_id\":null,\"date_created\":\"2017-04-27T21:05:56+00:00\",\"date_modified\":\"2017-04-27T21:06:20+00:00\",\"direction\":\"outbound-api\",\"error_code\":null,\"error_message\":null,\"from_number\":\"+13105559999\",\"id\":1,\"master_account_id\":10000,\"message_type\":\"local_sms\",\"num_media\":0,\"num_segments\":1,\"price\":75,\"price_currency\":\"USD\",\"sent\":\"2017-04-27T21:06:00+00:00\",\"status\":\"delivered\",\"to_number\":\"+13109995555\"},{\"account_id\":10000,\"body\":\"Goodbye.\",\"connector_id\":null,\"date_created\":\"2017-04-27T21:26:45+00:00\",\"date_modified\":\"2017-04-27T21:27:01+00:00\",\"direction\":\"outbound-api\",\"error_code\":null,\"error_message\":null,\"from_number\":\"+13105559999\",\"id\":2,\"master_account_id\":10000,\"message_type\":\"local_sms\",\"num_media\":0,\"num_segments\":1,\"price\":75,\"price_currency\":\"USD\",\"sent\":\"2017-04-27T21:26:56+00:00\",\"status\":\"delivered\",\"to_number\":\"+13109995555\"}]}"
                                ));

            List<Message> messages = Message.Find(client: client);
            Assert.NotNull(messages);
        }

        [Test]
        public void TestFindSingleResponse()
        {
            Message message = FindSingleResponse();
            Assert.NotNull(message);
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

            int count = Message.Count(client);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestAttachmentResponse()
        {
            Attachment attachment = AttachmentResponse();
            Assert.NotNull(attachment);
        }

        [Test]
        public void TestMediaResponse()
        {
            Attachment attachment = AttachmentResponse();

            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "����\0\u0010JFIF\0\u0001\u0001\0\0\u0001\0\u0001\0\0��\0;CREATOR: gd-jpeg v1.0 (using IJG JPEG v62), quality = 95\n��\0C\0\u0002\u0001\u0001\u0001\u0001\u0001\u0002\u0001\u0001\u0001\u0002\u0002\u0002\u0002",
                                    string.Empty,
                                    256,
                                    "image/jpeg",
                                    null,
                                    null,
                                    null,
                                    null,
                                    null
                                ));

            Media media = attachment.Media(client);
            Assert.NotNull(media);
        }

        [Test]
        public void TestSendResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"message\":{\"account_id\":10000,\"body\":\"My new text message!\",\"connector_id\":null,\"date_created\":\"2017-06-06T00:52:12+00:00\",\"date_modified\":\"2017-06-06T00:52:12+00:00\",\"direction\":\"outbound-api\",\"error_code\":null,\"error_message\":null,\"from_number\":\"+13105559999\",\"id\":3,\"master_account_id\":10000,\"message_type\":\"local_sms\",\"num_media\":0,\"num_segments\":1,\"price\":75,\"price_currency\":\"USD\",\"sent\":null,\"status\":\"accepted\",\"to_number\":\"+13109995555\"}}"
                                ));

            Message message = Message.Send("+13109995555", "+13105559999", "My new text message!", client: client);
            Assert.NotNull(message);
        }

        [Test]
        public void TestRedactResponse()
        {
            Message message = FindSingleResponse();

            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"message\":{\"account_id\":10000,\"body\":\"\",\"connector_id\":null,\"date_created\":\"2017-04-27T21:05:56+00:00\",\"date_modified\":\"2017-04-27T21:06:20+00:00\",\"direction\":\"outbound-api\",\"error_code\":null,\"error_message\":null,\"from_number\":\"+13105559999\",\"id\":1,\"master_account_id\":10000,\"message_type\":\"local_sms\",\"num_media\":0,\"num_segments\":1,\"price\":75,\"price_currency\":\"USD\",\"sent\":\"2017-04-27T21:06:00+00:00\",\"status\":\"delivered\",\"to_number\":\"+13109995555\"}}"
                                ));

            message.Redact(client);
            Assert.AreEqual(string.Empty, message.Body);
        }

        public Message FindSingleResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"message\":{\"account_id\":10000,\"body\":\"Hello.\",\"connector_id\":null,\"date_created\":\"2017-04-27T21:05:56+00:00\",\"date_modified\":\"2017-04-27T21:06:20+00:00\",\"direction\":\"outbound-api\",\"error_code\":null,\"error_message\":null,\"from_number\":\"+13105559999\",\"id\":1,\"master_account_id\":10000,\"message_type\":\"local_sms\",\"num_media\":0,\"num_segments\":1,\"price\":75,\"price_currency\":\"USD\",\"sent\":\"2017-04-27T21:06:00+00:00\",\"status\":\"delivered\",\"to_number\":\"+13109995555\"}}"
                                ));

            return Message.FindSingle(MessageId, client: client);
        }

        public Attachment AttachmentResponse()
        {
            Message message = FindSingleResponse();

            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"attachment\":{\"account_id\":10000,\"content_type\":\"image/jpeg\",\"date_created\":\"2017-04-28T16:34:32+00:00\",\"date_modified\":\"2017-04-28T16:34:32+00:00\",\"file_name\":\"myfile.jpg\",\"id\":1,\"key_name\":\"path/to/123abc/myfile.jpg\",\"message_id\":1,\"size\":256}}"
                                ));

            return message.Attachment(AttachmentId, client);
        }
    }
}
