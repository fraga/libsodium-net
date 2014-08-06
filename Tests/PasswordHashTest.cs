using System.Text;
using Sodium;
using NUnit.Framework;

namespace Tests
{
  [TestFixture]
  public class PasswordHashTest
  {
    [Test]
    public void HashSalsa208Sha256Test()
    {
      string passhex = "a347ae92bce9f80f6f595a4480fc9c2fe7e7d7148d371e9487d75f5c23008ffae065577a928febd9b1973a5a95073acdbeb6a030cfc0d79caa2dc5cd011cef02c08da232d76d52dfbca38ca8dcbd665b17d1665f7cf5fe59772ec909733b24de97d6f58d220b20c60d7c07ec1fd93c52c31020300c6c1facd77937a597c7a6";
      string salthex = "5541fbc995d5c197ba290346d2c559dedf405cf97e5f95482143202f9e74f5c2";
      long opsLimit = 481326;
      int memLimit = 7256678;

      string actual = PasswordHash.HashSalsa208Sha256(passhex, salthex, opsLimit, memLimit);

      Assert.AreEqual("8D40F5F8C6A1791204F03E19A98CD74F918B6E331B39CFC2415E5014D7738B7BB0A83551FB14A035E07FDD4DC0C60C1A6822AC253918979F6324FF0C87CBA75D3B91F88F41CA5414A0F152BDC4D636F42AB2250AFD058C19EC31A3374D1BD7133289BF21513FF67CBF8482E626AEE9864C58FD05F9EA02E508A10182B7D838", actual);
    }
  }
}

