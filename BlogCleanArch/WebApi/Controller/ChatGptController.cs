using Infrastructure.services;
using Microsoft.AspNetCore.Mvc;

public class ChatGptController : ControllerBase
{
    private readonly GptApiService _gptApiService;

    public ChatGptController(GptApiService gptApiService)
    {
        _gptApiService = gptApiService;
    }

    [HttpPost("detect-hate-speech")]
    public async Task<IActionResult> DetectHateSpeech([FromBody] string text)
    {
        try
        {
            var generatedText = await _gptApiService.DetectHateSpeech(text);
            return Ok(generatedText);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
