using Core_API.Service;

using Microsoft.AspNetCore.Mvc;

namespace Core_API.Classes.Base
{
  public class BaseClassController : ControllerBase
  {
    protected HTTPService httpService;
    protected URLData urlData;

    public BaseClassController()
    {
      httpService = new HTTPService();
      urlData = new URLData();
    }
  }
}
