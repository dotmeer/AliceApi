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
    Task<string?> GetUserIdAsync(string? token, CancellationToken cancellationToken);
}