using Xunit;

namespace JenkinsMvc.Test
{ 
     
     public class HomeController {
       
       
           [Fact]   
           public void HelloTest() {
               var hc  = new HomeController();
               Assert.NotNull(hc);
           }
        }
    }
