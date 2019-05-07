using System.IO;
using NUnit.Framework;
using Storage.Serializers;

namespace Storage.Tests
{
    [TestFixture]
    public class Sqlitetests
    {
        [Test]
        public void TestSqliteConnection()
        {
            var path = @"d:\Personal\sources\timeSheets\test.db ";
            if(File.Exists(path))
                File.Delete(path);

            using (var s = Factory.GetDbSerializer(path))
            {
                Assert.True(File.Exists(path));
            }
        }
    }
}
