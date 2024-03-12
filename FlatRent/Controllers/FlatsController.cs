using Microsoft.AspNetCore.Mvc;

namespace FlatRent.Controllers;

public class FlatsController : BaseApiController
{

    public FlatsController()
    {
        
    }

    [HttpGet]
    public async Task<ActionResult> GetFlatsList()
    {
        return null;
    }

    [HttpPost]
    public async Task<ActionResult> AddNewFlat()
    {
        return null;
    }
    
}