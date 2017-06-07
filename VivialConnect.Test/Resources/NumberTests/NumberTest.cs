using System.Collections.Generic;
using System.Net;

using NSubstitute;
using NUnit.Framework;
using VivialConnect.Http;
using VivialConnect.Resources.Number;

namespace VivialConnect.Test.Resources.NumberTests
{
    [TestFixture]
    public class NumberTest : VcTest
    {
        public const int NumberId = 1;

        [Test]
        public void TestFindResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"phone_numbers\":[{\"account_id\":10000,\"active\":true,\"address_requirements\":\"none\",\"capabilities\":{\"mms\":true,\"sms\":true,\"voice\":true},\"city\":\"BROCKWAY\",\"date_created\":\"2017-04-27T00:06:36+00:00\",\"date_modified\":\"2017-05-24T18:23:59+00:00\",\"id\":1,\"incoming_text_fallback_method\":null,\"incoming_text_fallback_url\":null,\"incoming_text_method\":null,\"incoming_text_url\":null,\"lata\":null,\"master_account_id\":10000,\"name\":\"Myupdatednumber.\",\"phone_number\":\"+13105559999\",\"phone_number_type\":\"local\",\"rate_center\":\"NTAHBCWY\",\"region\":\"CA\",\"status_text_url\":null,\"voice_forwarding_number\":null}]}"
                                ));

            List<Number> numbers = Number.Find(client: client);
            Assert.NotNull(numbers);
        }

        [Test]
        public void TestFindLocalResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"phone_numbers\":[{\"account_id\":10000,\"active\":true,\"address_requirements\":\"none\",\"capabilities\":{\"mms\":true,\"sms\":true,\"voice\":true},\"city\":\"BROCKWAY\",\"date_created\":\"2017-04-27T00:06:36+00:00\",\"date_modified\":\"2017-05-24T18:23:59+00:00\",\"id\":1,\"incoming_text_fallback_method\":null,\"incoming_text_fallback_url\":null,\"incoming_text_method\":null,\"incoming_text_url\":null,\"lata\":null,\"master_account_id\":10000,\"name\":\"Myupdatednumber.\",\"phone_number\":\"+13105559999\",\"phone_number_type\":\"local\",\"rate_center\":\"NTAHBCWY\",\"region\":\"CA\",\"status_text_url\":null,\"voice_forwarding_number\":null}]}"
                                ));

            List<Number> numbers = Number.Find(local: true, client: client);
            Assert.NotNull(numbers);
        }

        [Test]
        public void TestFindSingleResponse()
        {
            Number number = FindSingleResponse();
            Assert.NotNull(number);
        }

        [Test]
        public void TestFindSingleLocalResponse()
        {
            Number number = FindSingleLocalResponse();
            Assert.NotNull(number);
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

            int count = Number.Count(client: client);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestCountLocalResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"count\":1}"
                                ));

            int count = Number.Count(local: true, client: client);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestSaveResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"phone_number\":{\"account_id\":10000,\"active\":true,\"address_requirements\":\"none\",\"capabilities\":{\"mms\":true,\"sms\":true,\"voice\":true},\"city\":\"BROCKWAY\",\"date_created\":\"2017-04-27T00:06:36+00:00\",\"date_modified\":\"2017-06-06T07:18:22+00:00\",\"id\":1,\"incoming_text_fallback_method\":null,\"incoming_text_fallback_url\":null,\"incoming_text_method\":null,\"incoming_text_url\":null,\"lata\":null,\"master_account_id\":10000,\"name\":\"310-555-9999\",\"phone_number\":\"+13105559999\",\"phone_number_type\":\"local\",\"rate_center\":\"NTAHBCWY\",\"region\":\"CA\",\"status_text_url\":null,\"voice_forwarding_number\":null}}"
                                ));

            Number number = FindSingleResponse();
            number.Name = "310-555-9999";
            number.Save(client);
            Assert.AreEqual("310-555-9999", number.Name);
        }

        [Test]
        public void TestLookupResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"number_info\":{\"carrier\":{\"capabilities\":{\"deactivation_files\":false,\"device_lookup_api\":false,\"location_data\":false,\"mms_connection_status\":false,\"mms_dr\":false,\"sms_connection_status\":true,\"sms_fteu\":false,\"sms_handset_dr\":false,\"uaprof_in_mms_dr\":false},\"country\":\"US\",\"name\":\"TestingWireless\"},\"date_created\":\"2017-06-06T07:27:20+00:00\",\"date_modified\":\"2017-06-06T07:27:20+00:00\",\"device\":{\"error\":\"15012-Devicelookupisnotsupportedbythiscarrier.\",\"model\":null},\"phone_number\":\"+13105559999\"}}"
                                ));

            Number number = FindSingleResponse();
            NumberInfo info = number.Lookup(client);
            Assert.NotNull(info);
        }

        [Test]
        public void TestDeleteResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.NoContent,
                                    null
                                ));

            Number number = FindSingleResponse();
            bool results = number.Delete(client);
            Assert.AreEqual(true, results);
        }

        [Test]
        public void TestFindAvailableResponse()
        {
            List<NumberAvailable> available = FindAvailableResponse();
            Assert.NotNull(available);
        }

        [Test]
        public void TestBuyResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.Created,
                                    "{\"phone_number\":{\"account_id\":10000,\"active\":true,\"address_requirements\":null,\"capabilities\":{\"mms\":true,\"sms\":true,\"voice\":true},\"city\":\"ARCADIA\",\"date_created\":\"2017-06-06T20:54:01+00:00\",\"date_modified\":\"2017-06-06T20:54:01+00:00\",\"id\":3,\"incoming_text_fallback_method\":null,\"incoming_text_fallback_url\":null,\"incoming_text_method\":null,\"incoming_text_url\":null,\"lata\":null,\"master_account_id\":10000,\"name\":\"(310)111-2222\",\"phone_number\":\"+13101112222\",\"phone_number_type\":\"local\",\"rate_center\":\"ARCADIA\",\"region\":\"CA\",\"status_text_url\":null,\"voice_forwarding_number\":null}}"
                                ));

            List<NumberAvailable> available = FindAvailableResponse();
            Number number = available[0].Buy(client);
            Assert.NotNull(number);
        }

        public List<NumberAvailable> FindAvailableResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"phone_numbers\":[{\"city\":\"ARCADIA\",\"lata\":null,\"name\":\"(310)111-2222\",\"phone_number\":\"+13101112222\",\"phone_number_type\":\"local\",\"rate_center\":\"ARCADIA\",\"region\":\"CA\"},{\"city\":\"ARCADIA\",\"lata\":null,\"name\":\"(310)222-1111\",\"phone_number\":\"+13102221111\",\"phone_number_type\":\"local\",\"rate_center\":\"ARCADIA\",\"region\":\"CA\"}]}"
                                ));

            return Number.FindAvailable(inRegion: RegionEnum.CA, client: client);
        }

        public Number FindSingleResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"phone_number\":{\"account_id\":10000,\"active\":true,\"address_requirements\":\"none\",\"capabilities\":{\"mms\":true,\"sms\":true,\"voice\":true},\"city\":\"BROCKWAY\",\"date_created\":\"2017-04-27T00:06:36+00:00\",\"date_modified\":\"2017-05-24T18:23:59+00:00\",\"id\":1,\"incoming_text_fallback_method\":null,\"incoming_text_fallback_url\":null,\"incoming_text_method\":null,\"incoming_text_url\":null,\"lata\":null,\"master_account_id\":10000,\"name\":\"Myupdatednumber.\",\"phone_number\":\"+13105559999\",\"phone_number_type\":\"local\",\"rate_center\":\"NTAHBCWY\",\"region\":\"CA\",\"status_text_url\":null,\"voice_forwarding_number\":null}}"
                                ));

            return Number.FindSingle(NumberId, client: client);
        }

        public Number FindSingleLocalResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"phone_number\":{\"account_id\":10000,\"active\":true,\"address_requirements\":\"none\",\"capabilities\":{\"mms\":true,\"sms\":true,\"voice\":true},\"city\":\"BROCKWAY\",\"date_created\":\"2017-04-27T00:06:36+00:00\",\"date_modified\":\"2017-05-24T18:23:59+00:00\",\"id\":1,\"incoming_text_fallback_method\":null,\"incoming_text_fallback_url\":null,\"incoming_text_method\":null,\"incoming_text_url\":null,\"lata\":null,\"master_account_id\":10000,\"name\":\"Myupdatednumber.\",\"phone_number\":\"+13105559999\",\"phone_number_type\":\"local\",\"rate_center\":\"NTAHBCWY\",\"region\":\"CA\",\"status_text_url\":null,\"voice_forwarding_number\":null}}"
                                ));

            return Number.FindSingle(NumberId, local: true, client: client);
        }
    }
}
