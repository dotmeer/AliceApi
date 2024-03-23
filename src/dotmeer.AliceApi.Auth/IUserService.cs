using System.Threading.Tasks;
using System.Threading;
using System;

namespace dotmeer.AliceApi.Auth;

public interface IUserService
{
    /// <summary>
    /// Возвращает идентификатор пользователя в яндексе
    /// </summary>
    /// <param name="token">Токен авторизации</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
    /// <exception cref="UnauthorizedAccessException">Если не удалось проверить токен или пользователю нельзя пользоваться сервисом</exception>
    Task<string> GetUserIdAsync(string? token, CancellationToken cancellationToken);
}