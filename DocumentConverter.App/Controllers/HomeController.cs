using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DocumentConverter.App.Services;
using DocumentConverter.App.Models;

namespace DocumentConverter.App.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDocumentService _documentService;

    public HomeController(
        ILogger<HomeController> logger,
        IDocumentService documentService
    )
    {
        _documentService = documentService;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        // TODO Get user ID from auth claims
        var documents = await _documentService.GetDocumentsByUserIdAsync(Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"));
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
        // TODO Create created record for document file (in file status transaction table?)
        // TODO Create created record for document
        // TODO Convert document to other formats
        // TODO Create created record for each converted document file
        // TODO Create converted record for document
        // TODO Write each file to S3
        // TODO Create success record for each file
        // TODO Create success record for document
        // await _documentService.CreateDocumentAsync(file);
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
