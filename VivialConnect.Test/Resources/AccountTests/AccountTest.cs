using System;
using System.Net;

using NSubstitute;
using NUnit.Framework;
using VivialConnect.Http;
using VivialConnect.Resources.Account;

namespace VivialConnect.Test.Resources.AccountTests
{
    [TestFixture]
    public class AccountTest : VcTest
    {
        [Test]
        public void TestFindSingleResponse()
        {
            Account account = FindSingleResponse();
            Assert.NotNull(account);
        }

        [Test]
        public void TestSaveResponse()
        {
            Account account = FindSingleResponse();

            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"account\":{\"account_id\":null,\"active\":true,\"company_name\":\"My Updated Master Account\",\"contacts\":[{\"account_id\":10000,\"active\":true,\"address1\":\"123 Main St\",\"address2\":null,\"address3\":null,\"city\":\"Los Angeles\",\"company_name\":\"Vivial\",\"contact_type\":\"main\",\"country\":\"US\",\"date_created\":\"2017-03-28T21:41:04+00:00\",\"date_modified\":\"2017-04-04T21:57:19+00:00\",\"email\":\"vc@vivial.net\",\"fax\":null,\"first_name\":\"FirstName\",\"id\":1,\"last_name\":\"LastName\",\"mobile_phone\":\"999-999-9999\",\"postal_code\":\"90210\",\"state\":\"CA\",\"title\":null,\"work_phone\":null}],\"date_created\":\"2017-03-28T21:41:04+00:00\",\"date_modified\":\"2017-05-15T21:49:43+00:00\",\"id\":10000,\"services\":[{\"active\":true,\"date_created\":\"2016-09-30T23:42:58+00:00\",\"date_modified\":\"2016-09-30T23:42:58+00:00\",\"description\":\"SMS service\",\"id\":1,\"name\":\"sms\",\"service_type\":\"client\"},{\"active\":true,\"date_created\":\"2016-09-30T23:42:58+00:00\",\"date_modified\":\"2016-09-30T23:42:58+00:00\",\"description\":\"Account service\",\"id\":2,\"name\":\"accounts\",\"service_type\":\"client\"},{\"active\":true,\"date_created\":\"2016-09-30T23:42:58+00:00\",\"date_modified\":\"2016-09-30T23:42:58+00:00\",\"description\":\"Public service\",\"id\":3,\"name\":\"public\",\"service_type\":\"client\"}]}}"
                                ));

            account.CompanyName = "My Updated Master Account";
            account.Save(client);
            Assert.AreEqual("My Updated Master Account", account.CompanyName);
        }

        [Test]
        public void TestGetLogsResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                           .Returns(new Response(
                                        HttpStatusCode.OK,
                                        "{\"last_key\":\"\",\"log_items\":[{\"account_id\":\"10000\",\"account_id_item_id\":\"10000-+13109999999\",\"account_id_log_type\":\"10000-number.purchased\",\"account_id_operator_id\":\"10000-10000\",\"description\":\"numberpurchased\",\"item_id\":\"+13109999999\",\"item_type\":\"number\",\"log_data\":{\"phone_number\":\"+113109999999\"},\"log_data_json\":\"{\\\"phone_number\\\":\\\"+13109999999\\\"}\",\"log_id\":\"33340905951207340072784104845492921599137333898341842944\",\"log_timestamp\":20170517215209876172,\"log_type\":\"number.purchased\",\"operator_id\":\"10000\",\"operator_type\":\"account\",\"origin\":\"system\"},{\"account_id\":\"10000\",\"account_id_item_id\":\"10000-+13109999999\",\"account_id_log_type\":\"10000-number.create\",\"account_id_operator_id\":\"10000-00\",\"description\":\"chargenumber\",\"item_id\":\"+13109999999\",\"item_type\":\"local\",\"log_data\":{\"number\":\"+13109999999\",\"number_type\":\"local\"},\"log_data_json\":\"{\\\"number_type\\\":\\\"local\\\",\\\"number\\\":\\\"+13109999999\\\"}\",\"log_id\":\"33340905945476048556761734697849912190563694622780293120\",\"log_timestamp\":20170517215209619776,\"log_type\":\"number.create\",\"operator_id\":\"10000\",\"operator_type\":\"number\",\"origin\":\"system\"}]}"
                                   ));

            DateTime startTime = new DateTime(2017, 5, 16);
            DateTime endTime = new DateTime(2017, 5, 18);
            AccountLogs logs = Account.GetLogs(startTime, endTime, client: client);
            Assert.NotNull(logs);
        }

        [Test]
        public void TestGetLogsAggregateResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                           .Returns(new Response(
                                        HttpStatusCode.OK,
                                        "{\"last_key\":\"\",\"log_items\":[{\"account_id\":\"10000\",\"account_id_log_type\":\"10000-number.create\",\"aggregate_key\":\"hours\",\"log_count\":1,\"log_timestamp\":2017051721,\"log_type\":\"number.create\"},{\"account_id\":\"10000\",\"account_id_log_type\":\"10000-number.purchased\",\"aggregate_key\":\"hours\",\"log_count\":1,\"log_timestamp\":2017051721,\"log_type\":\"number.purchased\"}]}"
                                   ));

            DateTime startTime = new DateTime(2017, 5, 16);
            DateTime endTime = new DateTime(2017, 5, 18);
            AccountLogsAggregate logs = Account.GetLogsAggregate(startTime, endTime, AggregatorTypeEnum.Hours, client: client);
            Assert.NotNull(logs);
        }

        public Account FindSingleResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"account\":{\"account_id\":10000,\"active\":true,\"company_name\":\"My Master Account\",\"contacts\":[{\"account_id\":10000,\"active\":true,\"address1\":\"123 Main St\",\"address2\":null,\"address3\":null,\"city\":\"Los Angeles\",\"company_name\":\"Vivial\",\"contact_type\":\"main\",\"country\":\"US\",\"date_created\":\"2017-03-28T21:41:04+00:00\",\"date_modified\":\"2017-04-04T21:57:19+00:00\",\"email\":\"vc@vivial.net\",\"fax\":null,\"first_name\":\"FirstName\",\"id\":1,\"last_name\":\"LastName\",\"mobile_phone\":\"999-999-9999\",\"postal_code\":\"90210\",\"state\":\"CA\",\"title\":null,\"work_phone\":null}],\"date_created\":\"2017-03-28T21:41:04+00:00\",\"date_modified\":\"2017-05-15T21:49:43+00:00\",\"id\":10000,\"services\":[{\"active\":true,\"date_created\":\"2016-09-30T23:42:58+00:00\",\"date_modified\":\"2016-09-30T23:42:58+00:00\",\"description\":\"SMS service\",\"id\":1,\"name\":\"sms\",\"service_type\":\"client\"},{\"active\":true,\"date_created\":\"2016-09-30T23:42:58+00:00\",\"date_modified\":\"2016-09-30T23:42:58+00:00\",\"description\":\"Account service\",\"id\":2,\"name\":\"accounts\",\"service_type\":\"client\"},{\"active\":true,\"date_created\":\"2016-09-30T23:42:58+00:00\",\"date_modified\":\"2016-09-30T23:42:58+00:00\",\"description\":\"Public service\",\"id\":3,\"name\":\"public\",\"service_type\":\"client\"}]}}"
                                ));

            return Account.FindSingle(client);
        }
    }
}
