using Xunit;
using JM = JenkinsMvc.Controllers;

namespace JenkinsMvc.Test
{
    public class HomeController
    {
      [Fact]
      public void HelloTest()
      {
        var hc = new JM.HomeController();
        Assert.NotNull(hc);
      }
    }
}