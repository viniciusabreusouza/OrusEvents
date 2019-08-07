using Microsoft.AspNetCore.Mvc;

namespace OrusEvents.Controllers
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
        }
    }
}
