﻿using Microsoft.AspNetCore.Mvc;

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
    
}