using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using DocumentConverter.App.Services;
using DocumentConverter.App.Models;

namespace DocumentConverter.App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDocumentService _documentService;
    private readonly IDocumentProcessingService _documentProcessingService;

    public HomeController(
        ILogger<HomeController> logger,
        IDocumentService documentService,
        IDocumentProcessingService documentProcessingService
    )
    {
        _documentService = documentService;
        _documentProcessingService = documentProcessingService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        // TODO Get user ID from auth claims
        var userId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        var documents = await _documentService.GetDocumentsByUserIdAsync(userId);
        var documentViewModels = documents?.Select(d => new DocumentViewModel(d)).ToList() ?? new List<DocumentViewModel>();
        return View(documentViewModels);
    }

    public IActionResult Upload()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        // TODO Get user ID from auth claims
        var userId = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff");

        // TODO processing and saving should happen async, user should get redirected instantly and notified when done or failed
        await _documentProcessingService.ProcessNewDocumentAsync(userId, file);

        _logger.LogInformation("Uploaded file: {FileName}", file.FileName);
        return RedirectToAction("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
