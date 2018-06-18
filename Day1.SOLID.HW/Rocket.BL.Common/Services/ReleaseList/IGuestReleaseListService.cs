using Rocket.BL.Common.Models.Pagination;
using System;
using Rocket.BL.Common.Models.ReleaseList;

namespace Rocket.BL.Common.Services.ReleaseList
{
    /// <summary>
    /// Представляет сервис для получения ленты новостей для гостя
    /// </summary>
    public interface IGuestReleaseListService : IDisposable
    {
        /// <summary>
        /// Возвращает страницу вышедших релизов с заданным номером и размером
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns>Информация о странице релизов</returns>
        PageInfo<BaseRelease> GetPublishedReleasesPage(int pageSize, int pageNumber);

        /// <summary>
        /// Возвращает страницу будущих релизов с заданным номером и размером
        /// </summary>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="pageNumber">Номер страницы</param>
        /// <returns>Информация о странице релизов</returns>
        PageInfo<BaseRelease> GetFutureReleasesPage(int pageSize, int pageNumber);
    }
}