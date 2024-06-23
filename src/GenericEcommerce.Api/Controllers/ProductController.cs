using System.Security.Claims;
using GenericEcommerce.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GenericEcommerce.Api.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{
    private readonly IProductApplicationService _productApplicationService;

    public ProductController(IProductApplicationService productApplicationService)
    {
        _productApplicationService = productApplicationService;
    }
    
    [HttpGet("/AllowAnonymous")]
    [AllowAnonymous]
    public async Task<IActionResult> TestingAnonymousAccess()
    {
        return Ok();
    }

    [HttpGet("/Admin")]
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> TestingAdminAccess()
    {
        return Ok();
    }

    [HttpGet("/Regular")]
    [Authorize(Roles = "regular")]
    public async Task<IActionResult> TestingRegularAccess()
    {
        return Ok();
    }

    [HttpGet("/AdminAndRegular")]
    [Authorize(Roles = "admin, regular")]
    public async Task<IActionResult> TestingAdminAndRegularAccess()
    {
        return Ok();
    }

    [HttpGet("/AdminAndRegularWithMininumAge")]
    [Authorize(Roles = "admin, regular", Policy ="IdadeMinima")]
    public async Task<IActionResult> TestingAdminAndRegularWithMininumAgeAccess()
    {
        return Ok();
    }


    [HttpGet]
    [Authorize(Roles = "admin, regular")]
    public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber,[FromQuery] int pageSize)
    {
        var userIdClaim = User.FindFirst("id");
        
        var productResponseList = await _productApplicationService.GetAllProductsAsync(pageNumber, pageSize);

        if (!productResponseList.Any()) return NoContent();

        return Ok(productResponseList);
    }
}