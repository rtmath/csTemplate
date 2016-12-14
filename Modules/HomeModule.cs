using Nancy;
using System.Collections.Generic;

namespace NAMESPACE
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      //Insert your GETs and POSTs here
    }
  }
}
