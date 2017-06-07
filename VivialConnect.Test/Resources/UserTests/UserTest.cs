using System.Collections.Generic;
using System.Net;

using NSubstitute;
using NUnit.Framework;
using VivialConnect.Http;
using VivialConnect.Resources.User;

namespace VivialConnect.Test.Resources.UserTests
{
    [TestFixture]
    public class UserTest : VcTest
    {
        public const int UserId = 1000;

        [Test]
        public void TestFindResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"users\":[{\"account_id\":10000,\"active\":true,\"api_key\":\"5GS321FA6WE98RF1A23SDF\",\"date_created\":\"2017-03-28T21:41:04+00:00\",\"date_modified\":\"2017-05-11T23:52:59+00:00\",\"email\":\"vc@vivial.net\",\"first_name\":\"FirstName\",\"id\":1000,\"last_name\":\"LastName\",\"roles\":[{\"active\":true,\"date_created\":\"2016-09-30T23:42:59+00:00\",\"date_modified\":\"2016-09-30T23:42:59+00:00\",\"description\":\"Accountadministratorrole\",\"id\":3,\"name\":\"AccountAdministrator\",\"role_type\":\"client\"},{\"active\":true,\"date_created\":\"2016-09-30T23:42:59+00:00\",\"date_modified\":\"2016-09-30T23:42:59+00:00\",\"description\":\"Userrole\",\"id\":4,\"name\":\"User\",\"role_type\":\"client\"}],\"timezone\":\"UTC\",\"username\":\"myuser\",\"verified\":true}]}"
                                ));

            List<User> users = User.Find(client: client);
            Assert.NotNull(users);
        }

        [Test]
        public void TestFindSingleResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{\"user\":{\"account_id\":10000,\"active\":true,\"api_key\":\"5GS321FA6WE98RF1A23SDF\",\"date_created\":\"2017-03-28T21:41:04+00:00\",\"date_modified\":\"2017-05-11T23:52:59+00:00\",\"email\":\"vc@vivial.net\",\"first_name\":\"FirstName\",\"id\":1000,\"last_name\":\"LastName\",\"roles\":[{\"active\":true,\"date_created\":\"2016-09-30T23:42:59+00:00\",\"date_modified\":\"2016-09-30T23:42:59+00:00\",\"description\":\"Accountadministratorrole\",\"id\":3,\"name\":\"AccountAdministrator\",\"role_type\":\"client\"},{\"active\":true,\"date_created\":\"2016-09-30T23:42:59+00:00\",\"date_modified\":\"2016-09-30T23:42:59+00:00\",\"description\":\"Userrole\",\"id\":4,\"name\":\"User\",\"role_type\":\"client\"}],\"timezone\":\"UTC\",\"username\":\"myuser\",\"verified\":true}}"
                                ));

            User user = User.FindSingle(UserId, client);
            Assert.NotNull(user);
        }

        [Test]
        public void TestUpdatePasswordResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.OK,
                                    "{}"
                                ));

            bool results = User.UpdatePassword(UserId, "myoldpassword", "mynewpassword", client);
            Assert.AreEqual(true, results);
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

            int count = User.Count(client);
            Assert.AreEqual(1, count);
        }

        [Test]
        public void TestDeleteResponse()
        {
            IVcRestClient client = Substitute.For<IVcRestClient>();
            client.Request(Arg.Any<Request>())
                        .Returns(new Response(
                                    HttpStatusCode.NoContent,
                                    string.Empty
                                ));

            bool results = User.Delete(UserId, client);
            Assert.AreEqual(true, results);
        }
    }
}
