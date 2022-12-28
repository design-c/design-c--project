namespace Logic.Services.Interfaces;

public interface IUrfuHtmlParserService
{
    Task<object> ParseUserInfoHtml(string userInfoHtml);
}