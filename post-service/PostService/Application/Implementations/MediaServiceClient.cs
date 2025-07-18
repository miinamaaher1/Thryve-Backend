using Application.DTOs;
using Application.IServices;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Application.Services;

public class MediaServiceClient : IMediaServiceClient
{
    private readonly HttpClient _http;
    private const string BASE_ROUTE = "api/internal/media";

    public MediaServiceClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<MediaUploadResponse> UploadMediaAsync(MediaUploadRequest request, CancellationToken ct = default)
    {
        using var form = new MultipartFormDataContent();

        // Add files
        foreach (var file in request.Files)
        {
            var streamContent = new StreamContent(file.OpenReadStream());
            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse(
                string.IsNullOrWhiteSpace(file.ContentType) ? "application/octet-stream" : file.ContentType);
            form.Add(streamContent, "Files", file.FileName);
        }

        // Add media type
        form.Add(new StringContent(request.MediaType.ToString()), "MediaType");

        // Add usage category
        form.Add(new StringContent(request.usageCategory.ToString()), "UsageCategory");

        var response = await _http.PostAsync(BASE_ROUTE, form, ct);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<MediaUploadResponse>(cancellationToken: ct)
            ?? throw new InvalidOperationException("Failed to deserialize media upload response");
    }
}
